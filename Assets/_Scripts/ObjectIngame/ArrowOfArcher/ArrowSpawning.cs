using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawning : LoadData
{
    [SerializeField] protected ArrowSpawner spawner;
    public ArrowSpawner Spawner => spawner;

    [SerializeField] protected ArrowPrefabs prefabs;
    public ArrowPrefabs Prefabs => prefabs;


    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<Arrow> spawnedArrows = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ArrowSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponent<ArrowPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        //this.RemoveDeadOne();
    }

    public virtual void Spawning(Vector3 archerPosition)
    {
        if (this.spawnedArrows.Count >= this.maxSpawn) return;
        Arrow prefab = this.Prefabs.GetRandom();
        Arrow newArrow = this.Spawner.Spawn(prefab, archerPosition);
        this.spawnedArrows.Add(newArrow);
    }
}
