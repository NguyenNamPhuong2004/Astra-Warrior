using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : PoolPrefabs<Enemy>
{
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Length > 0) return;
        this.prefabs = Resources.LoadAll<Enemy>("Prefabs/Enemy");
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}
