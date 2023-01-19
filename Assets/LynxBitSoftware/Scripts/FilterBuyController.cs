using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterBuyController : MonoBehaviour
{
    [SerializeField]
    private int filterCost;
    public UIController ui;
    public GameObject filter;
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
        ui.OpenUIBuyFilter(filter, filterCost, this.gameObject);

    }
}
