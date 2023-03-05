using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pool : MonoBehaviour
{
    [SerializeField] GameObject enemy_prefab;
    [SerializeField] [Range(0.1f,30f)] float Spawn_time;

    [SerializeField] [Range(0f, 50f)] int Pool_size;

    GameObject[] pool;

    void Awake()
    {
        Populate_pool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    void Populate_pool()
    {
        pool = new GameObject[Pool_size];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i]= Instantiate(enemy_prefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Enable_object()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Enable_object();
            yield return new WaitForSeconds(Spawn_time);
        }
    }
}
