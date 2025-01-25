using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopHeroBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenShopHero();
    }
}
