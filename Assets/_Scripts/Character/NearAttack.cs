using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearAttack : HeroAttack
{
    protected override void TakeDamage()
    {
        base.TakeDamage();
        SoundManager.Ins.SwordAttack();
    }
}
