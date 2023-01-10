using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    private float currency_cash, currency_gems;
    // Start is called before the first frame update
    void Start()
    {
        currency_cash = 0;
        currency_gems = 0;
    }
    //Cash stuff
    public void AddCurrencyCash(float amount)
    {
        currency_cash += amount;
    }

    public void SubstractCurrencyCash(float amount) 
    {
       currency_cash -= amount;      
    }

    public float GetCurrencyCash() 
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

    public float GetCurrencyGems()
    {
        return this.currency_gems;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
