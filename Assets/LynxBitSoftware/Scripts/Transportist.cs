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
    [SerializeField]
    private int numOfItemsStackable;
    //UI 
    public GameObject uiPerson;
    //DataCosntructor
    public TextMeshProUGUI ItemName, ItemDescription, ButtonUpgradeable;
    public Image ItemSprite;

    // Start is called before the first frame update
    public void SetNumberOfStackableItems(int maxItem)
    {
        this.numOfItemsStackable = maxItem;
    }
    public int GetNumberOfStackableItems()
    {
        return this.numOfItemsStackable;
    }
    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;
        CalculateCostUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfItemsStackable == itemList.Count && canPickUpItem) {
            canPickUpItem = false;
            //Start giving item to car
            DistributeItems();
        }
        if (itemList.Count > numOfItemsStackable) 
        {
            DeleteItemsTransportistShouldNotHave();
        }
    }
    public void DeleteItemsTransportistShouldNotHave() 
    {
        itemList.RemoveRange(numOfItemsStackable, itemList.Count - numOfItemsStackable);
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
            for(int i = 0; i < numOfItemsStackable; i++) 
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
            ;
    }
}
