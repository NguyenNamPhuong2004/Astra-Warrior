using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheldSkill : MonoBehaviour
{
    [SerializeField] private GameObject sheldPrefab;
    [SerializeField] private float dectionRadius;
    [SerializeField] private LayerMask dectionLayer;
    [SerializeField] private Button sheldSkillBtn;
    [SerializeField] private Image countDownTimeSkill;
    [SerializeField] private Image graphic;

    [SerializeField] private int spawnTime;
    private float curSpawnTime;

    private void Awake()
    {
        sheldSkillBtn = GetComponent<Button>();
        sheldSkillBtn.onClick.AddListener(ActiveSkill);
        curSpawnTime = spawnTime;
    }
    public void ActiveSkill()
    {
        var heroFindeds = Physics2D.OverlapCircleAll(transform.position, dectionRadius, dectionLayer);
        foreach(Collider2D col in heroFindeds)
        {
            if (col.GetComponentInChildren<Sheld>() != null) continue;
            GameObject sheld = Instantiate(sheldPrefab, col.transform.position, Quaternion.identity);
            sheld.transform.SetParent(col.transform);
            col.GetComponent<Hero>().armor += 150;
        }
        StartCoroutine(SpawnTime());
    }
    private IEnumerator SpawnTime()
    {
        graphic.color = new Color(0.2f, 0.2f, 0.2f, 1);
        curSpawnTime = 0;
        sheldSkillBtn.enabled = false;
        while (curSpawnTime < spawnTime)
        {
            curSpawnTime += Time.deltaTime;
            countDownTimeSkill.fillAmount = curSpawnTime / spawnTime;
            yield return new WaitForSeconds(1 / 60);
        }
        graphic.color = new Color(0.4f, 0.4f, 0.4f, 1);
        sheldSkillBtn.enabled = true;
    }
}
