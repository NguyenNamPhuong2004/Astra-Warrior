using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInMenu : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Setting;
    public GameObject EarnCoin;
    public GameObject ShopHero;
    public GameObject ShopCastle;
    public GameObject DailyReward;
    public GameObject Ads;
    public GameObject Level;
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
    public void disPlayLevel()
    {
        if (Level.activeSelf) unDisPlayLevel();
        else Level.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void unDisPlayLevel()
    {
        Level.SetActive(false);
    }
    public void displayShop()
    {
        Shop.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void unDisplayShop()
    {
        Shop.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void displayEarnCoin()
    {
        EarnCoin.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void unDisplayEarnCoin()
    {
        EarnCoin.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void displaySetting()
    {
        Setting.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void unDisplaySetting()
    {
        Setting.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void displayShopHero()
    {
        ShopHero.transform.SetSiblingIndex(ShopHero.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void displayShopCastle()
    {
        ShopCastle.transform.SetSiblingIndex(ShopCastle.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void displayDailyReward()
    {
        DailyReward.transform.SetSiblingIndex(ShopHero.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void displayAds()
    {
        Ads.transform.SetSiblingIndex(ShopCastle.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void ResetDataGame()
    {
        DataPlayer.ResetGameData();
        SoundManager.Ins.ButtonSound();
    }
    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

