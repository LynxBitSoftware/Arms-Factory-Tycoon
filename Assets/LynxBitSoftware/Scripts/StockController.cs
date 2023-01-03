using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockController : MonoBehaviour
{
    public GameObject transportist;
    public int totalItemStock = 100;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
