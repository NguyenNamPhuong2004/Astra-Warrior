using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLevelBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.CloseLevel();
    }
}
