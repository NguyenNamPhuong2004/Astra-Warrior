using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawning : LoadData
{
    [SerializeField] protected HeroSpawner spawner;
    public HeroSpawner Spawner => spawner;

    [SerializeField] protected HeroPrefabs prefabs;
    public HeroPrefabs Prefabs => prefabs;
   
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

    public virtual void Spawning(Vector3 spawnHeroPosition, int id)
    {
        Hero prefab = this.Prefabs.GetByID(id);
        Hero newHero = this.Spawner.Spawn(prefab, spawnHeroPosition);
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
