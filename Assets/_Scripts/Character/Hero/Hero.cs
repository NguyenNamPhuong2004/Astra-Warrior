using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Hero : PoolObj
{
    public override string GetName()
    {
        return gameObject.name;
    }
}
