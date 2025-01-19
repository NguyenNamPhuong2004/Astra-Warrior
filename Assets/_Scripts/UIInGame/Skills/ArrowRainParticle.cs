using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRainParticle : MonoBehaviour
{
    public ArrowRain arrowRain;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().SetHealth(arrowRain.damage);
        }
    }
}
