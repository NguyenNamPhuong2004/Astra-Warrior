using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : Singleton<GameUIManager>
{
   
    public GameObject setting;
    protected override void Awake()
    {
        MakeSingleton(false);
    }
    public void OpenSetting()
    {
        Time.timeScale = 0;
        setting.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void CloseSetting()
    {
        Time.timeScale = 1;
        setting.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(1);
        SoundManager.Ins.AufxRain.loop = false;
        SoundManager.Ins.ButtonSound();
        Time.timeScale = 1;
    }
    public void ResetGamePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        SoundManager.Ins.ButtonSound();
    }
    public void NextLevel()
    {
        if (DataPlayer.GetLevelGame() >= 5) return;
        DataPlayer.SetLevelGame(DataPlayer.GetLevelGame() + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


