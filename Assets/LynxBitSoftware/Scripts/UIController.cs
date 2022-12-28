using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField]
    private CurrencyController currency;
    [SerializeField]
    private CarController car;
    [SerializeField]
    private TextMeshProUGUI textCash, textIncomePerMin, textCapacityCar;
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
        textCapacityCar.text = GameManager.instance.itemsStock + " / " + car.GetNumberOfStackableItems();
        textCash.text = GameManager.instance.ConvertValueForUI(currency.GetCurrencyCash()) + "$";
        //textIncomePerMin.text = GameManager.instance.ConvertValueForUI(GameManager.instance.GetIncomePerMin()) + " / min";
    }
}
