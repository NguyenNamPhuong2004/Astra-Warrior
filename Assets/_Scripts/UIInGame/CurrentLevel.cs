using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField] private Text curLevel;

    private void Update()
    {
        curLevel.text = "Level:" + DataPlayer.GetLevelGame().ToString();
    }
}
