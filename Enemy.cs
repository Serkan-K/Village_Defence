using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int gold_reward;
    [SerializeField] int gold_penalty;

    Bank bank;

    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }

    public void Reward()
    {
        if(bank ==null) { return; }
        bank.Deposit(gold_reward);
    }


    public void Steal()
    {
        if (bank == null) { return; }
        bank.Withdraw(gold_penalty);
    }
}
