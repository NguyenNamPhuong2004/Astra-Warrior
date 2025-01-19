using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public static ArrowPool Instance;
    private Queue<GameObject> arrowPool = new Queue<GameObject>();
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject[] arrowPrefabs;   
    [SerializeField] private GameObject arrow;

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
            AddArrow();
        }
    }
    public GameObject GetArrowFromPool(Vector3 position)
    {
        if (arrowPool.Count == 0)
        {
            AddArrow();
        }
        GameObject arrowFromPool = null;
        arrowFromPool = arrowPool.Dequeue();
        arrowFromPool.transform.position = position;
        arrowFromPool.SetActive(true);
        return arrowFromPool;
    }
    private void AddArrow()
    {
        arrow = Instantiate(arrowPrefab);
        arrow.SetActive(false);
        arrowPool.Enqueue(arrow);
    }

    public void ReturnArrowToPool(GameObject arrow)
    {
        arrow.SetActive(false);
        arrowPool.Enqueue(arrow);
    }
}

