using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private int doorCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() 
    {
        if (doorCost <= GameManager.instance.currency.GetCurrencyCash()) 
        {
            GameManager.instance.currency.SubstractCurrencyCash(doorCost);
            Debug.Log("I bought a door for: " + doorCost);
            GameManager.instance.ExpandFactory();
            Destroy(this.gameObject);
        }
    }
}
