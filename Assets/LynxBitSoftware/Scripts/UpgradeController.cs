using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public double calculateNewTimeToProduce(double time) 
    {
        double newTimeToProduce;
        newTimeToProduce = time - 0.1f;
        return Math.Round(newTimeToProduce, 2);
    }
    public double calculateNewValue(double value) 
    {
        double newValue;
        newValue = value + 1 + (value * 0.05f);
        return Math.Round(newValue, 2);

    }
    public double calculateNewMultiplier(double multiplier) 
    {
        double newMultiplier;
        newMultiplier = multiplier + 0.1f;
        return Math.Round(newMultiplier, 2);
    }

    public int calculateNewCapacityTransportist(int numOfStackableItems) 
    {
        return numOfStackableItems + 5;
    }
    public void UpgradeWorker(WorkerController worker) 
    {
        if (GameManager.instance.currency.GetCurrencyCash() >= worker.constructor.GetCostToUpgrade()) 
        {
            GameManager.instance.currency.SubstractCurrencyCash(worker.constructor.GetCostToUpgrade());
            worker.constructor.SetLevel(worker.constructor.GetLevel()+1);
            worker.constructor.SetTimeToProduce(calculateNewTimeToProduce(worker.constructor.GetTimeToProduce()));
            worker.CalculateCostUpgrade();
            worker.SetDataUI();
        }
    }
    public void UpgradeGun(WorkerController worker) 
    {
        if (GameManager.instance.currency.GetCurrencyCash() >= worker.constructor.GetItem().GetCostToUpgrade()) 
        {
            GameManager.instance.currency.SubstractCurrencyCash(worker.constructor.GetItem().GetCostToUpgrade());
            worker.constructor.GetItem().SetLevel(worker.constructor.GetItem().GetLevel() + 1);
            worker.constructor.GetItem().SetValue(calculateNewValue(worker.constructor.GetItem().GetValue()));
            worker.CalculateCostToUpgradeGun();
            worker.SetDataUI();
        }
    }
    public void UpgradeFilter(FilterController filter) 
    { 
        if(GameManager.instance.currency.GetCurrencyCash() >= filter.filter.GetCostToUpgrade())
        {
            GameManager.instance.currency.SubstractCurrencyCash(filter.filter.GetCostToUpgrade());
            filter.filter.SetLevel(filter.filter.GetLevel() + 1);
            filter.filter.SetMultiplier(calculateNewMultiplier(filter.filter.GetMultiplier()));
            filter.CalculateCostUpgrade();
            filter.SetDataUI();
        }
    }

    public void UpgradeTransportist(Transportist transportist) 
    {
        if (GameManager.instance.currency.GetCurrencyCash() >= transportist.distribuidor.GetCostToUpgrade())
        {
            GameManager.instance.currency.SubstractCurrencyCash(transportist.distribuidor.GetCostToUpgrade());
            transportist.distribuidor.SetLevel(transportist.distribuidor.GetLevel() + 1);
            transportist.distribuidor.SetnumOfItemsStackable(calculateNewCapacityTransportist(transportist.distribuidor.GetnumOfItemsStackable()));
            transportist.CalculateCostUpgrade();
            transportist.SetDataUI();
        }
    }

    public void UpgradeStock() 
    { 
    
    }

    public void UpgradeTruck() 
    { 
    
    }
}
