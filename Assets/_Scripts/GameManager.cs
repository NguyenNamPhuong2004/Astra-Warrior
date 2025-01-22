using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : LoadData
{
    public static GameManager Instance;

    [Header("Actor:")]
    [SerializeField] private GameObject[] hero;
    [SerializeField] private GameObject[] enemy; 

    [Header("Castle Actor:")]
    [SerializeField] private Castle heroCastle;
    [SerializeField] private Castle enemyCastle;


    [Header("Game Over UI:")]
    [SerializeField] private Text gameEqualText;
    [SerializeField] private GameObject gameOverDialog;
    [SerializeField] private GameObject nextLevelBtn;
    [SerializeField] private Text addCoin;

    [Header("Effect:")]
    [SerializeField] private SpriteRenderer background1;
    [SerializeField] private SpriteRenderer background2;
    [SerializeField] private ParticleSystem rain;

    [Header("Spawn Enemy:")]
    private bool isSpawnBoss;
    int spawnEnemyTime;
    float spawnTime;
    [SerializeField] private Transform enemySpawnPosition;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSingleton();
        LoadHeroData();
        LoadEnemyData();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        isSpawnBoss = true;
    }
    protected virtual void LoadHeroData()
    {
        if (this.hero != null) return;
        this.hero = Resources.LoadAll<GameObject>("Prefabs/Hero");
        Debug.Log(transform.name + ": ListHero ", gameObject);
    } 
    protected virtual void LoadEnemyData()
    {
        if (this.enemy != null) return;
        this.enemy = Resources.LoadAll<GameObject>("Prefabs/Enemy");
        Debug.Log(transform.name + ": ListEnemy ", gameObject);
    }
    private void Start()
    {
        SetID();
    }

    private void SetID()
    {
        if (hero == null || hero.Length == 0) return;
        for (int i = 0; i < hero.Length; i++)
        {
            hero[i].GetComponent<HeroStats>().SetID(i);
        }
    }

    private void Update()
    {
        GameOver();
        LevelDesign();
    }
    private void LoadSingleton() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
   
    private void LevelDesign()
    {
        switch (DataPlayer.GetLevelGame())
        {
            case 1:
                SpawnEnemy(15, 20, 1);
                if(enemyCastle.curHealth < enemyCastle.maxHealth && isSpawnBoss == true)
                {
                    Instantiate(enemy[1], enemySpawnPosition.position, Quaternion.identity);
                    isSpawnBoss = false;
                }
                break; 
            case 2:
                SpawnEnemy(15, 20, 2);
                break;
            case 3:
                SpawnEnemy(10, 15, 2);
                if (enemyCastle.curHealth < enemyCastle.maxHealth && isSpawnBoss == true)
                {
                    Instantiate(enemy[2], enemySpawnPosition.position, Quaternion.identity);
                    isSpawnBoss = false;
                }
                background1.color = new Color32(100, 100, 100, 255);
                background2.color = new Color32(100, 100, 100, 255);
                rain.Play();
                break;
            case 4:
                SpawnEnemy(10, 15, 4);
                background1.color = new Color32(100, 100, 100, 255);
                background2.color = new Color32(100, 100, 100, 255);
                rain.Play();
                break;
            case 5:
                SpawnEnemy(7, 12, 4);
                enemyCastle.maxHealth += 10000;
                enemyCastle.armor += 100;
                background1.color = new Color32(100, 100, 100, 255);
                background2.color = new Color32(100, 100, 100, 255);
                rain.Play();
                break;
        }
    }
    private void SpawnEnemy(int minTime, int maxTime, int numberOfTypes)
    {
        if (enemyCastle.isDead() || enemyCastle == null) return;
        if (spawnTime <= 0f)
        {
            InstantiatEnenmy(numberOfTypes);
            spawnEnemyTime = Random.Range(minTime, maxTime);
            spawnTime = spawnEnemyTime;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
    public void InstantiateHero(int id)
    {
        if (hero == null || hero.Length == 0) return;
        Instantiate(hero[id], transform.position, Quaternion.identity);
    }
    private void InstantiatEnenmy(int numberOfTypes)
    {
        int id = Random.Range(0, numberOfTypes);
        Instantiate(enemy[id], enemySpawnPosition.position, Quaternion.identity);
    }

    private void GameOver()
    {
        if (heroCastle.isDead() && heroCastle != null)
        {
            Defeat();
        }
        if (enemyCastle.isDead() && enemyCastle != null)
        {
            Victory();
        }
        
    }
    private void Defeat()
    {
        Destroy(heroCastle.gameObject);

        gameEqualText.text = "DEFEAT";
        gameOverDialog.SetActive(true);
        nextLevelBtn.SetActive(false);

        int coin = Random.Range(100, 120);
        addCoin.text = coin.ToString();
        DataPlayer.AddCoin(coin);

        SoundManager.Ins.Defeat();
    }
    private void Victory()
    {
        Destroy(enemyCastle.gameObject);

        gameEqualText.text = "VICTORY";
        gameOverDialog.SetActive(true);
        nextLevelBtn.SetActive(true);

        int coin = Random.Range(240, 260);
        addCoin.text = coin.ToString();
        DataPlayer.AddCoin(coin);

        SoundManager.Ins.Victory();

        // Unlock Level Next 
        if (DataPlayer.GetLevelGame() == DataPlayer.GetUnlockLevelGame())
        {
            DataPlayer.SetUnlockLevelGame();
        }
    }
}
