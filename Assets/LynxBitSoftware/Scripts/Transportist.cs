using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Transportist : MonoBehaviour
{
    public Distribuidor distribuidor;
    public StockController stock;
    public List<Item> itemList;
    public List<CarController> cars;
    public bool canPickUpItem = true;
    public Vector3 initPos;
    //UI 
    public GameObject uiPerson;
    
    public Slider slider;
    //DataCosntructor
    public TextMeshProUGUI ItemName, ItemDescription, textCostUpgradeTransportist;
    public Image ItemSprite;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = distribuidor.GetnumOfItemsStackable();
        initPos = this.transform.position;
        CalculateCostUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = itemList.Count;

        if (distribuidor.GetnumOfItemsStackable() == itemList.Count && canPickUpItem) {
            canPickUpItem = false;
            //Start giving item to car
            DistributeItems();
        }
        if (itemList.Count > distribuidor.GetnumOfItemsStackable()) 
        {
            DeleteItemsTransportistShouldNotHave();
        }

    }
    public void DeleteItemsTransportistShouldNotHave() 
    {
        itemList.RemoveRange(distribuidor.GetnumOfItemsStackable(), itemList.Count - distribuidor.GetnumOfItemsStackable());
    }
    public void DistributeItems() 
    {
        checkForAvaliableTruck();
    }
    public void checkForAvaliableTruck() 
    {
        for (int i = 0; i < cars.Count; i++) 
        {
            if (cars[i].canStack && itemList.Count > 0) 
            {
                StartCoroutine(SetDestination(cars[i].gameObject.transform.transform.position));
                break;
            }
        }
        //If there're no cars avaliable should wait 1s and look again for avaliable trucks
    }
    public IEnumerator SetDestination(Vector3 destination)
    {
        while (this.gameObject.transform.position != destination)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination, Time.deltaTime * distribuidor.GetSpeed());
            yield return null;
        }
        StartCoroutine(ReturnToInitPos());
    }
    IEnumerator ReturnToInitPos() 
    {
        while (this.gameObject.transform.position != initPos)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, initPos, Time.deltaTime * distribuidor.GetSpeed());
            yield return null;
        }
        canPickUpItem = true;
        checkForAvaliableStock();
        yield return new WaitForSeconds(2f);
    }
    public void CalculateCostUpgrade()
    {
        distribuidor.SetCostToUpgrade(GameManager.instance.CalculeCostToUpgrade(distribuidor.GetId(), distribuidor.GetLevel()));
    }
    public void checkForAvaliableStock() 
    {
        if (stock.GetItemsList().Count > 0) 
        { 
            for(int i = 0; i < distribuidor.GetnumOfItemsStackable(); i++) 
            {
                if (stock.GetItemInStockPos(0) == null) { break; }
                //if (i < stock.GetItemsList().Count)
                //{
                    itemList.Add(stock.GetItemInStockPos(0));
                    stock.DeleteItemOnList(0);
               // }
            }
        }
    }

    public void ClearList()
    {
        itemList.Clear();
    }

    //When Click on GameObject
    public void OnMouseDown()
    {
        if (!uiPerson.activeSelf)
        {
            GameManager.instance.canOpenUI = false;
            GameManager.instance.transportistToUpgrade = this.gameObject.GetComponent<Transportist>();
            uiPerson.SetActive(true);
            SetDataUI();
        }
    }

    public void SetDataUI()
    {
        ItemName.text = distribuidor.GetAlias();
        ItemSprite.sprite = distribuidor.GetSpriteWorker();
        ItemDescription.text = "Level: " + distribuidor.GetLevel() + "\n"
            + "Salary: " + distribuidor.GetSalary() + "\n"
            + "Capacity: " + distribuidor.GetnumOfItemsStackable();
            ;
        textCostUpgradeTransportist.text = "Cost: " + GameManager.instance.ConvertValueForUI(distribuidor.GetCostToUpgrade()) + " $";
    }

    
}
