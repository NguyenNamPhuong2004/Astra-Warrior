using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDialogEffect : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDialogText;
    private void gameOverDialogEffect()
    {
        gameOverDialogText.SetActive(true);
    }
}
