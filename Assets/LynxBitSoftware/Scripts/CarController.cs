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
    // Start is called before the first frame update

    public void stackItemOnPile(Item item) 
    {
        itemsToTransport.Add(item);
        GameManager.instance.itemsStock += 1;
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canStack)
        {
            stackItemOnPile(collision.GetComponent<ItemData>().item);
            Destroy(collision.gameObject, 1.5f);
        }
    }

    public void ClearList() 
    {
        itemsToTransport.Clear();
    }

    public float CountItemValue() 
    {
        float totalValue = 0;
        if (itemsToTransport.Count == 100) {
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
        if (itemsToTransport.Count == 100) 
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
