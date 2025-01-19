using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Hero : Actor
{
    public int level;
    public int id;
    [SerializeField] private int Speed;

    private Animator anim;
    private BoxCollider2D boxCol2D;
    public GameObject enemyTargeted;
    public Vector3 SpawnArrowPosition;
    public Vector3 SpawnTakeDamageTextPosition;

    [SerializeField] private float enemyDectionRadius;
    [SerializeField] private LayerMask enemyDectionLayer;
    [SerializeField] private LayerMask enemyCastleDectionLayer;
    [SerializeField] private SpriteRenderer sprite;
    public ShopHeroData heroData;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        SetData();
        curHealth = maxHealth;
    }
    protected virtual void Update()
    {
        Move();
        GetArrowPosition();
        GetTakeDamageTextPosition();
    }
    private void SetData()
    {
        level = DataPlayer.GetLevelHero(id);
        damage = heroData.shopHero[id].heroLevel[level].damage;
        maxHealth = heroData.shopHero[id].heroLevel[level].maxHealth;
        armor = heroData.shopHero[id].heroLevel[level].armor;
    }
    private void GetTakeDamageTextPosition()
    {
        SpawnTakeDamageTextPosition = transform.GetChild(0).position;
    }
    private void GetArrowPosition()
    {
        if (transform.childCount == 1) return;
        SpawnArrowPosition = transform.GetChild(1).position;
    }
    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    public override void Dead()
    {
        if (!isDead()) return;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        anim.SetTrigger("Dead");       
    }
    private void DestroyHero()
    {
        StartCoroutine(DestroyHeroEffect());
        Destroy(gameObject);
    }

    private IEnumerator DestroyHeroEffect()
    {
        float opaque = sprite.color.a;
        while (opaque > 0)
        {
            opaque -= 0.1f;
            sprite.color = new Color (1,1,1,1 - opaque);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void FixedUpdate()
    {
        DetectEnemy();
    }

    private void DetectEnemy()
    {
        var enemyFindeds = Physics2D.OverlapCircleAll(transform.position, enemyDectionRadius, enemyDectionLayer);
        var enemyCastleFindeds = Physics2D.OverlapCircleAll(transform.position, enemyDectionRadius, enemyCastleDectionLayer);
        var finalEnemy = FindNearestEnemy(enemyFindeds);
        var finalEnemyCastle = FindNearestEnemy(enemyCastleFindeds);
        if (finalEnemy == null && finalEnemyCastle == null) return;
        if (finalEnemy != null) enemyTargeted = finalEnemy;
        else enemyTargeted = finalEnemyCastle;
        Attack();
    }
    protected override void Attack()
    {
        if (enemyTargeted == null) return;
        anim.SetBool("Attack", true);
        if (speed == 0) speed = 5;
        Speed = speed;
        speed = 0;
    }
    private GameObject FindNearestEnemy(Collider2D[] enemyFindeds)
    {
        float minDistance = 0;
        GameObject finalEnemy = null;
        if (enemyFindeds == null || enemyFindeds.Length <= 0) return null;
        for (int i = 0; i < enemyFindeds.Length; i++)
        {
            var enemyFinded = enemyFindeds[i];
            if (enemyFinded == null) continue;
            if (finalEnemy == null)
            {
                minDistance = Vector2.Distance(transform.position, enemyFinded.transform.position);
            }
            else
            {
                float distanceTemp = Vector2.Distance(transform.position, enemyFinded.transform.position);
                if (distanceTemp > minDistance) continue;
                minDistance = distanceTemp;
            }
            finalEnemy = enemyFinded.gameObject;
        }
        return finalEnemy;
    }
    public void SetHealth(int damage)
    {
        int realDamage = Mathf.CeilToInt(UnityEngine.Random.Range(damage / (1 + armor / 100f) - 2, damage / (1 + armor / 100f) + 3));
        curHealth -= realDamage;
        SpawnTakeDamageText(realDamage);
    }
    public bool isDead()
    {
        return curHealth <= 0;
    }
    public void TakeDamage()
    {
        if (enemyTargeted == null)
        {
            speed = Speed;
            anim.SetBool("Attack", false);
            return;
        }
        if (transform.childCount == 1) SoundManager.Ins.SwordAttack();
        else SoundManager.Ins.ArrowAttack();
        if (enemyTargeted.CompareTag("Enemy"))
        TakeDamageEnemy();
        else
        TakeDamageEnemyCastle();
    }
    private void TakeDamageEnemy()
    {
        var enemy = enemyTargeted.GetComponent<Enemy>();
        if (enemy == null) return;
        enemy.SetHealth(damage);
        if (enemy.isDead() || enemy.gameObject.activeSelf == false )
        {
            speed = Speed;
            enemy.Dead();
            enemyTargeted = null;
            anim.SetBool("Attack", false);
        }
    }
    private void TakeDamageEnemyCastle()
    {
        var enemyCastle = enemyTargeted.GetComponent<Castle>();
        if (enemyCastle == null) return;
        enemyCastle.SetHealth(damage);
        if (enemyCastle.isDead())
        {
            speed = Speed;
            enemyTargeted = null;
            anim.SetBool("Attack", false);
        }

    }
    private void SpawnArrow()
    {
        GameObject arrow = ArrowPool.Instance.GetArrowFromPool(SpawnArrowPosition);
        arrow.GetComponent<Arrow>().archer = this;
    }
    private void SpawnTakeDamageText(int realDamage)
    {
        GameObject takeDamageText = TakeDamageTextPool.Instance.GetTakeDamageTextFromPool(SpawnTakeDamageTextPosition);
        takeDamageText.GetComponent<Text>().text = realDamage.ToString();
        takeDamageText.GetComponent<Text>().color = new Color(1, 0, 0, 1);
    }
}
