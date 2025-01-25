using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingMenuBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.CloseSetting();
    }
}
