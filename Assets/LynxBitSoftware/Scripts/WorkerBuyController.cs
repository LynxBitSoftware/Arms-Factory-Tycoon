using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBuyController : MonoBehaviour
{
    [SerializeField]
    private int workerCost;
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
        if (workerCost <= GameManager.instance.currency.GetCurrencyCash())
        {
            GameManager.instance.currency.SubstractCurrencyCash(workerCost);
            Debug.Log("I bought a worker for: " + workerCost);
            worker.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
