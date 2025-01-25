using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenLevel();
    }
}
