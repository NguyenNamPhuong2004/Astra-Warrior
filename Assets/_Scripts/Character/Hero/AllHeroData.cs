using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Hero Data", menuName = "HeroData")]
public class AllHeroData : ScriptableObject
{
    public HeroData[] heroData;
}
[System.Serializable]
public class HeroData
{
    public string heroName;
    public int id;
    public bool isUnlocked;
    public int unlockedLevel;
    public HeroLevelStats[] heroLevel;
}
[System.Serializable]
public class HeroLevelStats
{
    public int damage;
    public int maxHp;
    public int armor;
    public int unlockCost;
}
