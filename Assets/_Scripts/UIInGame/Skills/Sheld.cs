using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheld : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 0, -200 * Time.deltaTime);
    }
}
