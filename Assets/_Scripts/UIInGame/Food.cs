using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public ShopCastleData foodData;
    [SerializeField] private Text foodText;
    int level;
    public int food;
    [SerializeField] private int maxFood;
    [SerializeField] private float updateSpeed;
    private float curUpdateSpeed;

    private void Awake()
    {
        food = 0;
        SetData();
    }
    private void SetData()
    {
        level = DataPlayer.GetLevelFood();
        maxFood = foodData.shopFood.foodLevel[level].foodMax;
        updateSpeed = foodData.shopFood.foodLevel[level].foodSpeed;
    }
    private void FixedUpdate()
    {
        UpdateFood();
    }
    private void UpdateFood()
    {
        if (food >= maxFood) return;
        if (curUpdateSpeed <= 0)
        {
            curUpdateSpeed = updateSpeed;
            food += 1;
            foodText.text = food.ToString() + " / " + maxFood.ToString();
        }
        else
        {
            curUpdateSpeed -= updateSpeed / 25;
        }
    }
}
