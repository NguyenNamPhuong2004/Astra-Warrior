using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowRain : MonoBehaviour
{
    public ShopCastleData arrowRainData;
    int level;
    [SerializeField] private ParticleSystem arrowRain;
    [SerializeField] private Button arrowRainBtn;
    [SerializeField] private Image countDownTimeSkill;
    [SerializeField] private Image graphic;
    public int damage;

    [SerializeField] private int spawnTime;
    private float curSpawnTime;

    private void Awake()
    {
        SetData();
        arrowRainBtn = GetComponent<Button>();
        arrowRainBtn.onClick.AddListener(ActiveSkill);
        curSpawnTime = spawnTime;
    }
    private void SetData()
    {
        level = DataPlayer.GetLevelArrows();
        damage = arrowRainData.shopArrows.arrowsLevel[level].damage;
        spawnTime = arrowRainData.shopArrows.arrowsLevel[level].timeSkill;
    }

    private void ActiveSkill()
    {
        arrowRain.Play();
        SoundManager.Ins.ArrowRainAttack();
        StartCoroutine(SpawnTime());
    }
    private IEnumerator SpawnTime()
    {
        graphic.color = new Color(0.2f, 0.2f, 0.2f, 1);
        curSpawnTime = 0;
        arrowRainBtn.enabled = false;
        while (curSpawnTime < spawnTime)
        {
            curSpawnTime += Time.deltaTime;
            countDownTimeSkill.fillAmount = curSpawnTime / spawnTime;
            yield return new WaitForSeconds(1 / 60);
        }
        graphic.color = new Color(0.4f, 0.4f, 0.4f, 1);
        arrowRainBtn.enabled = true;
    }
}
