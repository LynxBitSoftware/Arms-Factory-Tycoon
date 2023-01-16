using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        calculateCostToUpgrade();
    }
    public void calculateCostToUpgrade() 
    {
        GameManager.instance.CalculeCostToUpgrade(this.item.GetId(), this.item.GetLevel());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
