using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private CurrencyController currency;
    [SerializeField]
    private List<CarController> cars;
    [SerializeField]
    private TextMeshProUGUI textCash, textIncomePerMin, textGems;
    [SerializeField]
    private List<TextMeshProUGUI> textCapacityCars;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject uiTextCapacityCars;
    //UI 
    public GameObject uiPerson,uiDistribuitor, uiStats;
    public TextMeshProUGUI ItemName;
    public List<Constructor> list_constructor;
    public List<TextMeshProUGUI> list_ItemDescription;
    public List<Image> list_ItemImage;
    



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
        ShowUITextCapacityCars();
        SetUIDATA();
        for (int i = 0; i < textCapacityCars.Count; i++) 
        {
            textCapacityCars[i].text = cars[i].GetSizeItemsInCar() + " / " + cars[i].GetNumberOfStackableItems();
        }
        textCash.text = GameManager.instance.ConvertValueForUI(currency.GetCurrencyCash()) + "$";
        textGems.text = currency.GetCurrencyGems().ToString();
        //textIncomePerMin.text = GameManager.instance.ConvertValueForUI(GameManager.instance.GetIncomePerMin()) + " / min";
    }

    public void SetUIDATA()
    {
        ItemName.text = "statistics";
        for (int i = 0; i < list_constructor.Capacity; i++)
        {
            Constructor constructor = list_constructor[i];
            list_ItemDescription[i].text = "Weapon: " + constructor.GetItem().GetAlias() + "\n"+
                "Level: " + constructor.GetItem().GetLevel() + "\n"
                        + "Time to Produce: " + constructor.GetTimeToProduce() + "\n"
                        + "Salary: " + constructor.GetSalary() + "\n"
                        ;
            list_ItemImage[i].sprite = constructor.GetItem().GetSpriteItem();


        }
        


    }

    void ShowUITextCapacityCars() 
    {
        if (camera.transform.position.x <= -7.5f)
        {
            uiTextCapacityCars.SetActive(true);
        }
        else
        {
            uiTextCapacityCars.SetActive(false);
        }
    }

    public void CloseUIPerson() 
    {
        uiPerson.SetActive(false);
    }
    
    public void CloseUIDistribuitor() 
    {
        uiDistribuitor.SetActive(false);
    }
        
    public void OpenUIStats() 
    {
        uiStats.SetActive(true);
    }
    
    public void CloseUIStats() 
    {
        uiStats.SetActive(false);
    }

    
}
