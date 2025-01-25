using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGamePlayBtn : ButtonAbstract
{
    public override void OnClick()
    {
        GameUIManager.Ins.ResetGamePlay();
    }
}
