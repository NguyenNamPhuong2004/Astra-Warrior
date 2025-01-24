using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Actor
{
    [SerializeField] private GameObject heroTargeted;
    private Animator anim;

    [SerializeField] private float heroDectionRadius;
    [SerializeField] private LayerMask heroDectionLayer;
    [SerializeField] private LayerMask heroCastleDectionLayer;
    [SerializeField] private SpriteRenderer sprite;
    public Vector3 SpawnTakeDamageTextPosition;

    [SerializeField] private int Speed;
    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    protected virtual void Update()
    {
        Move();
        GetTakeDamageTextPosition();
    }
    protected override void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    private void GetTakeDamageTextPosition()
    {
        SpawnTakeDamageTextPosition = transform.GetChild(0).position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tornado"))
        {
            speed = 5;
            heroTargeted = null;
        }
    }
    private void FixedUpdate()
    {
        DetectHero();
    }

    private void DetectHero()
    {
        var heroFindeds = Physics2D.OverlapCircleAll(transform.position, heroDectionRadius, heroDectionLayer);
        var heroCastleFindeds = Physics2D.OverlapCircleAll(transform.position, heroDectionRadius, heroCastleDectionLayer);
        var finalHero = FindNearestHero(heroFindeds);
        var finalHeroCastle = FindNearestHero(heroCastleFindeds);
        if (finalHero == null && finalHeroCastle == null) return;
        if (finalHero != null ) heroTargeted = finalHero;
        else heroTargeted = finalHeroCastle;
        Attack();
    }
    private GameObject FindNearestHero(Collider2D[] heroFindeds)
    {
        float minDistance = 0;
        GameObject finalHero = null;
        if (heroFindeds == null || heroFindeds.Length <= 0) return null;
        for (int i = 0; i < heroFindeds.Length; i++)
        {
            var heroFinded = heroFindeds[i];
            if (heroFinded == null) continue;
            if (finalHero == null)
            {
                minDistance = Vector2.Distance(transform.position, heroFinded.transform.position);
            }
            else
            {
                float distanceTemp = Vector2.Distance(transform.position, heroFinded.transform.position);
                if (distanceTemp > minDistance) continue;
                minDistance = distanceTemp;
            }
            finalHero = heroFinded.gameObject;
        }
        return finalHero;
    }
    public override void Dead()
    {
        if (!isDead()) return;
        anim.SetTrigger("Dead");
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

    }
    private void DestroyEnemy()
    {     
        StartCoroutine(DestroyEnemyEffect());
        Destroy(gameObject);
    }

    private IEnumerator DestroyEnemyEffect()
    {
        float opaque = sprite.color.a;
        while (opaque > 0)
        {
            opaque -= 0.1f;
            sprite.color = new Color(1, 1, 1, 1 - opaque);
            yield return new WaitForSeconds(0.1f);
        }
    }
    protected override void Attack()
    {
        if (heroTargeted == null) return;
        anim.SetBool("Attack", true);
        if (speed == 0) speed = 5;
        Speed = speed;
        speed = 0;
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
        if (heroTargeted == null)
        {
            speed = Speed;
            anim.SetBool("Attack", false);
            return;
        }
        SoundManager.Ins.SwordAttack();
        if (heroTargeted.CompareTag("Hero"))
        TakeDamageHero();
        else
        TakeDamageHeroCastle();
    }
    private void TakeDamageHero()
    {
        var hero = heroTargeted.GetComponent<Hero>();
        if (hero == null) return;
        hero.SetHealth(damage);
        if (hero.isDead())
        {
            speed = Speed;
            hero.Dead();
            heroTargeted = null;
            anim.SetBool("Attack", false);
        }
    }
    private void TakeDamageHeroCastle()
    {
        var heroCastle = heroTargeted.GetComponent<Castle>();
        if (heroCastle == null) return;
        heroCastle.SetHealth(damage);
        if (heroCastle.isDead() )
        {
            speed = Speed;
            heroTargeted = null;
            anim.SetBool("Attack", false);
        }
    }
    private void SpawnTakeDamageText(int realDamage)
    {
        GameObject takeDamageText = TakeDamageTextPool.Instance.GetTakeDamageTextFromPool(SpawnTakeDamageTextPosition);
        takeDamageText.GetComponent<Text>().text = realDamage.ToString();
        takeDamageText.GetComponent<Text>().color = new Color(0, 1, 0, 1);
    }
}
