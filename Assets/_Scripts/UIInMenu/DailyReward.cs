using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailyReward : MonoBehaviour
{
    public GameObject addCoinText;
    public GameObject canvas;
    int addCoin;
    public GameObject TimeDaily;
    public GameObject DailyoffBtn;
    DateTime StartTime;
    DateTime EndTime;
    bool isTime;
    TimeSpan timeleft;
    public Transform AddCoinTextSpawnPosition;
    private void Awake()
    {
        EndTime = DataPlayer.GetEndtime();
        DateTime start = DateTime.Now;
        timeleft = EndTime - start;  
        if (DataPlayer.GetisTime() == true)
        {
            TimeDaily.SetActive(true);
            DailyoffBtn.SetActive(true);
            int second = Mathf.FloorToInt((float)(timeleft.TotalSeconds)) % 60;
            int minute = Mathf.FloorToInt((float)(timeleft.TotalMinutes)) % 60;
            int hour = Mathf.FloorToInt((float)(timeleft.TotalHours));
            TimeDaily.GetComponent<Text>().text = string.Format("Return back: {0:00}:{1:00}:{2:00}", hour, minute, second);
        }
        else
        {
            TimeDaily.SetActive(false);
            DailyoffBtn.SetActive(false);
            DataPlayer.SetCanDaily(true);
        }
    }
    private void FixedUpdate()
    {
        if (DataPlayer.GetisTime() == true)
        {
            DateTime start = DateTime.Now;
            EndTime = DataPlayer.GetEndtime();
            timeleft = EndTime - start;
            if (timeleft.TotalSeconds < 0)
            {
                TimeDaily.SetActive(false);
                DailyoffBtn.SetActive(false);
                DataPlayer.SetisTime(isTime);
                DataPlayer.SetCanDaily(true);
            }
            else
            {
                int second = Mathf.FloorToInt((float)(timeleft.TotalSeconds)) % 60;
                int minute = Mathf.FloorToInt((float)(timeleft.TotalMinutes)) % 60;
                int hour = Mathf.FloorToInt((float)(timeleft.TotalHours));
                TimeDaily.GetComponent<Text>().text = string.Format("Return back : {0:00}:{1:00}:{2:00}", hour, minute, second);

            }
        }
    }
   
    public void ReceiveDailyReward()
    {
        HandleTimeDaily();
        HandleAddCoin();
    }
    private void HandleTimeDaily()
    {
        StartTime = DateTime.Now;
        EndTime = StartTime.AddHours(24);
        DataPlayer.SetEndtime(EndTime);
        DataPlayer.SetisTime(isTime);
        TimeDaily.SetActive(true);
        DailyoffBtn.SetActive(true);
        DataPlayer.SetCanDaily(false);
    }
    private void HandleAddCoin()
    {
        addCoin = UnityEngine.Random.Range(100, 120);
        addCoinText.GetComponentInChildren<Text>().text = " + " + addCoin;
        DataPlayer.AddCoin(addCoin);
        GameObject addcoinPrefab = Instantiate(addCoinText, AddCoinTextSpawnPosition);
        addcoinPrefab.transform.SetParent(canvas.transform);
        SoundManager.Ins.BuyOrUpgrade();
    }
}