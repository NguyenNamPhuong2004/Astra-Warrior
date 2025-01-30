using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextSpawning : LoadData
{
    [SerializeField] protected DamageTextSpawner spawner;
    public DamageTextSpawner Spawner => spawner;

    [SerializeField] protected DamageTextPrefabs prefabs;
    public DamageTextPrefabs Prefabs => prefabs;


    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<DamageText> spawnedDamageTexts = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<DamageTextSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponent<DamageTextPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        //this.RemoveDeadOne();
    }

    public virtual void Spawning(Vector3 spawnDamageTextPosition, string color, int damage)
    {
        DamageText prefab = this.Prefabs.GetRandom();
        DamageText newDamageText = this.Spawner.Spawn(prefab, spawnDamageTextPosition);
        this.spawnedDamageTexts.Add(newDamageText);
        newDamageText.GetComponentInChildren<Text>().text = damage.ToString();
        if (color == "Green") newDamageText.GetComponentInChildren<Text>().color = new Color(0, 1, 0, 1);
        else newDamageText.GetComponentInChildren<Text>().color = new Color(1, 0, 0, 1);
    }
}
