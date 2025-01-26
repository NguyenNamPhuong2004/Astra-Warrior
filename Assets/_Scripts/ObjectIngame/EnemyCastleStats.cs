using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastleStats : LoadData
{
    private int level;
    public int maxHP;
    public int curHP;
    public int armor;
    protected override void ResetValue()
    {
        base.ResetValue();
        ResetCastleStats();
    }

    private void ResetCastleStats()
    {
        level = DataPlayer.GetLevelGame();
        maxHP = 8000 + 3000 * level;
        armor = 80 + 30 * level;
        curHP = maxHP;
    }
}
