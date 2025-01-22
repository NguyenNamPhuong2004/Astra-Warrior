using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class UIShopHero : LoadUIShopHero
{
    private void Start()
    {
        AddListenerSelectBtns();
        AddListenerPurchaseBtn();
        SelectHero(0);
    }
    private void AddListenerSelectBtns()
    {
        for (int i = 0; i < selectHeroBtns.Length; i++)
        {
            int index = i;
            selectHeroBtns[index].onClick.AddListener(() => SelectHero(index));
        }
    }
    private void AddListenerPurchaseBtn()
    {
        purchaseBtn.onClick.AddListener(UpgradeButton);
    }
    private void SelectHero(int index)
    {
        SoundManager.Ins.ButtonSound();
        currentHeroIndex = index;
        currentHeroLevel = allHeroData.heroData[currentHeroIndex].unlockedLevel;
        heroTargeted.sprite = selectHeroGraphics[currentHeroIndex].sprite;
        cost = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].unlockCost;
        allHeroData.heroData[currentHeroIndex].unlockedLevel = DataPlayer.GetLevelHero(currentHeroIndex);
        UpdateView();
    }
    private void UpgradeButton()
    {
        currentHeroLevel = allHeroData.heroData[currentHeroIndex].unlockedLevel;
        SoundManager.Ins.BuyOrUpgrade();
        if (purchaseBtnText.text == "BUY")
        {
            DataPlayer.AddHero(currentHeroIndex);
            allHeroData.heroData[currentHeroIndex].isUnlocked = true;
        }
        else
        {
            DataPlayer.SetLevelHero(currentHeroIndex);
            allHeroData.heroData[currentHeroIndex].unlockedLevel = DataPlayer.GetLevelHero(currentHeroIndex);
        }
        DataPlayer.SetCoin(allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].unlockCost);
        cost = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].unlockCost;
        UpdateView();
    }
    private void UpdateView()
    {
        UpdateHeroStatsView();
        UpdateOtherView();
    }
    private void UpdateHeroStatsView()
    {
        levelText.text = (currentHeroLevel + 1).ToString();
        damageText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].damage.ToString();
        maxHpText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].maxHp.ToString();
        armorText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].armor.ToString();
        currentHeroLevel = allHeroData.heroData[currentHeroIndex].unlockedLevel + 1;
        if (currentHeroLevel > 4 || DataPlayer.IsUnlocked(currentHeroIndex) == false)
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
        nextLevelText.text = (currentHeroLevel + 1).ToString();
        nextDamageText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].damage.ToString();
        nextMaxHpText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].maxHp.ToString();
        nextArmorText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].armor.ToString();
    }
    private void UpdateOtherView()
    {
        canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].unlockCost, allHeroData.heroData[currentHeroIndex].unlockedLevel));
        purchaseBtnText.text = DataPlayer.IsUnlocked(currentHeroIndex) ? "UPGRADE" : "BUY";
        heroNameText.text = allHeroData.heroData[currentHeroIndex].heroName;
        costText.text = allHeroData.heroData[currentHeroIndex].heroLevel[currentHeroLevel].unlockCost.ToString();
    }
}
