using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Hero Data", menuName = "HeroData")]
public class ShopHeroData : ScriptableObject
{
    public ShopHeroElement[] shopHero;
}
[System.Serializable]
public class ShopHeroElement
{
    public string heroName;
    public int id;
    public bool isUnlocked;
    public int unlockCost;
    public int unlockedLevel;
    public HeroStats[] heroLevel;
}
[System.Serializable]
public class HeroStats
{
    public int damage;
    public int maxHealth;
    public int armor;
}
