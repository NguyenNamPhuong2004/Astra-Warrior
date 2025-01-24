using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroInGameBtn : MonoBehaviour
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
    [SerializeField] private Vector3 spawnHeroPosition;
    private void Awake()
    {
        purchaseBtn = GetComponent<Button>();
        purchaseBtn.onClick.AddListener(OnSpawnHero);
        costTxt.text = cost.ToString();
        curSpawnTime = spawnTime;
    }
    private void Update()
    {
        if (cost > food.food || curSpawnTime < spawnTime)
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
        heroSpawning.Spawning(spawnHeroPosition, id);
        StartCoroutine(SpawnTime());
        food.food -= cost;
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
