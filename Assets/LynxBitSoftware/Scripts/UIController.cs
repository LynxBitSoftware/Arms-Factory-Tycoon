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
    private TextMeshProUGUI textCash, textIncomePerMin, textGems, textCostWorker, textCostDoor, textCostFilter;
    [SerializeField]
    private List<TextMeshProUGUI> textCapacityCars;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject uiTextCapacityCars;
    [SerializeField]
    private GameObject workerBuyController, filterBuyController, worker, lockDoor, filter;
    [SerializeField]
    private int costToUpgradeWorker, costToBuyDoor, costToBuyFilter;
    //UI 
    public GameObject uiPerson,uiDistribuitor, uiStats, uiBuyWorker, uiBuyDoor, uiBuyFilter, uiFilter;
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
        uiPerson.SetActive(false);
    }
    
    public void CloseUIDistribuitor() 
    {
        uiDistribuitor.SetActive(false);
    }
        
    public void OpenUIStats() 
    {
        uiStats.SetActive(true);
    }
    
    public void CloseUIStats() 
    {
        uiStats.SetActive(false);
    }

    public void OpenUIBuyDoor(int costDoor, GameObject lockDoor)
    {
        textCostDoor.text = "Cost for door: " + costDoor + " $";
        this.lockDoor = lockDoor;
        this.costToBuyDoor = costDoor;
        uiBuyDoor.SetActive(true);
    }

    public void CloseUIBuyDoor()
    {
        uiBuyDoor.SetActive(false);
    }
    public void OpenUIBuyFilter(GameObject _filter, int _filterCost, GameObject button) 
    {
        this.filter = _filter;
        this.filterBuyController = button;
        costToBuyFilter = _filterCost;
        textCostFilter.text = "Cost of new filter: " + GameManager.instance.ConvertValueForUI(costToBuyFilter) + " $";
        uiBuyFilter.SetActive(true);

    }
    public void CloseUIBuyFilter() 
    {
        uiBuyFilter.SetActive(false);
    }
    public void OpenUIBuyWorker(GameObject _worker, int _workerCost, GameObject button)
    {
        this.worker = _worker;
        this.workerBuyController = button;
        costToUpgradeWorker = _workerCost;
        textCostWorker.text = "Cost of new worker: " + GameManager.instance.ConvertValueForUI(costToUpgradeWorker) + " $";
        uiBuyWorker.SetActive(true);
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
        uiBuyWorker.SetActive(false);
    }

    public void CloseUIFilterUpgrade() 
    {
        uiFilter.SetActive(false);
    }
    public void OpenUIFilterUpgrade()
    {
        uiFilter.SetActive(true);
    }


}
