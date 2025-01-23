using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : PoolObj
{
    [SerializeField] private int speed = 20;
    [SerializeField] private int lifetime = 2;
    [SerializeField] private int damage;
    public Hero archer;
    
    private void Start()
    {
        Invoke("DestroyArrow", lifetime);
        damage = archer.damage;
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyCastle"))
        {
            archer.TakeDamage();
            DestroyArrow();
        }
    }

    public void DestroyArrow()
    {
        ArrowPool.Instance.ReturnArrowToPool(gameObject);
    }

    public override string GetName()
    {
        throw new System.NotImplementedException();
    }
}


