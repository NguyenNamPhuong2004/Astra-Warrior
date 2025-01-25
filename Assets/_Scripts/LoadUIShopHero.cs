using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUIShopHero : LoadData
{
    [SerializeField] protected AllHeroData allHeroData;
    [SerializeField] protected Text purchaseBtnText, heroNameText, costText;
    [SerializeField] protected Text levelText, damageText, maxHpText, armorText; 
    [SerializeField] protected Text nextLevelText, nextDamageText, nextMaxHpText, nextArmorText;
    [SerializeField] protected Button purchaseBtn;
    [SerializeField] protected Button[] selectHeroBtns;
    [SerializeField] protected Image[] selectHeroGraphics;
    [SerializeField] protected Image canPurchase;
    [SerializeField] protected Image heroTargeted;
    [SerializeField] protected GameObject arrow;
    [SerializeField] protected GameObject nextStats;

    [SerializeField] protected int currentHeroIndex;
    [SerializeField] protected int currentHeroLevel;
    [SerializeField] protected int cost;

    protected override void LoadComponents()
    {
        base.LoadComponents();    
        LoadAllHeroData();
        LoadArmorText();
        LoadArrow();
        LoadCanPurchase();
        LoadCostText();
        LoadDamageText();
        LoadHeroNameText();
        LoadHeroTargeted();
        LoadLevelText();
        LoadMaxHpText();
        LoadNextArmorText();
        LoadNextDamageText();
        LoadNextLevelText();
        LoadNextMaxHpText();
        LoadNextStats();
        LoadPurchaseBtn();
        LoadPurchaseBtnText();
        LoadSelectHeroBtns();
        LoadSelectHeroGraphics();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        currentHeroIndex = 0;
        currentHeroLevel = allHeroData.heroData[currentHeroIndex].unlockedLevel;
        cost = 0;
    }
    protected virtual void LoadAllHeroData()
    {
        if (this.allHeroData != null) return;
        this.allHeroData = Resources.Load<AllHeroData>("Prefabs/Hero Data");
        Debug.Log(transform.name + ": allHeroData ", gameObject);
    }
    protected virtual void LoadSelectHeroBtns()
    {
        if (this.selectHeroBtns != null && this.selectHeroBtns.Length > 0) return;
        this.selectHeroBtns = transform.Find("HeroElementBtns").GetComponentsInChildren<Button>();
        Debug.Log(transform.name + ": SelectHeroBtns", gameObject);
    }
    protected virtual void LoadSelectHeroGraphics()
    {
        if (this.selectHeroGraphics != null && this.selectHeroGraphics.Length > 0) return;
        this.selectHeroGraphics = transform.Find("HeroElementGraphics").GetComponentsInChildren<Image>();
        Debug.Log(transform.name + ": SelectHeroGraphics", gameObject);
    }
    protected virtual void LoadPurchaseBtn()
    {
        if (this.purchaseBtn != null) return;
        this.purchaseBtn = transform.Find("Purchase").Find("PurchaseBtn").GetComponent<Button>();
        Debug.Log(transform.name + ": PurchaseBtn", gameObject);
    }
    protected virtual void LoadPurchaseBtnText()
    {
        if (this.purchaseBtnText != null) return;
        this.purchaseBtnText = transform.Find("Purchase").Find("PurchaseBtn").Find("PurchaseBtnText").GetComponent<Text>();
        Debug.Log(transform.name + ": PurchaseBtnText", gameObject);
    }
    protected virtual void LoadCanPurchase()
    {
        if (this.canPurchase != null) return;
        this.canPurchase = transform.Find("Purchase").Find("NoBuy").GetComponent<Image>();
        Debug.Log(transform.name + ": canPurchase", gameObject);
    }
    protected virtual void LoadHeroNameText()
    {
        if (this.heroNameText != null) return;
        this.heroNameText = transform.Find("HeroTargeted").Find("HeroTargetedName").GetComponent<Text>();
        Debug.Log(transform.name + ": heroNameText", gameObject);
    } 
    protected virtual void LoadHeroTargeted()
    {
        if (this.heroTargeted != null) return;
        this.heroTargeted = transform.Find("HeroTargeted").Find("HeroTargetedGraphic").GetComponent<Image>();
        Debug.Log(transform.name + ": heroTargeted", gameObject);
    }
    protected virtual void LoadCostText()
    {
        if (this.costText != null) return;
        this.costText = transform.Find("Purchase").Find("Cost").Find("CostText").GetComponent<Text>();
        Debug.Log(transform.name + ": costText", gameObject);
    }
    protected virtual void LoadLevelText()
    {
        if (this.levelText != null) return;
        this.levelText = transform.Find("Stats").Find("CurStats").Find("Level").GetComponent<Text>();
        Debug.Log(transform.name + ": levelText", gameObject);
    }
    protected virtual void LoadDamageText()
    {
        if (this.damageText != null) return;
        this.damageText = transform.Find("Stats").Find("CurStats").Find("Damage").GetComponent<Text>();
        Debug.Log(transform.name + ": damageText", gameObject);
    }
    protected virtual void LoadMaxHpText()
    {
        if (this.maxHpText != null) return;
        this.maxHpText = transform.Find("Stats").Find("CurStats").Find("Hp").GetComponent<Text>();
        Debug.Log(transform.name + ": maxHpText", gameObject);
    } 
    protected virtual void LoadArmorText()
    {
        if (this.armorText != null) return;
        this.armorText = transform.Find("Stats").Find("CurStats").Find("Armor").GetComponent<Text>();
        Debug.Log(transform.name + ": armorText", gameObject);
    }
    protected virtual void LoadNextLevelText()
    {
        if (this.nextLevelText != null) return;
        this.nextLevelText = transform.Find("Stats").Find("NextStats").Find("Level").GetComponent<Text>();
        Debug.Log(transform.name + ": nextLevelText", gameObject);
    }
    protected virtual void LoadNextDamageText()
    {
        if (this.nextDamageText != null) return;
        this.nextDamageText = transform.Find("Stats").Find("NextStats").Find("Damage").GetComponent<Text>();
        Debug.Log(transform.name + ": nextDamageText", gameObject);
    }
    protected virtual void LoadNextMaxHpText()
    {
        if (this.nextMaxHpText != null) return;
        this.nextMaxHpText = transform.Find("Stats").Find("NextStats").Find("Hp").GetComponent<Text>();
        Debug.Log(transform.name + ": nextMaxHpText", gameObject);
    }
    protected virtual void LoadNextArmorText()
    {
        if (this.nextArmorText != null) return;
        this.nextArmorText = transform.Find("Stats").Find("NextStats").Find("Armor").GetComponent<Text>();
        Debug.Log(transform.name + ": armorText", gameObject);
    }  
    protected virtual void LoadArrow()
    {
        if (this.arrow != null) return;
        this.arrow = transform.Find("Stats").Find("Arrow").gameObject;
        Debug.Log(transform.name + ": arrow", gameObject);
    }
    protected virtual void LoadNextStats()
    {
        if (this.nextStats != null) return;
        this.nextStats = transform.Find("Stats").Find("NextStats").gameObject;
        Debug.Log(transform.name + ": nextStats", gameObject);
    }
}
