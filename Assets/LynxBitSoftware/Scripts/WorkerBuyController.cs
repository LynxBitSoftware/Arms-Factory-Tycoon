using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBuyController : MonoBehaviour
{
    [SerializeField]
    private int workerCost;
    public UIController ui;
    public GameObject worker;
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
        ui.OpenUIBuyWorker(worker, workerCost, this.gameObject);
       
    }
}
