using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelBtn : ButtonAbstract
{
    public override void OnClick()
    {
        GameUIManager.Ins.NextLevel();
    }
}
