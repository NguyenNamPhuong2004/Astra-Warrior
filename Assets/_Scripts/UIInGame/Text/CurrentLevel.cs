using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurentLevelText : TextAbstract
{
    private void Start()
    {
        UpdateView();
    }
    private void UpdateView()
    {
        text.text = DataPlayer.GetLevelGame().ToString();
    }
    private void OnEnable()
    {
        DataPlayer.AddListenerUpdateCurrentLevelEvent(UpdateView);
    }
    private void OnDisable()
    {
        DataPlayer.RemoveListenerUpdateCurrentLevelEvent(UpdateView);
    }
}
