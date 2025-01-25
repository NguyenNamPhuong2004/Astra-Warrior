using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAdsBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenAds();
    }
}
