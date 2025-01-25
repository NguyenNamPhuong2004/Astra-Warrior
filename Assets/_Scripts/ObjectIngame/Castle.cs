using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public ShopCastleData castleData;
    [SerializeField] private int level;
    public int maxHealth;
    public int curHealth;
    public int armor;
    [SerializeField] private Text heathText;
    [SerializeField] private Image heathBar;

    private void Awake()
    {
        if(gameObject.layer == 8) SetData();
        curHealth = maxHealth;
    }
    private void SetData()
    {
        level = DataPlayer.GetLevelCastle();
        maxHealth = castleData.shopCastle.castleLevel[level].maxHp;
        armor = castleData.shopCastle.castleLevel[level].armor;
    }
    private void Update()
    {
        heathText.text = curHealth.ToString() + " / " + maxHealth.ToString();
        heathBar.fillAmount = (float) curHealth / maxHealth;
    }
    public bool isDead()
    {
        return curHealth <= 0;
    }
    public void SetHealth(int damage)
    {
        curHealth -= Mathf.CeilToInt(damage / (1 + armor / 100f));
    }
}
