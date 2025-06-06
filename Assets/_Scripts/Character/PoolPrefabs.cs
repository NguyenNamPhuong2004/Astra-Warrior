using System.Collections.Generic;
using UnityEngine;

public abstract class PoolPrefabs<T> : LoadData where T : PoolObj
{
    [SerializeField] protected T[] prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        // For override
    }

    public virtual T GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Length);
        return this.prefabs[rand];
    }
    public virtual T GetRandom(int id)
    {
        int rand = Random.Range(0, id);
        return this.prefabs[rand];
    }

    public virtual T GetByName(string prefabName)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != prefabName) continue;
            return prefab;
        }

        return null;
    }
    public virtual T GetByID(int id)
    {
        if (id >= prefabs.Length) return null;
        return this.prefabs[id];
    }
}
