using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockUI : MonoBehaviour
{
    public GameObject uiStockAndTruck;
    public CarController car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if (!uiStockAndTruck.activeSelf && GameManager.instance.canOpenUI)
        {
            GameManager.instance.canOpenUI = false;
            GameManager.instance.stockToUpgrade = this.GetComponentInChildren<StockController>();
            GameManager.instance.truckToUpgrade = car;
            GameManager.instance.stockToUpgrade.CalculateCostUpgrade();
            GameManager.instance.truckToUpgrade.CalculateCostUpgrade();
            uiStockAndTruck.SetActive(true);
            GameManager.instance.stockToUpgrade.SetDataUI();
            GameManager.instance.truckToUpgrade.SetDataUI();
        }
    }
}
