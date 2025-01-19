using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIShopCastle : MonoBehaviour
{
    public ShopCastleData shopCastleData;
    public Text itemNameText, costText;

    public Text statsNameText1, statsNameText2, statsNameText3;
    public Text statsText1, statsText2, statsText3;
    public Text nextStatsText1, nextStatsText2, nextStatsText3;

    public Button purchaseBtn;
    public Image canPurchase;
    public Image itemTargeted;
    public Button[] selectItemBtns;
    public GameObject arrow;
    public GameObject nextStats;
    public Button openShopCastle;

    private int currentIndex = 0;

    private void Start()
    {
        openShopCastle.onClick.AddListener(delegate { SelectItem(currentIndex); });
        selectItemBtns = GetComponentsInChildren<Button>();
        for (int i = 0; i < selectItemBtns.Length; i++)
        {
            int index = i;
            selectItemBtns[index].onClick.AddListener(() => SelectItem(index));
        }
        costText.text = shopCastleData.shopCastle.unlockCost.ToString();
        SetItemData();
        purchaseBtn.onClick.AddListener(UpgradeButton);
        itemTargeted.sprite = selectItemBtns[currentIndex].transform.GetChild(0).GetComponentInChildren<Image>().sprite;
    }

    private void SetItemData()
    {
        int currentLevel;
        if (currentIndex == 0)
        {
            canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopCastleData.shopCastle.unlockCost, shopCastleData.shopCastle.unlockedLevel));
            shopCastleData.shopCastle.unlockedLevel = DataPlayer.GetLevelCastle();
            currentLevel = shopCastleData.shopCastle.unlockedLevel;
            itemNameText.text = "Castle";
            statsNameText1.text = "Level :";
            statsNameText2.text = "Hp :";
            statsNameText3.text = "Armor :";
            statsText1.text = (currentLevel + 1).ToString();
            statsText2.text = shopCastleData.shopCastle.castleLevel[currentLevel].heathMax.ToString();
            statsText3.text = shopCastleData.shopCastle.castleLevel[currentLevel].armor.ToString();
            currentLevel += 1;
            nextStatsText1.text = (currentLevel + 1).ToString();
            nextStatsText2.text = shopCastleData.shopCastle.castleLevel[currentLevel].heathMax.ToString();
            nextStatsText3.text = shopCastleData.shopCastle.castleLevel[currentLevel].armor.ToString();
            costText.text = shopCastleData.shopCastle.unlockCost.ToString();
        }
        else if(currentIndex == 1)
        {
            canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopCastleData.shopArrows.unlockCost, shopCastleData.shopArrows.unlockedLevel));
            shopCastleData.shopArrows.unlockedLevel = DataPlayer.GetLevelArrows();
            currentLevel = shopCastleData.shopArrows.unlockedLevel;
            itemNameText.text = "Arrows";
            statsNameText1.text = "Level :";
            statsNameText2.text = "Damage :";
            statsNameText3.text = "TimeSkill :";
            statsText1.text = (currentLevel + 1).ToString();
            statsText2.text = shopCastleData.shopArrows.arrowsLevel[currentLevel].damage.ToString();
            statsText3.text = shopCastleData.shopArrows.arrowsLevel[currentLevel].timeSkill.ToString();
            currentLevel += 1;
            nextStatsText1.text = (currentLevel + 1).ToString();
            nextStatsText2.text = shopCastleData.shopArrows.arrowsLevel[currentLevel].damage.ToString();
            nextStatsText3.text = shopCastleData.shopArrows.arrowsLevel[currentLevel].timeSkill.ToString();
            costText.text = shopCastleData.shopArrows.unlockCost.ToString();
        }
        else
        {
            canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopCastleData.shopFood.unlockCost, shopCastleData.shopFood.unlockedLevel));
            shopCastleData.shopFood.unlockedLevel = DataPlayer.GetLevelFood();
            currentLevel = shopCastleData.shopFood.unlockedLevel;
            itemNameText.text = "Food";
            statsNameText1.text = "Level :";
            statsNameText2.text = "Max :";
            statsNameText3.text = "Speed :";
            statsText1.text = (currentLevel + 1).ToString();
            statsText2.text = shopCastleData.shopFood.foodLevel[currentLevel].foodMax.ToString();
            statsText3.text = shopCastleData.shopFood.foodLevel[currentLevel].foodSpeed.ToString() + "/s";
            currentLevel += 1;
            nextStatsText1.text = (currentLevel + 1).ToString();
            nextStatsText2.text = shopCastleData.shopFood.foodLevel[currentLevel].foodMax.ToString();
            nextStatsText3.text = shopCastleData.shopFood.foodLevel[currentLevel].foodSpeed.ToString() + "/s";
            costText.text = shopCastleData.shopFood.unlockCost.ToString();
        }
        if (currentLevel > 4)
        {
            arrow.SetActive(false);
            nextStats.SetActive(false);
            return;
        }
        else
        {
            arrow.SetActive(true);
            nextStats.SetActive(true);
        }
    }
    private void SelectItem(int index)
    {
        SoundManager.Ins.ButtonSound();
        currentIndex = index;
        itemTargeted.sprite = selectItemBtns[index].transform.GetChild(0).GetComponent<Image>().sprite;
        SetItemData();
    }
    private void UpgradeButton()
    {
        SoundManager.Ins.BuyOrUpgrade();
        if (currentIndex == 0)
        {
            DataPlayer.SetLevelCastle();
            shopCastleData.shopCastle.unlockedLevel = DataPlayer.GetLevelCastle();
            DataPlayer.SetCoin(shopCastleData.shopCastle.unlockCost);
            shopCastleData.shopCastle.unlockCost = shopCastleData.shopCastle.unlockCost * 2;
            costText.text = shopCastleData.shopCastle.unlockCost.ToString();
        } 
        else if (currentIndex == 1)
        {
            DataPlayer.SetLevelArrows();
            shopCastleData.shopArrows.unlockedLevel = DataPlayer.GetLevelArrows();
            DataPlayer.SetCoin(shopCastleData.shopArrows.unlockCost);
            shopCastleData.shopArrows.unlockCost = shopCastleData.shopArrows.unlockCost * 2;
            costText.text = shopCastleData.shopArrows.unlockCost.ToString();
        } 
        else
        {
            DataPlayer.SetLevelFood();
            shopCastleData.shopFood.unlockedLevel = DataPlayer.GetLevelFood();
            DataPlayer.SetCoin(shopCastleData.shopFood.unlockCost);
            shopCastleData.shopFood.unlockCost = shopCastleData.shopFood.unlockCost * 2;
            costText.text = shopCastleData.shopFood.unlockCost.ToString();
        }
        SetItemData();
    }
}