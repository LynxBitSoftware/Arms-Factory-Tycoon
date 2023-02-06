using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StockController : MonoBehaviour
{
    public GameObject transportist;
    public Stock stock;
    public int totalItemStock;
    public TextMeshProUGUI ItemDescription, textCostUpgradeStock;
    public Image ItemSprite;
    [SerializeField]
    private List<Item> itemsToStock;
    public void SetNumberOfTotalItems(int maxItem)
    {
        this.totalItemStock = maxItem;
    }
    public int GetNumberOfTotalItems()
    {
        return this.totalItemStock;
    }
    public List<Item> GetItemsList() 
    {
        return this.itemsToStock;
    }
    public Item GetItemInStockPos(int id) 
    {
        if(id < itemsToStock.Count)
        {
            return this.itemsToStock[id];
        }
        return null;
    }
    public void DeleteItemOnList(int id) 
    {
        itemsToStock.RemoveAt(id);
    }
    // Start is called before the first frame update
    void Start()
    {
        totalItemStock = stock.GetCapacity();
    }

    // Update is called once per frame
    void Update()
    {
        totalItemStock = stock.GetCapacity();
    }
    public void CalculateCostUpgrade() 
    {
        stock.SetCostToUpgrade(GameManager.instance.CalculeCostToUpgrade(stock.GetId(), stock.GetLevel()));
    }
    public void SetDataUI() 
    {
        
        ItemSprite.sprite = stock.GetSprite();
        ItemDescription.text = "Level: " + stock.GetLevel() + "\n"
            + "Capacity: " + stock.GetCapacity();
        ;
        textCostUpgradeStock.text = "Cost: " + GameManager.instance.ConvertValueForUI(stock.GetCostToUpgrade()) + " $";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Worker"))
        {
            if (transportist.GetComponent<Transportist>().canPickUpItem == true)
            {
                transportist.GetComponent<Transportist>().itemList.Add(collision.GetComponent<ItemData>().item);
            }
            else if (GetNumberOfTotalItems() > itemsToStock.Count)
            {
                itemsToStock.Add(collision.GetComponent<ItemData>().item);
            }
            Destroy(collision.gameObject, 1f);
        }
    }
}
