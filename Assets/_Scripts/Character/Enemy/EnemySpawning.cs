using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : LoadData
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;

    [SerializeField] protected EnemyPrefabs prefabs;
    public EnemyPrefabs Prefabs => prefabs;


    public int spawnSpeed = 1;
    [SerializeField] protected List<Enemy> spawnedEnemys = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponent<EnemyPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        //this.RemoveDeadOne();
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
        Enemy prefab = this.Prefabs.GetRandom();
        Enemy newEnemy = this.Spawner.Spawn(prefab, transform.position);
        this.spawnedEnemys.Add(newEnemy);
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
