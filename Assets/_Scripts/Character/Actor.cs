using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int damage;
    public int maxHealth;
    public int armor;
    public int speed;
    public int curHealth;

    protected virtual void Awake()
    {
        curHealth = maxHealth;
    }

    protected virtual void Move() { }  
    protected virtual void Attack() { }
    public virtual void Dead() { }

}
