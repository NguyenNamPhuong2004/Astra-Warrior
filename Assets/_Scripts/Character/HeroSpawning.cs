using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawning : LoadData
{
    [SerializeField] protected HeroSpawner spawner;
    public HeroSpawner Spawner => spawner;

    [SerializeField] protected HeroPrefabs prefabs;
    public HeroPrefabs Prefabs => prefabs;
    

    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<Hero> spawnedHeros = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<HeroSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponent<HeroPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        //this.RemoveDeadOne();
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.spawnedHeros.Count >= this.maxSpawn) return;

        Hero prefab = this.Prefabs.GetRandom();
        Hero newHero = this.Spawner.Spawn(prefab, transform.position);
        this.spawnedHeros.Add(newHero);
    }

    //protected virtual void RemoveDeadOne()
    //{
    //    foreach (Hero hero in this.spawnedHeros)
    //    {
    //        if (hero.EnemyDamageReceiver.IsDead())
    //        {
    //            this.spawnedHeros.Remove(enemyCtrl);
    //            return;
    //        }
    //    }
    //}
}
