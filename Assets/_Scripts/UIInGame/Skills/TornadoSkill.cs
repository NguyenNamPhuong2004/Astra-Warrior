using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TornadoSkill : MonoBehaviour
{
    [SerializeField] private GameObject tornadoPrefab;
    [SerializeField] private Button tornadoSkillBtn;
    [SerializeField] private Image countDownTimeSkill;
    [SerializeField] private Image graphic;
    [SerializeField] private Image lockImage;
    [SerializeField] private Transform tornadoSpawnPosition;
    [SerializeField] private ParticleSystem rain;

    [SerializeField] private int spawnTime;
    private float curSpawnTime;

    private void Awake()
    {
        tornadoSkillBtn = GetComponent<Button>();
        tornadoSkillBtn.onClick.AddListener(ActiveSkill);
        curSpawnTime = spawnTime;
    }
    private void Update()
    {
        if (rain != null && rain.isPlaying)
        {
            lockImage.gameObject.SetActive(false);
        }
        else lockImage.gameObject.SetActive(true);
    }
    public void ActiveSkill()
    {
        Instantiate(tornadoPrefab, tornadoSpawnPosition);
        StartCoroutine(SpawnTime());
    }
    private IEnumerator SpawnTime()
    {
        graphic.color = new Color(0.2f, 0.2f, 0.2f, 1);
        curSpawnTime = 0;
        tornadoSkillBtn.enabled = false;
        while (curSpawnTime < spawnTime)
        {
            curSpawnTime += Time.deltaTime;
            countDownTimeSkill.fillAmount = curSpawnTime / spawnTime;
            yield return new WaitForSeconds(1 / 60);
        }
        graphic.color = new Color(0.4f, 0.4f, 0.4f, 1);
        tornadoSkillBtn.enabled = true;
    }
}
