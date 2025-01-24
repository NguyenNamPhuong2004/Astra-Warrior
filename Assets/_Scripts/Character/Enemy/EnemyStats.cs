using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : LoadData
{
    [SerializeField] private AllEnemyData allEnemyData;
    public int id;
    public int damage;
    public int maxHp;
    public int armor;
    public int speed;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyData();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        ResetEnemyStats();
    }

    private void ResetEnemyStats()
    {
        damage = allEnemyData.enemyData[id].damage;
        maxHp = allEnemyData.enemyData[id].maxHp;
        armor = allEnemyData.enemyData[id].armor;
        speed = 5;
    }
    public void SetID(int id)
    {
        this.id = id;
    }
    protected virtual void LoadEnemyData()
    {
        if (this.allEnemyData != null) return;
        this.allEnemyData = Resources.Load<AllEnemyData>("Prefabs/Enemy Data");
        Debug.Log(transform.name + ": allEnemyData ", gameObject);
    }
}
