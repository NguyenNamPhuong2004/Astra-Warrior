using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private List<GameObject> sweptEnemys;
    [SerializeField] private int speed;

    private void Awake()
    {
        sweptEnemys = new List<GameObject>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SweptAway(collision);
        }
        else if (collision.gameObject.CompareTag("EnemyCastle"))
        {
            DestroyTornado();         
        }
    }

    private void SweptAway(Collision2D collision)
    {
        sweptEnemys.Add(collision.gameObject);
        collision.gameObject.transform.SetParent(transform, true);
        collision.gameObject.SetActive(false);      
    }
    private void DestroyTornado()
    {
        foreach(GameObject enemy in sweptEnemys)
        {           
            enemy.transform.SetParent(null);
            enemy.SetActive(true);
            float x = Random.Range(-1f, 1f);
            enemy.transform.position = new Vector2(enemy.transform.position.x + x, enemy.transform.position.y);
        }
        Destroy(gameObject);
    }
}
