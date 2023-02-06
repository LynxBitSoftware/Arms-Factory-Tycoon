using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    //List of items the car can deposit (max 100 items)
    [SerializeField]
    private List<Item> itemsToTransport;
    [SerializeField]
    public bool canStack;
    public Truck truck;
    public TruckMovement truckMovement;
    public TextMeshProUGUI ItemDescription, textCostUpgradeStock;
    public Image ItemSprite;
    [SerializeField]
    private int numOfItemsStackable;
    // Start is called before the first frame update
    public int GetSizeItemsInCar() 
    {
        return itemsToTransport.Count;
    }
    public void SetNumberOfStackableItems(int maxItem)
    {
        this.numOfItemsStackable = maxItem;
    }
    public int GetNumberOfStackableItems()
    {
        return this.numOfItemsStackable;
    }
    public void stackItemOnPile(List<Item> items) 
    {
        for(int i = 0; i < items.Count; i++)
        {
            itemsToTransport.Add(items[i]);
        }
        GameManager.instance.itemsStock += items.Count;
        //itemsToTransport.Add(item);
        //GameManager.instance.itemsStock += 1;
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canStack)
        {
            stackItemOnPile(collision.GetComponent<Transportist>().itemList);
            collision.GetComponent<Transportist>().itemList.Clear();
            //stackItemOnPile(collision.GetComponent<ItemData>().item);

        }
    }

    public void ClearList() 
    {
        itemsToTransport.Clear();
    }
    public void SetDataUI() 
    {

        ItemSprite.sprite = truck.GetSprite();
        ItemDescription.text = "Level: " + truck.GetLevel() + "\n"
            + "Capacity: " + truck.GetCapacity();
        ;
        textCostUpgradeStock.text = "Cost: " + GameManager.instance.ConvertValueForUI(truck.GetCostToUpgrade()) + " $";
    }
    public void CalculateCostUpgrade() 
    {
        truck.SetCostToUpgrade(GameManager.instance.CalculeCostToUpgrade(truck.GetId(), truck.GetLevel()));
    }
    public double CountItemValue() 
    {
        double totalValue = 0;
        if (itemsToTransport.Count == truck.GetCapacity()) {
            for (int i = 0; i < itemsToTransport.Count; i++)
            {
                totalValue += itemsToTransport[i].GetValue() * itemsToTransport[i].GetMultiplier(); 
            }
            return totalValue;
        }
        return -1;
    }
    // Update is called once per frame
    void Update()
    {
        if (itemsToTransport.Count == numOfItemsStackable) 
        {
            canStack = false;
            GameManager.instance.wins = CountItemValue();
            truckMovement.startAnim = true;
            if(GameManager.instance.wins != -1)
            {
                GameManager.instance.GivePlayerSalary();
            }
            ClearList();
            GameManager.instance.itemsStock = 0;
        }
    }
}
