using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroNearAttack : HeroAttack
{
    public override void TakeDamage()
    {
        base.TakeDamage();
        SoundManager.Ins.SwordAttack();
    }
}
