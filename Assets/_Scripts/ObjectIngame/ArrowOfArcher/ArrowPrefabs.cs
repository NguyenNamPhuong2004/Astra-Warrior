using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPrefabs : PoolPrefabs<Arrow>
{
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Length > 0) return;
        this.prefabs = Resources.LoadAll<Arrow>("Prefabs/Arrow");
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}
