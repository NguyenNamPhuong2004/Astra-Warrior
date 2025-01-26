using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public ShopCastleData foodData;
    private int level;
    private int currentFood;
    private int maxFood;
    private float updateSpeed;
    private float curUpdateSpeed;

    public int CurrentFood { get => currentFood; set => currentFood = value; }
    public int MaxFood { get => maxFood; private set => maxFood = value; }

    private void Awake()
    {
        CurrentFood = 0;
        SetData();
    }
    private void SetData()
    {
        level = DataPlayer.GetLevelFood();
        MaxFood = foodData.shopFood.foodLevel[level].foodMax;
        updateSpeed = foodData.shopFood.foodLevel[level].foodSpeed;
    }
    private void FixedUpdate()
    {
        UpdateFood();
    }
    private void UpdateFood()
    {
        if (CurrentFood >= MaxFood) return;
        if (curUpdateSpeed <= 0)
        {
            curUpdateSpeed = updateSpeed;
            CurrentFood += 1;
        }
        else
        {
            curUpdateSpeed -= updateSpeed / 25;
        }
    }
}
