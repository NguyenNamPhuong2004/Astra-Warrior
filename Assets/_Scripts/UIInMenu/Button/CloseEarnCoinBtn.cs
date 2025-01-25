using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEarnCoinBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.CloseEarnCoin();
    }
}
