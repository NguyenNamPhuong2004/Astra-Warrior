using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeroSpawn : LoadData
{
    public int id;
    [SerializeField] private int cost;
    [SerializeField] private Text costTxt;
    [SerializeField] private Button purchaseBtn;

    [SerializeField] private int spawnTime;
    private float curSpawnTime;

    [SerializeField] private Image spawnTimeBar;
    [SerializeField] private Image heroGraphic;
    [SerializeField] private Food food;

    [SerializeField] private HeroSpawning heroSpawning;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCostTxt();
        LoadPurchaseBtn();
        LoadSpawnTimeBar();
        LoadHeroGraphic();
        LoadFood();
        LoadHeroSpawning();
    }
    private void LoadCostTxt()
    {
        if (this.costTxt != null) return;
        this.costTxt = transform.Find("Cost").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadCostTxt ", gameObject);
    }
    private void LoadPurchaseBtn()
    {
        if (this.purchaseBtn != null) return;
        this.purchaseBtn = GetComponent<Button>();
        Debug.Log(transform.name + ": LoadPurchaseBtn ", gameObject);
    } 
    private void LoadSpawnTimeBar()
    {
        if (this.spawnTimeBar != null) return;
        this.spawnTimeBar = transform.Find("SpawnTimeBar").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadSpawnTimeBar ", gameObject);
    }
    private void LoadHeroGraphic()
    {
        if (this.heroGraphic != null) return;
        this.heroGraphic = GetComponent<Image>();
        Debug.Log(transform.name + ": LoadHeroGraphic ", gameObject);
    }
    private void LoadFood()
    {
        if (this.food != null) return;
        this.food = GameObject.Find("Food").GetComponent<Food>();
        Debug.Log(transform.name + ": LoadFood ", gameObject);
    } 

    private void LoadHeroSpawning()
    {
        if (this.heroSpawning != null) return;
        this.heroSpawning = GameObject.FindObjectOfType<HeroSpawning>();
        Debug.Log(transform.name + ": LoadHeroSpawning ", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        purchaseBtn.onClick.AddListener(OnSpawnHero);
        spawnTime = 7 - id;
        curSpawnTime = spawnTime;
        costTxt.text = cost.ToString();
        SetCost();
    }
    private void SetCost()
    {
        switch (id)
        {
            case 0: 
                cost = 30;
                break;
            case 1:
                cost = 65;
                break;
            case 2:
                cost = 115;
                break;
            case 3:
                cost = 160;
                break;
        }
    }
    private void Update()
    {
        if (cost > food.CurrentFood || curSpawnTime < spawnTime)
        {
            purchaseBtn.interactable = false;
        }
        else purchaseBtn.interactable = true;
    }
    public void SetID(int id)
    {
        this.id = id;
    }

    private void OnSpawnHero()
    {
        heroSpawning.Spawning(heroSpawning.transform.position, id);
        StartCoroutine(SpawnTime());
        food.CurrentFood -= cost;
    }

    private IEnumerator SpawnTime()
    {
        heroGraphic.color = new Color(0.2f, 0.2f, 0.2f, 1);
        curSpawnTime = 0;
        while (curSpawnTime < spawnTime)
        {
            curSpawnTime += Time.deltaTime;
            spawnTimeBar.fillAmount = curSpawnTime / spawnTime;
            yield return new WaitForSeconds(1/120);
        }
        heroGraphic.color = new Color(0.4f, 0.4f, 0.4f, 1);
    }
}
