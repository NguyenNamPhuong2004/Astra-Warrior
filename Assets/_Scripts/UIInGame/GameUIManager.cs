using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : Singleton<GameUIManager>
{
    protected override void Awake()
    {
        MakeSingleton(false);
        musicController.value = DataPlayer.GetMusic();
        soundController.value = DataPlayer.GetSound();
    }
    public GameObject setting;
    public Slider musicController;
    public Slider soundController;
    private void Update()
    {
        ControllVolume();
    }
    private void ControllVolume()
    {   
        DataPlayer.SetMusic(musicController.value);
        DataPlayer.SetSound(soundController.value);
        SoundManager.Ins.AufxBackground.volume = musicController.value;
        SoundManager.Ins.AufxRain.volume = musicController.value;
        SoundManager.Ins.AufxClick.volume = soundController.value;
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


