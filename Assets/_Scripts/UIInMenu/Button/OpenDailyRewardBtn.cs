using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDailyRewardBtn : ButtonAbstract
{
    public override void OnClick()
    {
        MenuUIManager.Ins.OpenDailyReward();
    }
}
  
