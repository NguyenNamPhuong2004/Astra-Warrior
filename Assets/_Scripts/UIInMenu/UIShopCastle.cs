using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIShopCastle : LoadUIShopCastle
{
    private void Start()
    {      
        for (int i = 0; i < selectItemBtns.Length; i++)
        {
            int index = i;
            selectItemBtns[index].onClick.AddListener(() => SelectItem(index));
        }
        costText.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].unlockCost.ToString();
        SetItemData();
        purchaseBtn.onClick.AddListener(UpgradeButton);
        itemTargeted.sprite = selectItemGraphics[currentItemIndex].sprite;
    }

    private void SetItemData()
    {
        if (currentItemIndex == 0)
        {
            canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopCastleData.shopCastle.castleLevel[currentItemLevel].unlockCost, shopCastleData.shopCastle.unlockedLevel));
            shopCastleData.shopCastle.unlockedLevel = DataPlayer.GetLevelCastle();
            currentItemLevel = shopCastleData.shopCastle.unlockedLevel;
            itemNameText.text = "Castle";
            statNameText1.text = "Level :";
            statNameText2.text = "Hp :";
            statNameText3.text = "Armor :";
            statText1.text = (currentItemLevel + 1).ToString();
            statText2.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].maxHp.ToString();
            statText3.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].armor.ToString();
            currentItemLevel += 1;
            nextStatText1.text = (currentItemLevel + 1).ToString();
            nextStatText2.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].maxHp.ToString();
            nextStatText3.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].armor.ToString();
            costText.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].unlockCost.ToString();
        }
        else if(currentItemIndex == 1)
        {
            canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopCastleData.shopArrows.arrowsLevel[currentItemLevel].unlockCost, shopCastleData.shopArrows.unlockedLevel));
            shopCastleData.shopArrows.unlockedLevel = DataPlayer.GetLevelArrows();
            currentItemLevel = shopCastleData.shopArrows.unlockedLevel;
            itemNameText.text = "Arrows";
            statNameText1.text = "Level :";
            statNameText2.text = "Damage :";
            statNameText3.text = "Skill Time :";
            statText1.text = (currentItemLevel + 1).ToString();
            statText2.text = shopCastleData.shopArrows.arrowsLevel[currentItemLevel].damage.ToString();
            statText3.text = shopCastleData.shopArrows.arrowsLevel[currentItemLevel].timeSkill.ToString();
            currentItemLevel += 1;
            nextStatText1.text = (currentItemLevel + 1).ToString();
            nextStatText2.text = shopCastleData.shopArrows.arrowsLevel[currentItemLevel].damage.ToString();
            nextStatText3.text = shopCastleData.shopArrows.arrowsLevel[currentItemLevel].timeSkill.ToString();
            costText.text = shopCastleData.shopArrows.arrowsLevel[currentItemLevel].unlockCost.ToString();
        }
        else
        {
            canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopCastleData.shopFood.foodLevel[currentItemLevel].unlockCost, shopCastleData.shopFood.unlockedLevel));
            shopCastleData.shopFood.unlockedLevel = DataPlayer.GetLevelFood();
            currentItemLevel = shopCastleData.shopFood.unlockedLevel;
            itemNameText.text = "Food";
            statNameText1.text = "Level :";
            statNameText2.text = "Max :";
            statNameText3.text = "Speed :";
            statText1.text = (currentItemLevel + 1).ToString();
            statText2.text = shopCastleData.shopFood.foodLevel[currentItemLevel].foodMax.ToString();
            statText3.text = shopCastleData.shopFood.foodLevel[currentItemLevel].foodSpeed.ToString() + "/s";
            currentItemLevel += 1;
            nextStatText1.text = (currentItemLevel + 1).ToString();
            nextStatText2.text = shopCastleData.shopFood.foodLevel[currentItemLevel].foodMax.ToString();
            nextStatText3.text = shopCastleData.shopFood.foodLevel[currentItemLevel].foodSpeed.ToString() + "/s";
            costText.text = shopCastleData.shopFood.foodLevel[currentItemLevel].unlockCost.ToString();
        }
        if (currentItemLevel > 4)
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
        currentItemIndex = index;
        itemTargeted.sprite = selectItemGraphics[currentItemIndex].sprite;
        SetItemData();
    }
    private void UpgradeButton()
    {
        SoundManager.Ins.BuyOrUpgrade();
        if (currentItemIndex == 0)
        {
            DataPlayer.SetLevelCastle();
            shopCastleData.shopCastle.unlockedLevel = DataPlayer.GetLevelCastle();
            DataPlayer.SetCoin(shopCastleData.shopCastle.castleLevel[currentItemLevel].unlockCost);
            costText.text = shopCastleData.shopCastle.castleLevel[currentItemLevel].unlockCost.ToString();
        } 
        else if (currentItemIndex == 1)
        {
            DataPlayer.SetLevelArrows();
            shopCastleData.shopArrows.unlockedLevel = DataPlayer.GetLevelArrows();
            DataPlayer.SetCoin(shopCastleData.shopArrows.arrowsLevel[currentItemLevel].unlockCost);
            costText.text = shopCastleData.shopArrows.arrowsLevel[currentItemLevel].unlockCost.ToString();
        } 
        else
        {
            DataPlayer.SetLevelFood();
            shopCastleData.shopFood.unlockedLevel = DataPlayer.GetLevelFood();
            DataPlayer.SetCoin(shopCastleData.shopFood.foodLevel[currentItemLevel].unlockCost);
            costText.text = shopCastleData.shopFood.foodLevel[currentItemLevel].unlockCost.ToString();
        }
        SetItemData();
    }
}