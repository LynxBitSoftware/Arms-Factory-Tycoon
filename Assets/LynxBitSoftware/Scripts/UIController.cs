using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField]
    private CurrencyController currency;
    [SerializeField]
    private List<CarController> cars;
    [SerializeField]
    private TextMeshProUGUI textCash, textIncomePerMin;
    [SerializeField]
    private List<TextMeshProUGUI> textCapacityCars;
    

    // Start is called before the first frame update
    void Start()
    {
        //textIncomePerMin = GetComponentInChildren<TextMeshProUGUI>()
        //textCash = GetComponentInChildren<TextMeshProUGUI>();
        currency = GetComponent<CurrencyController>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < textCapacityCars.Count; i++) 
        {
            textCapacityCars[i].text = cars[i].GetSizeItemsInCar() + " / " + cars[i].GetNumberOfStackableItems();
        }
        textCash.text = GameManager.instance.ConvertValueForUI(currency.GetCurrencyCash()) + "$";
        //textIncomePerMin.text = GameManager.instance.ConvertValueForUI(GameManager.instance.GetIncomePerMin()) + " / min";
    }

    
}
