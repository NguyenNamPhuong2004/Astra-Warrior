using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Ins;
    public AudioSource AufxClick;
    public AudioSource AufxRain;
    public AudioSource AufxBackground;
    public AudioClip rain;
    public AudioClip arrowRain;
    public AudioClip buttonClip;
    public AudioClip music;
    public AudioClip buyOrUpgrade;
    public AudioClip victory;
    public AudioClip defeat;
    public AudioClip swordAttack;
    public AudioClip arrowAttack;
    public AudioClip typeKeyBoard;
    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(Ins);
        }
        else
        {
            Destroy(this);
        }
    }
    private void OnValidate()
    {
        if (AufxClick == null)
        {
            AufxClick = gameObject.AddComponent<AudioSource>();
            AufxClick.playOnAwake = false;
        }
    } 
    public void Music()
    {
        AufxBackground.clip = music;
        AufxBackground.Play();
    }
    public void Rain()
    {
        AufxRain.clip = rain;
        AufxRain.Play();
    }
    public void ButtonSound()
    {
        AufxClick.PlayOneShot(buttonClip);
    }
    public void BuyOrUpgrade()
    {
        AufxClick.PlayOneShot(buyOrUpgrade);
    }
    public void Victory()
    {
        AufxClick.PlayOneShot(victory);
    }
    public void Defeat()
    {
        AufxClick.PlayOneShot(defeat);
    }
    public void SwordAttack()
    {
        AufxClick.PlayOneShot(swordAttack);
    }
    public void ArrowAttack()
    {
        AufxClick.PlayOneShot(arrowAttack);
    } 
    public void ArrowRainAttack()
    {
        AufxClick.PlayOneShot(arrowRain);
    } 
    public void TypeKeyBoard()
    {
        AufxClick.PlayOneShot(typeKeyBoard);
    }

}
