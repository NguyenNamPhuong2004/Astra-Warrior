using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenShop();
    }
}
