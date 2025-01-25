using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : Singleton<MenuUIManager>
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

    protected override void Awake()
    {
        MakeSingleton(false);
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
    public void OpenLevel()
    {
        if (Level.activeSelf) CloseLevel();
        else Level.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void CloseLevel()
    {
        Level.SetActive(false);
    }
    public void OpenShop()
    {
        Shop.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void CloseShop()
    {
        Shop.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void OpenEarnCoin()
    {
        EarnCoin.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void CloseEarnCoin()
    {
        EarnCoin.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void OpenSetting()
    {
        Setting.SetActive(true);
        SoundManager.Ins.ButtonSound();
    }
    public void CloseSetting()
    {
        Setting.SetActive(false);
        SoundManager.Ins.ButtonSound();
    }
    public void OpenShopHero()
    {
        ShopHero.transform.SetSiblingIndex(ShopHero.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void OpenShopCastle()
    {
        ShopCastle.transform.SetSiblingIndex(ShopCastle.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void OpenDailyReward()
    {
        DailyReward.transform.SetSiblingIndex(ShopHero.transform.parent.childCount - 1);
        SoundManager.Ins.ButtonSound();
    }
    public void OpenAds()
    {
        Ads.transform.SetSiblingIndex(ShopCastle.transform.parent.childCount - 1);
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

