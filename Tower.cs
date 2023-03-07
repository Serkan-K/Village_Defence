using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] float buil_delay;


    void Start()
    {
        StartCoroutine(Build());
    }


    public bool Tower_Spawn(Tower tower, Vector3 position)
    {
        Bank bank = FindAnyObjectByType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.Money >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
        
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }


        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buil_delay);


            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }


    }


}
