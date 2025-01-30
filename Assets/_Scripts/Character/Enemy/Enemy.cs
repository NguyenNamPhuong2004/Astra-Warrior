using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : PoolObj
{
    public override string GetName()
    {
        return gameObject.name;
    }
}
