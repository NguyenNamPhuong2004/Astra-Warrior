using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInGame : MonoBehaviour
{
    public GameObject setting;
    public Slider musicController;
    public Slider soundController;
    private void Awake()
    {
        musicController.value = DataPlayer.GetMusic();
        soundController.value = DataPlayer.GetSound();
    }
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
    public void displaySetting()
    {
        Time.timeScale = 0;
        setting.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void unDisplaySetting()
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


