using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageText : MonoBehaviour
{
    public void DestroyTakeDamageText()
    {
        TakeDamageTextPool.Instance.ReturnTakeDamageTextToPool(gameObject);
    }
}
