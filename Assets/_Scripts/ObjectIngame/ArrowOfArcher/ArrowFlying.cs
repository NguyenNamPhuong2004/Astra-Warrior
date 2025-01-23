using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFlying : LoadData
{
    [SerializeField] private int speed = 20;
    private void Update()
    {
        Fly();
    }
    protected virtual void Fly()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
