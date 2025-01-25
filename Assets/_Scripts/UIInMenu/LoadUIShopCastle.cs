using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUIShopCastle : LoadData
{
    [SerializeField] protected ShopCastleData shopCastleData;
    [SerializeField] protected Text itemNameText, costText;

    [SerializeField] protected Text statNameText1, statNameText2, statNameText3;
    [SerializeField] protected Text statText1, statText2, statText3;
    [SerializeField] protected Text nextStatText1, nextStatText2, nextStatText3;

    [SerializeField] protected Button purchaseBtn;
    [SerializeField] protected Image canPurchase;
    [SerializeField] protected Image itemTargeted;
    [SerializeField] protected Button[] selectItemBtns;
    [SerializeField] protected Image[] selectItemGraphics;
    [SerializeField] protected GameObject arrow;
    [SerializeField] protected GameObject nextStats;

    [SerializeField] protected int currentItemIndex;
    [SerializeField] protected int currentItemLevel;
    [SerializeField] protected int cost;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadArrow();
        LoadCanPurchase();
        LoadCostText();
        LoadItemNameText();
        LoadItemTargeted();
        LoadNextStats();
        LoadNextStatText1();
        LoadNextStatText2();
        LoadNextStatText3();
        LoadPurchaseBtn();
        LoadSelectHeroGraphics();
        LoadSelectItemBtns();
        LoadShopCastleData();
        LoadStatNameText1();
        LoadStatNameText2();
        LoadStatNameText3();
        LoadStatText1();
        LoadStatText2();
        LoadStatText3();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        currentItemIndex = 0;
        cost = 0;
        currentItemLevel = shopCastleData.shopCastle.unlockedLevel;
    }

    protected virtual void LoadShopCastleData()
    {
        if (this.shopCastleData != null) return;
        this.shopCastleData = Resources.Load<ShopCastleData>("Prefabs/Castle Data");
        Debug.Log(transform.name + ": Castle Data", gameObject);
    }
    protected virtual void LoadSelectItemBtns()
    {
        if (this.selectItemBtns != null && this.selectItemBtns.Length > 0) return;
        this.selectItemBtns = transform.Find("CastleElementBtns").GetComponentsInChildren<Button>();
        Debug.Log(transform.name + ": SelectItemBtns", gameObject);
    }
    protected virtual void LoadSelectHeroGraphics()
    {
        if (this.selectItemGraphics != null && this.selectItemGraphics.Length > 0) return;
        this.selectItemGraphics = transform.Find("CastleElementGraphics").GetComponentsInChildren<Image>();
        Debug.Log(transform.name + ": SelectItemGraphics", gameObject);
    }
    protected virtual void LoadPurchaseBtn()
    {
        if (this.purchaseBtn != null) return;
        this.purchaseBtn = transform.Find("Purchase").Find("PurchaseBtn").GetComponent<Button>();
        Debug.Log(transform.name + ": PurchaseBtn", gameObject);
    }
    protected virtual void LoadCanPurchase()
    {
        if (this.canPurchase != null) return;
        this.canPurchase = transform.Find("Purchase").Find("NoBuy").GetComponent<Image>();
        Debug.Log(transform.name + ": canPurchase", gameObject);
    }
    protected virtual void LoadItemNameText()
    {
        if (this.itemNameText != null) return;
        this.itemNameText = transform.Find("ItemTargeted").Find("ItemTargetedName").GetComponent<Text>();
        Debug.Log(transform.name + ": ItemNameText", gameObject);
    }
    protected virtual void LoadItemTargeted()
    {
        if (this.itemTargeted != null) return;
        this.itemTargeted = transform.Find("ItemTargeted").Find("ItemTargetedGraphic").GetComponent<Image>();
        Debug.Log(transform.name + ": ItemTargeted", gameObject);
    }
    protected virtual void LoadCostText()
    {
        if (this.costText != null) return;
        this.costText = transform.Find("Purchase").Find("Cost").Find("CostText").GetComponent<Text>();
        Debug.Log(transform.name + ": costText", gameObject);
    }
    protected virtual void LoadStatNameText1()
    {
        if (this.statNameText1 != null) return;
        this.statNameText1 = transform.Find("Stats").Find("NameText").Find("1").GetComponent<Text>();
        Debug.Log(transform.name + ": statNameText1", gameObject);
    } 
    protected virtual void LoadStatNameText2()
    {
        if (this.statNameText2 != null) return;
        this.statNameText2 = transform.Find("Stats").Find("NameText").Find("2").GetComponent<Text>();
        Debug.Log(transform.name + ": statNameText2", gameObject);
    } 
    protected virtual void LoadStatNameText3()
    {
        if (this.statNameText3 != null) return;
        this.statNameText3 = transform.Find("Stats").Find("NameText").Find("3").GetComponent<Text>();
        Debug.Log(transform.name + ": statNameText3", gameObject);
    }
    protected virtual void LoadStatText1()
    {
        if (this.statText1 != null) return;
        this.statText1 = transform.Find("Stats").Find("CurStats").Find("1").GetComponent<Text>();
        Debug.Log(transform.name + ": StatsText1", gameObject);
    } 
    protected virtual void LoadStatText2()
    {
        if (this.statText2 != null) return;
        this.statText2 = transform.Find("Stats").Find("CurStats").Find("2").GetComponent<Text>();
        Debug.Log(transform.name + ": StatsText2", gameObject);
    }
    protected virtual void LoadStatText3()
    {
        if (this.statText3 != null) return;
        this.statText3 = transform.Find("Stats").Find("CurStats").Find("3").GetComponent<Text>();
        Debug.Log(transform.name + ": StatsText3", gameObject);
    }
    protected virtual void LoadNextStatText1()
    {
        if (this.nextStatText1 != null) return;
        this.nextStatText1 = transform.Find("Stats").Find("NextStats").Find("1").GetComponent<Text>();
        Debug.Log(transform.name + ": NextStatText1", gameObject);
    } 
    protected virtual void LoadNextStatText2()
    {
        if (this.nextStatText2 != null) return;
        this.nextStatText2 = transform.Find("Stats").Find("NextStats").Find("2").GetComponent<Text>();
        Debug.Log(transform.name + ": NextStatText2", gameObject);
    } 
    protected virtual void LoadNextStatText3()
    {
        if (this.nextStatText3 != null) return;
        this.nextStatText3 = transform.Find("Stats").Find("NextStats").Find("3").GetComponent<Text>();
        Debug.Log(transform.name + ": NextStatText3", gameObject);
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
