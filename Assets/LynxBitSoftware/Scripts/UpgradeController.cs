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
        newTimeToProduce = time - (time * 0.1f);
        return Math.Round(newTimeToProduce, 2);
    }
    public double calculateNewValue(double value) 
    {
        double newValue;
        newValue = value + (value * 0.1f);
        return Math.Round(newValue, 2);

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
    public void UpgradeFilter() 
    { 
    
    }

    public void UpgradeTransportist() 
    {
    
    }

    public void UpgradeStock() 
    { 
    
    }

    public void UpgradeTruck() 
    { 
    
    }
}
