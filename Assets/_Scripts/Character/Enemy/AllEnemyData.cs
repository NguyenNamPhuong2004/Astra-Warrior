using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Enemy Data", menuName = "EnemyData")]
public class AllEnemyData : ScriptableObject
{
    public EnemyData[] enemyData;
}
[System.Serializable]
public class EnemyData
{
    public string enemyName;
    public int id;
    public int damage;
    public int maxHp;
    public int armor;
}

