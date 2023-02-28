using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem arrow;
    [SerializeField] float Tower_range;
    Transform target;
   
    void Update()
    {
        Find_enemy();
        AimTarget();
    }


    void Find_enemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closest_Target = null;
        float max_Distance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float target_Distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (target_Distance < max_Distance)
            {
                closest_Target = enemy.transform;
                max_Distance = target_Distance;
            }
        }
        target = closest_Target;
    }

    void AimTarget()
    {
        float target_Distance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (target_Distance < Tower_range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }


    void Attack(bool isActive)
    {
        var emissionmodule = arrow.emission;
        emissionmodule.enabled = isActive;

    }
}
