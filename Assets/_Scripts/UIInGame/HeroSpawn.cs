using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawn : MonoBehaviour
{
    [SerializeField] private HeroInGameBtn[] heroSpawn;
    private void Awake()
    {
        heroSpawn = GetComponentsInChildren<HeroInGameBtn>();
    }
    private void Start()
    {
        SetID();
        SetHeroBtn();
    }
    private void SetID()
    {
        if (heroSpawn == null || heroSpawn.Length == 0) return;
        for (int i = 0; i < heroSpawn.Length; i++)
        {
            heroSpawn[i].SetID(i);
            heroSpawn[i].gameObject.SetActive(false);
        }
    }
    private void SetHeroBtn()
    {
        foreach (int heroID in DataPlayer.GetHeroList())
            foreach (var heroBtn in heroSpawn)
            {
                if (heroID == heroBtn.id)
                    heroBtn.gameObject.SetActive(true);
            }
    }

}
