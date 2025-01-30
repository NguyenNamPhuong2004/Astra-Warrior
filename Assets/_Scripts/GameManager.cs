using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Enemy Component:")]
    [SerializeField] private EnemySpawning enemySpawning; 
    [SerializeField] private EnemyCastleDamageReceiver enemyCastleDamageReceiver;


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
    protected override void Awake()
    {
        base.Awake();
       // MakeSingleton(false);
    }
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
        Physics2D.IgnoreLayerCollision(7, 7);
        Physics2D.IgnoreLayerCollision(6, 8);
        Physics2D.IgnoreLayerCollision(7, 9);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemySpawning();
        LoadEnemyCastleDamageReceiver();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        isSpawnBoss = true;
        spawnTime = 0;
    }
    protected virtual void LoadEnemySpawning()
    {
        if (this.enemySpawning != null) return;
        this.enemySpawning = GameObject.FindObjectOfType<EnemySpawning>();
        Debug.Log(transform.name + ": EnemySpawning ", gameObject);
    } 
    protected virtual void LoadEnemyCastleDamageReceiver()
    {
        if (this.enemyCastleDamageReceiver != null) return;
        this.enemyCastleDamageReceiver = GameObject.FindObjectOfType<EnemyCastleDamageReceiver>();
        Debug.Log(transform.name + ": EnemyCastleDamageReceiver ", gameObject);
    }

    private void Update()
    {
        LevelDesign();
    }
   
    private void LevelDesign()
    {
        Debug.Log("1");
        switch (DataPlayer.GetLevelGame())
        {
            case 1:
                Debug.Log("2");
                SpawnEnemy(15, 20, 1);
                Debug.Log("3");
                if (enemyCastleDamageReceiver.IsHurt() && isSpawnBoss == true)
                {
                    enemySpawning.ByIDSpawning(1);
                    isSpawnBoss = false;
                }
                break; 
            case 2:
                SpawnEnemy(15, 20, 2);
                break;
            case 3:
                SpawnEnemy(10, 15, 2);
                if (enemyCastleDamageReceiver.IsHurt() && isSpawnBoss == true)
                {
                    enemySpawning.ByIDSpawning(2);
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
                background1.color = new Color32(100, 100, 100, 255);
                background2.color = new Color32(100, 100, 100, 255);
                rain.Play();
                break;
        }
    }
    private void SpawnEnemy(int minTime, int maxTime, int numberOfTypes)
    {
        if (enemyCastleDamageReceiver.IsDead() || enemyCastleDamageReceiver == null) return;
        Debug.Log("4");
        if (spawnTime <= 0f)
        {
            Debug.Log("5");
            enemySpawning.RandomSpawning(numberOfTypes);
            Debug.Log("6");
            spawnEnemyTime = Random.Range(minTime, maxTime);
            spawnTime = spawnEnemyTime;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
    public void Defeat()
    {  
        gameEqualText.text = "DEFEAT";
        gameOverDialog.SetActive(true);
        nextLevelBtn.SetActive(false);

        int coin = Random.Range(100, 120);
        addCoin.text = coin.ToString();
        DataPlayer.AddCoin(coin);

        SoundManager.Ins.Defeat();
    }
    public void Victory()
    {
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
