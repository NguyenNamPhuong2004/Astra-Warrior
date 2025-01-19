using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CancelBtn : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene(1);
        SoundManager.Ins.ButtonSound();
        SoundManager.Ins.Music();
    }
}
