using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEarnCoinBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenEarnCoin();
    }
}
