using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageTextPool : MonoBehaviour
{
    public static TakeDamageTextPool Instance;
    private Queue<GameObject> takeDamageTextPool = new Queue<GameObject>();
    [SerializeField] private GameObject takeDamageTextPrefab;
    [SerializeField] private GameObject[] takeDamageTextPrefabs;
    [SerializeField] private GameObject takeDamageText;
    [SerializeField] private GameObject canvas;

    private int poolSize = 10;
    private void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            AddTakeDamageText();
        }
    }
    public GameObject GetTakeDamageTextFromPool(Vector3 position)
    {
        if (takeDamageTextPool.Count == 0)
        {
            AddTakeDamageText();
        }
        GameObject takeDamageTextFromPool = null;
        takeDamageTextFromPool = takeDamageTextPool.Dequeue();
        takeDamageTextFromPool.transform.position = position;
        takeDamageTextFromPool.SetActive(true);
        return takeDamageTextFromPool;
    }
    private void AddTakeDamageText()
    {
        takeDamageText = Instantiate(takeDamageTextPrefab);
        takeDamageText.transform.SetParent(canvas.transform);
        takeDamageText.SetActive(false);
        takeDamageTextPool.Enqueue(takeDamageText);
    }

    public void ReturnTakeDamageTextToPool(GameObject arrow)
    {
        arrow.SetActive(false);
        takeDamageTextPool.Enqueue(arrow);
    }
}
