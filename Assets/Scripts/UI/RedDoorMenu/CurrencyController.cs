using System;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public static CurrencyController Instance;

    [SerializeField] private int startingMoney = 100; //Money upon starting new game
    private int playerMoney = 100;
    public event Action<int> onMoneyChanged;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            playerMoney = startingMoney;
        }
    }

    public int getMoney() => playerMoney;

    public bool SpendMoney(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            onMoneyChanged?.Invoke(playerMoney);
            return true;
        }
        return false;
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        onMoneyChanged?.Invoke(playerMoney);
    }

    public void SetMoney(int amount)
    {
        playerMoney = amount;
        onMoneyChanged?.Invoke(playerMoney);
    }
}
