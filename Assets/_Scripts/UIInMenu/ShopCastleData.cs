using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Castle Data", menuName = "CastleData")]
public class ShopCastleData : ScriptableObject
{
    public CastleData shopCastle;
    public ArrowsData shopArrows;
    public FoodData shopFood;
}
[System.Serializable]
public class CastleData
{
    public string ItemName;
    public int unlockedLevel;
    public CastleStats[] castleLevel;
}
[System.Serializable]
public class ArrowsData
{
    public string ItemName;
    public int unlockedLevel;
    public ArrowsStats[] arrowsLevel;
}
[System.Serializable]
public class FoodData
{
    public string ItemName;
    public int unlockedLevel;
    public FoodStats[] foodLevel;
}
[System.Serializable]
public class CastleStats
{
    public int maxHp;
    public int armor;
    public int unlockCost;
}

[System.Serializable]
public class ArrowsStats
{
    public int damage;
    public int timeSkill;
    public int unlockCost;
}

[System.Serializable]
public class FoodStats
{ 
    public int foodMax;
    public float foodSpeed;
    public int unlockCost;
}
