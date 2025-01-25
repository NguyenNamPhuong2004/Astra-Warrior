using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingMenuBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenSetting();
    }
}
