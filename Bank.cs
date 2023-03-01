using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int Money_start;
    
    int money;
    public int Money { get { return money; } }


    [SerializeField] TextMeshProUGUI Balance;


    void Awake()
    {
        money = Money_start;
        Update_balance();
    }


    public void Deposit(int amount)
    {
        money += Mathf.Abs(amount);
        Update_balance();
    }

    public void Withdraw(int amount)
    {
        money -= Mathf.Abs(amount);
        Update_balance();

        if (money < 0)
        {
            Restart();
        }
    }


    void Update_balance()
    {
        Balance.text = "Gold: " + money;
    }



    void Restart()
    {
        Scene level_number = SceneManager.GetActiveScene();
        SceneManager.LoadScene(level_number.buildIndex);
    }
}
