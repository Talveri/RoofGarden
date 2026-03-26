using TMPro;
using UnityEngine;

public class WorkPageManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int moneyPerClick;
    public int timePerClick;
    public int energyPerClick;
    public TMP_Text playerMoneyText;

    void Start()
    {
        playerMoneyText.text = CurrencyController.Instance.getMoney().ToString();
    }
    public void onButtonPress()
    {
        IncreaseMoney();
        decreaseEnergy();
        ForwardTime();
    }
    public void decreaseEnergy()
    {

    }
    public void ForwardTime()
    {

    }
    public void IncreaseMoney()
    {
        CurrencyController.Instance.AddMoney(moneyPerClick);
        playerMoneyText.text = CurrencyController.Instance.getMoney().ToString();
    }
}
