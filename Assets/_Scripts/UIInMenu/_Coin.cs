using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int coin;
    [SerializeField] private Text coinText;
    private void Update()
    {
        coin = DataPlayer.GetCoin();
        coinText.text = coin.ToString();
    }
}
