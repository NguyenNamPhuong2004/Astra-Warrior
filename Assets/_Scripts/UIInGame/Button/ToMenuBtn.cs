using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenuBtn : ButtonAbstract
{
    public override void OnClick()
    {
        GameUIManager.Ins.ToMenu();
    }
}
