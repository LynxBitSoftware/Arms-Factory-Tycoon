using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //List of items the car can deposit (max 100 items)
    [SerializeField]
    private List<Item> itemsToTransport;
    [SerializeField]
    private bool canStack;
    [SerializeField]
    private int numOfItemsStackable;
    // Start is called before the first frame update
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
            //stackItemOnPile(collision.GetComponent<ItemData>().item);
            
        }
    }

    public void ClearList() 
    {
        itemsToTransport.Clear();
    }

    public float CountItemValue() 
    {
        float totalValue = 0;
        if (itemsToTransport.Count == numOfItemsStackable) {
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
            GameManager.instance.wins = CountItemValue();
            if(GameManager.instance.wins != -1)
            {
                GameManager.instance.GivePlayerSalary();
            }
            ClearList();
            GameManager.instance.itemsStock = 0;
        }
    }
}
