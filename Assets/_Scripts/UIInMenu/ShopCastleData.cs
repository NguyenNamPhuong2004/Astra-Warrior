using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Castle Data", menuName = "CastleData")]
public class ShopCastleData : ScriptableObject
{
    public ShopCastleElement shopCastle;
    public ShopArrowsElement shopArrows;
    public ShopFoodElement shopFood;
}
[System.Serializable]
public class ShopCastleElement
{
    public string ItemName;
    public int unlockCost;
    public int unlockedLevel;
    public CastleStats[] castleLevel;
}
[System.Serializable]
public class ShopArrowsElement
{
    public string ItemName;
    public int unlockCost;
    public int unlockedLevel;
    public ArrowsStats[] arrowsLevel;
}
[System.Serializable]
public class ShopFoodElement
{
    public string ItemName;
    public int unlockCost;
    public int unlockedLevel;
    public FoodStats[] foodLevel;
}
[System.Serializable]
public class CastleStats
{
    public int heathMax;
    public int armor;
}

[System.Serializable]
public class ArrowsStats
{
    public int damage;
    public int timeSkill;
}

[System.Serializable]
public class FoodStats
{ 
    public int foodMax;
    public float foodSpeed;
}
