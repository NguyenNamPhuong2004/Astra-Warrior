using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardProcess : MonoBehaviour
{
    public GameObject addCoinText;
    public GameObject canvas;
    int addCoin;
    public Image dailyRewardProcess;
    public Button collectCoin;
    public Transform AddCoinTextSpawnPosition;
    public float value;
    private void Awake()
    {
        value = DataPlayer.GetDailyProcess();
        dailyRewardProcess.fillAmount = value / 7;
    }
    public void Setvalue()
    {
        DataPlayer.SetDailyProcess();
        StartCoroutine(FillAnim());
    }
    private IEnumerator FillAnim()
    {      
        float curValue = 0;     
        while (curValue < 1)
        {
            float time = Time.deltaTime;
            value += time;
            curValue += time;
            dailyRewardProcess.fillAmount = value / 7;
            yield return new WaitForSeconds(1 / 60);
            if (value >= 7)
            {
                collectCoin.interactable = true;
            }
        }
    }
    public void CollectReward()
    {
        SoundManager.Ins.BuyOrUpgrade();
        addCoin = Random.Range(340, 360);
        addCoinText.GetComponentInChildren<Text>().text = " + " + addCoin;
        DataPlayer.AddCoin(addCoin);
        GameObject addcoinPrefab = Instantiate(addCoinText, AddCoinTextSpawnPosition);
        addcoinPrefab.transform.SetParent(canvas.transform);
        collectCoin.interactable = false;
        DataPlayer.SetDailyProcess();
        value = 0;
        dailyRewardProcess.fillAmount = 0;
    }

}
