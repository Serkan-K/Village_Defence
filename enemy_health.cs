using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]

public class enemy_health : MonoBehaviour
{
    [SerializeField] int Hit;
    [SerializeField] int Difficulty;
    int Health;

    Enemy enemy;
    Enemy_path speed;


    void OnEnable()
    {
        Health = Hit;
    }


    void Start()
    {
        enemy = GetComponent<Enemy>();
        speed = GetComponent<Enemy_path>();
    }

    void OnParticleCollision(GameObject h)
    {
        Health--;

        if (Health<=0)
        {
            gameObject.SetActive(false);
            Hit += Difficulty;
            speed.Speed_Dif();
            enemy.Reward();
        }
    }
}
