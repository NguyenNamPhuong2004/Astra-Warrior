using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopCastleBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenShopCastle();
    }
}
