using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataPlayer
{
    private const string ALL_DATA = "all_data";
    public static AllData allData;

    public static UnityEvent updateCoinEvent = new();
    public static UnityEvent updateCurrentLevelEvent = new();
    static DataPlayer()
    {
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));
        if (allData == null)
        {
            allData = new AllData
            {
                heroList = new List<int>() { 0 },
                levelHeroList = new List<int>(new int[4]),
                coin = 1000,
                maxlevel = 4,
                endtime = new string(DateTime.Now.AddHours(24).ToString("yyyy-MM-ddTHH:mm:ss")),
                starttime1 = new string(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                isTime = false,
                canDaily = true,
                dailyProcess = 0,
                levelGame = 1,
                unlockLevelGame = 1,
                music = 0.5f,
                sound = 0.5f
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static bool IsMaxLevel(int id)
    {
        return allData.IsMaxLevel(id);
    }
    public static bool IsUnlocked(int id)
    {
        return allData.IsUnlocked(id);
    }
    public static bool IsCanPurchase(int cost, int level)
    {
        return allData.IsCanPurchase(cost, level);
    }
    public static void AddHero(int id)
    {
        allData.AddHero(id);
        SaveData();
    }
    public static List<int> GetHeroList()
    {
        return allData.GetHeroList();
    }

    public static void SetLevelHero(int id)
    {
        allData.SetLevelHero(id);
        SaveData();
    }
    public static int GetLevelHero(int id)
    {
        return allData.GetLevelHero(id);
    }
    public static void SetLevelCastle()
    {
        allData.SetLevelCastle();
        SaveData();
    }
    public static int GetLevelCastle()
    {
        return allData.GetLevelCastle();
    }
    public static void SetLevelArrows()
    {
        allData.SetLevelArrows();
        SaveData();
    }
    public static int GetLevelArrows()
    {
        return allData.GetLevelArrows();
    }
    public static void SetLevelFood()
    {
        allData.SetLevelFood();
        SaveData();
    }
    public static int GetLevelFood()
    {
        return allData.GetLevelFood();
    }

    public static int GetCoin()
    {
        return allData.GetCoin();
    }
    public static void SetCoin(int cost)
    {
        allData.SetCoin(cost);
        updateCoinEvent?.Invoke();
        SaveData();
    }
    public static bool IsEnoughMoney(int cost)
    {
        return allData.IsEnoughMoney(cost);
    }
    public static void AddCoin(int money)
    {
        allData.AddCoin(money);
        updateCoinEvent?.Invoke();
        SaveData();
    }
    public static void SetisTime(bool istime)
    {
        allData.SetisTime(istime);
        SaveData();
    }
    public static bool GetisTime()
    {
        return allData.GetisTime();
    }
    public static void SetCanDaily(bool candaily)
    {
        allData.SetCanDaily(candaily);
        SaveData();
    }
    public static bool GetCanDaily()
    {
        return allData.GetCanDaily();
    }
    public static void SetDailyProcess()
    {
        allData.SetDailyProcess();
        SaveData();
    } 
    public static int GetDailyProcess()
    {
        return allData.GetDailyProcess();
    }
    public static void SetEndtime(DateTime end)
    {
        allData.SetEndtime(end);
        SaveData();
    }
    public static DateTime GetEndtime()
    {
        return allData.GetEndtime();
    }
    public static void SetStarttime1(DateTime start)
    {
        allData.SetStarttime1(start);
        SaveData();
    }
    public static DateTime GetStarttime1()
    {
        return allData.GetStarttime1();
    }
    public static void SetLevelGame(int level)
    {
        allData.SetLevelGame(level);
        SaveData();
    }
    public static int GetLevelGame()
    {
        return allData.GetLevelGame();
    }  
    public static void SetUnlockLevelGame()
    {
        allData.SetUnlockLevelGame();
        SaveData();
    }
    public static int GetUnlockLevelGame()
    {
        return allData.GetUnlockLevelGame();
    } 
    public static void SetMusic(float volume)
    {
        allData.SetMusic(volume);
    }
    public static float GetMusic()
    {
        return allData.GetMusic();
    }
    public static void SetSound(float volume)
    {
        allData.SetSound(volume);
    }
    public static float GetSound()
    {
        return allData.GetSound();
    }
    public static void AddListenerUpdateCoinEvent(UnityAction updateCoin)
    {
        updateCoinEvent.AddListener(updateCoin);
    }
    public static void RemoveListenerUpdateCoinEvent(UnityAction updateCoin)
    {
        updateCoinEvent.RemoveListener(updateCoin);
    }
    public static void AddListenerUpdateCurrentLevelEvent(UnityAction updateCurrentLevel)
    {
        updateCurrentLevelEvent.AddListener(updateCurrentLevel);
    }
    public static void RemoveListenerUpdateCurrentLevelEvent(UnityAction updateCurrentLevel)
    {
        updateCurrentLevelEvent.RemoveListener(updateCurrentLevel);
    }
    public static void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
    }
}
public class AllData
{
    public List<int> heroList;
    public List<int> levelHeroList;
    public int levelCastle;
    public int levelArrows;
    public int levelFood;
    public int coin;
    public int maxlevel;
    public string endtime;
    public string starttime1;
    public bool isTime;
    public bool canDaily;
    public int dailyProcess;
    public int levelGame;
    public int unlockLevelGame;
    public float music;
    public float sound;

    public bool IsMaxLevel(int level)
    {
        return level >= maxlevel;
    }
    public void AddHero(int id)
    {
        if (IsUnlocked(id)) return;
        heroList.Add(id);  
    }
    public List<int> GetHeroList()
    {
        return heroList;
    }
    public void SetLevelHero(int id)
    {
        levelHeroList[id]++;
    }
    public int GetLevelHero(int id)
    {
        return levelHeroList[id];
    }
    public void SetLevelCastle()
    {
        levelCastle++;
    }
    public int GetLevelCastle()
    {
        return levelCastle;
    }
    public void SetLevelArrows()
    {
        levelArrows++;
    }
    public int GetLevelArrows()
    {
        return levelArrows;
    }
    public void SetLevelFood()
    {
        levelFood++;
    }
    public int GetLevelFood()
    {
        return levelFood;
    }
    public bool IsUnlocked(int id)
    {
        return heroList.Contains(id);
    }
    public bool IsCanPurchase(int cost, int level)
    {
        return IsEnoughMoney(cost) && !IsMaxLevel(level);
    }
    public void SetCoin(int cost)
    {
        coin -= cost;
    }
    public int GetCoin()
    {
        return coin;
    }
    public bool IsEnoughMoney(int cost)
    {
        return coin >= cost;
    }
    public void AddCoin(int money)
    {
        coin += money;
    }
    public void SetEndtime(DateTime end)
    {
        endtime = end.ToString("yyyy-MM-ddTHH:mm:ss");
    }
    public DateTime GetEndtime()
    {
        return DateTime.ParseExact(endtime, "yyyy-MM-ddTHH:mm:ss", null);
    }
    public void SetisTime(bool istime)
    {
        isTime = !istime;
    }
    public bool GetisTime()
    {
        return isTime;
    }
    public void SetStarttime1(DateTime start)
    {
        starttime1 = start.ToString("yyyy-MM-ddTHH:mm:ss");
    }
    public DateTime GetStarttime1()
    {
        return DateTime.ParseExact(starttime1, "yyyy-MM-ddTHH:mm:ss", null);
    }
    public void SetCanDaily(bool candaily)
    {
        canDaily = candaily;
    }
    public bool GetCanDaily()
    {
        return canDaily;
    }
    public void SetDailyProcess()
    {
        dailyProcess += 1;
        if (dailyProcess > 7) dailyProcess = 0;
    }
    public int GetDailyProcess()
    {
        return dailyProcess;
    }
    public void SetLevelGame(int level)
    {
        levelGame = level;
    }
    public int GetLevelGame()
    {
        return levelGame;
    }
    public void SetUnlockLevelGame()
    {
        unlockLevelGame += 1;
    }
    public int GetUnlockLevelGame()
    {
        return unlockLevelGame;
    }
    public void SetMusic(float volume)
    {
        music = volume;
    }
    public float GetMusic()
    {
        return music;
    }
    public void SetSound(float volume)
    {
        sound = volume;
    }
    public float GetSound()
    {
        return sound;
    }
}