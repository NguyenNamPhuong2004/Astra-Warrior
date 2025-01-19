using UnityEngine;
using UnityEngine.UI;


public class UIShopHero : MonoBehaviour
{
    [SerializeField] private Coin totalCoins;

    public GameObject[] heroList;
    public ShopHeroData shopHeroData;
    public Text purchaseBtnText, levelText, nextLevelText, heroNameText;
    public Text damageText, maxHealthText, armorText, totalCoinsText, costText;
    public Text nextDamageText, nextMaxHealthText, nextArmorText;
    public Button purchaseBtn;
    public Image canPurchase;
    public Image heroTargeted;
    public Button[] selectHeroBtns;
    public GameObject arrow;
    public GameObject nextStats;
    public Button openShopHero;

    private int currentIndex = 0;
    private int cost = 0;

    private void Start()
    {
        openShopHero.onClick.AddListener(delegate { SelectHero(currentIndex); });
        selectHeroBtns = GetComponentsInChildren<Button>();
        for (int i = 0; i < selectHeroBtns.Length; i++)
        {
            int index = i;
            selectHeroBtns[index].onClick.AddListener(() => SelectHero(index));
        }
        totalCoinsText.text = totalCoins.ToString();
        cost = shopHeroData.shopHero[currentIndex].unlockCost;
        shopHeroData.shopHero[currentIndex].unlockCost = cost * (int)Mathf.Pow(2, DataPlayer.GetLevelHero(currentIndex));
        costText.text = shopHeroData.shopHero[currentIndex].unlockCost.ToString();
        SetHeroData();
        purchaseBtn.onClick.AddListener(UpgradeButton);
        heroTargeted.sprite = heroList[currentIndex].GetComponent<SpriteRenderer>().sprite;
    }

    private void SetHeroData()
    {
        canPurchase.gameObject.SetActive(!DataPlayer.IsCanPurchase(shopHeroData.shopHero[currentIndex].unlockCost, shopHeroData.shopHero[currentIndex].unlockedLevel));
        purchaseBtnText.text = DataPlayer.IsUnlocked(currentIndex) ? "UPGRADE" : "BUY";
        costText.text = shopHeroData.shopHero[currentIndex].unlockCost.ToString();
        heroNameText.text = shopHeroData.shopHero[currentIndex].heroName;
        shopHeroData.shopHero[currentIndex].unlockedLevel = DataPlayer.GetLevelHero(currentIndex);
        costText.text = shopHeroData.shopHero[currentIndex].unlockCost.ToString();
        UpdateView();
    }
    private void UpdateView()
    {
        int currentLevel = shopHeroData.shopHero[currentIndex].unlockedLevel;
        levelText.text = (currentLevel + 1).ToString();
        damageText.text = shopHeroData.shopHero[currentIndex].heroLevel[currentLevel].damage.ToString();
        maxHealthText.text = shopHeroData.shopHero[currentIndex].heroLevel[currentLevel].maxHealth.ToString();
        armorText.text = shopHeroData.shopHero[currentIndex].heroLevel[currentLevel].armor.ToString();
            currentLevel = shopHeroData.shopHero[currentIndex].unlockedLevel + 1;
        if (currentLevel > 4 || DataPlayer.IsUnlocked(currentIndex) == false)
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
        nextLevelText.text = (currentLevel + 1).ToString();
        nextDamageText.text = shopHeroData.shopHero[currentIndex].heroLevel[currentLevel].damage.ToString();
        nextMaxHealthText.text = shopHeroData.shopHero[currentIndex].heroLevel[currentLevel].maxHealth.ToString();
        nextArmorText.text = shopHeroData.shopHero[currentIndex].heroLevel[currentLevel].armor.ToString();
    }
    private void SelectHero(int index)
    {
        SoundManager.Ins.ButtonSound();
        currentIndex = index;
        heroTargeted.sprite = heroList[currentIndex].GetComponent<SpriteRenderer>().sprite;
        cost = shopHeroData.shopHero[currentIndex].unlockCost;
        SetHeroData();
    }
    private void UpgradeButton()
    {
        SoundManager.Ins.BuyOrUpgrade();
        if (purchaseBtnText.text == "BUY")
        {
            DataPlayer.AddHero(currentIndex);
            shopHeroData.shopHero[currentIndex].isUnlocked = true;
        }
        else
        {
            DataPlayer.SetLevelHero(currentIndex);
            shopHeroData.shopHero[currentIndex].unlockedLevel = DataPlayer.GetLevelHero(currentIndex);
        }
        DataPlayer.SetCoin(shopHeroData.shopHero[currentIndex].unlockCost);
        shopHeroData.shopHero[currentIndex].unlockCost = cost * (int)Mathf.Pow(2, DataPlayer.GetLevelHero(currentIndex));
        costText.text = shopHeroData.shopHero[currentIndex].unlockCost.ToString();
        SetHeroData();
    }
}
