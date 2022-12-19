using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    private int currency_cash, currency_gems;
    // Start is called before the first frame update
    void Start()
    {
        currency_cash = 10;
    }
    //Cash stuff
    public void AddCurrencyCash(int amount)
    {
        currency_cash += amount;
    }

    public void SubstractCurrencyCash(int amount) 
    {
       currency_cash -= amount;      
    }

    public int GetCurrencyCash() 
    {
        return this.currency_cash;
    }
    //Gems stuff
    public void AddCurrencyGems(int amount)
    {
        currency_gems += amount;
    }

    public void SubstractCurrencyGems(int amount)
    {
        currency_gems -= amount;
    }

    public int GetCurrencyGems()
    {
        return this.currency_gems;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
