using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodText : TextAbstract
{
    private Food food;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadFood();
    }
    private void LoadFood()
    {
        if (this.food != null) return;
        this.food = GetComponent<Food>();
        Debug.Log(transform.name + ": Food", gameObject);
    }
    private void FixedUpdate()
    {
        UpdateView();
    }
    private void UpdateView()
    {
        text.text = food.CurrentFood.ToString() + " / " + food.MaxFood.ToString();
    }
}
