using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private CurrencyController currency;
    [SerializeField]
    private List<CarController> cars;
    [SerializeField]
    private TextMeshProUGUI textCash, textIncomePerMin, textGems, textCostWorker, textCostDoor, textCostFilter, textCostTransportist;
    [SerializeField]
    private List<TextMeshProUGUI> textCapacityCars;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject uiTextCapacityCars;
    [SerializeField]
    private GameObject workerBuyController, filterBuyController, worker, lockDoor, filter, stock;
    [SerializeField]
    private int costToUpgradeWorker, costToBuyDoor, costToBuyFilter;
    //UI 
    public GameObject uiPerson,uiDistribuitor, uiStats, uiBuyWorker, uiBuyDoor, uiBuyFilter, uiFilter, uiStockAndTruck;
    public TextMeshProUGUI ItemName;
    public List<Constructor> list_constructor;
    public List<TextMeshProUGUI> list_ItemDescription;
    public List<Image> list_ItemImage;



    // Start is called before the first frame update
    void Start()
    {
        
        //textIncomePerMin = GetComponentInChildren<TextMeshProUGUI>()
        //textCash = GetComponentInChildren<TextMeshProUGUI>();
        currency = GetComponent<CurrencyController>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowUITextCapacityCars();
        SetUIDATA();
        for (int i = 0; i < textCapacityCars.Count; i++) 
        {
            textCapacityCars[i].text = cars[i].GetSizeItemsInCar() + " / " + cars[i].GetNumberOfStackableItems();
        }
        textCash.text = GameManager.instance.ConvertValueForUI(Convert.ToSingle(currency.GetCurrencyCash())) + "$";
        textGems.text = currency.GetCurrencyGems().ToString();
        //textIncomePerMin.text = GameManager.instance.ConvertValueForUI(GameManager.instance.GetIncomePerMin()) + " / min";
    }

    public void SetUIDATA()
    {
        ItemName.text = "statistics";
        for (int i = 0; i < list_constructor.Capacity; i++)
        {
            Constructor constructor = list_constructor[i];
            list_ItemDescription[i].text = "Weapon: " + constructor.GetItem().GetAlias() + "\n"+
                "Level: " + constructor.GetItem().GetLevel() + "\n"
                        + "Time to Produce: " + constructor.GetTimeToProduce() + "\n"
                        + "Salary: " + constructor.GetSalary() + "\n"
                        ;
            list_ItemImage[i].sprite = constructor.GetItem().GetSpriteItem();


        }
        


    }

    void ShowUITextCapacityCars() 
    {
        if (camera.transform.position.x <= -7.5f)
        {
            uiTextCapacityCars.SetActive(true);
        }
        else
        {
            uiTextCapacityCars.SetActive(false);
        }
    }

    public void CloseUIPerson() 
    {
        GameManager.instance.canOpenUI = true;
        uiPerson.SetActive(false);
    }
    
    public void CloseUIDistribuitor() 
    {
        GameManager.instance.canOpenUI = true;
        uiDistribuitor.SetActive(false);
    }
        
    public void OpenUIStats() 
    {
        if (GameManager.instance.canOpenUI) {
            GameManager.instance.canOpenUI = false;
            uiStats.SetActive(true);
        }
        
    }
    public void OpenUIStockAndTruck()
    {
        if (GameManager.instance.canOpenUI)
        {
            GameManager.instance.canOpenUI = false;
            uiStockAndTruck.SetActive(true);
        }
    }


    public void CloseUIStats() 
    {
        GameManager.instance.canOpenUI = true;
        uiStats.SetActive(false);
    }

    public void OpenUIBuyDoor(int costDoor, GameObject lockDoor)
    {
        if (GameManager.instance.canOpenUI)
        {
            GameManager.instance.canOpenUI = false;
            textCostDoor.text = "Cost for door: " + costDoor + " $";
            this.lockDoor = lockDoor;
            this.costToBuyDoor = costDoor;
            uiBuyDoor.SetActive(true);
        }
    }

    public void CloseUIBuyDoor()
    {
        GameManager.instance.canOpenUI = true;
        uiBuyDoor.SetActive(false);
    }
    public void OpenUIBuyFilter(GameObject _filter, int _filterCost, GameObject button) 
    {
        if (GameManager.instance.canOpenUI)
        {
            GameManager.instance.canOpenUI = false;
            this.filter = _filter;
            this.filterBuyController = button;
            costToBuyFilter = _filterCost;
            textCostFilter.text = "Cost of new filter: " + GameManager.instance.ConvertValueForUI(costToBuyFilter) + " $";
            uiBuyFilter.SetActive(true);
        }

    }
    public void CloseUIBuyFilter() 
    {
        GameManager.instance.canOpenUI = true;
        uiBuyFilter.SetActive(false);
    }
    public void OpenUIBuyWorker(GameObject _worker, int _workerCost, GameObject button)
    {
        if (GameManager.instance.canOpenUI)
        {
            GameManager.instance.canOpenUI = false;
            this.worker = _worker;
            this.workerBuyController = button;
            costToUpgradeWorker = _workerCost;
            textCostWorker.text = "Cost of new worker: " + GameManager.instance.ConvertValueForUI(costToUpgradeWorker) + " $";
            uiBuyWorker.SetActive(true);
        }
    }
    public void BuyFilter()
    {
        CloseUIBuyFilter();
        if (costToBuyFilter <= GameManager.instance.currency.GetCurrencyCash())
        {
            GameManager.instance.currency.SubstractCurrencyCash(costToBuyFilter);
            Debug.Log("I bought a filter for: " + costToBuyDoor);
            filter.SetActive(true);
            Destroy(filterBuyController.gameObject);
        }

    }
    public void BuyDoor() 
    {
        CloseUIBuyDoor();
        if (costToBuyDoor <= GameManager.instance.currency.GetCurrencyCash())
        {
            GameManager.instance.currency.SubstractCurrencyCash(costToBuyDoor);
            Debug.Log("I bought a door for: " + costToBuyDoor);
            GameManager.instance.ExpandFactory();
            Destroy(lockDoor.gameObject);
        }

    }
    public void BuyWorker()
    {
        CloseUIBuyWorker();
        if (costToUpgradeWorker <= GameManager.instance.currency.GetCurrencyCash())
        {
            GameManager.instance.currency.SubstractCurrencyCash(costToUpgradeWorker);
            Debug.Log("I bought a worker for: " + costToUpgradeWorker);
            worker.SetActive(true);
            Destroy(workerBuyController.gameObject);
        }
    }
    public void CloseUIBuyWorker()
    {
        GameManager.instance.canOpenUI = true;
        uiBuyWorker.SetActive(false);
    }

    public void CloseUIFilterUpgrade() 
    {
        GameManager.instance.canOpenUI = true;
        uiFilter.SetActive(false);
    }
    public void CloseUIStockAndTruck()
    {
        GameManager.instance.canOpenUI = true;
        uiStockAndTruck.SetActive(false);
    }
    public void OpenUIFilterUpgrade()
    {
        GameManager.instance.canOpenUI = true;
        uiFilter.SetActive(true);
    }


}
