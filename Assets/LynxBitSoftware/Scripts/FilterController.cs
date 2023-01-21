using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FilterController : MonoBehaviour
{
    [SerializeField]
    public Filter filter;
    [SerializeField]
    public GameObject uiFilter;
    [SerializeField]
    private TextMeshProUGUI textCostFilter, filterDescription;
    [SerializeField]
    private Image filterSprite;
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
        if (collision.GetComponent<ItemData>().item.GetMultiplier() != filter.GetMultiplier())
        {
            collision.GetComponent<ItemData>().item.SetMultiplier(filter.GetMultiplier());
        }
    }
    public void OnMouseDown()
    {
        if (!uiFilter.activeSelf)
        {
            GameManager.instance.canOpenUI = false;
            GameManager.instance.filterToUpgrade = this.GetComponent<FilterController>();
            CalculateCostUpgrade();
            uiFilter.SetActive(true);
            SetDataUI();
        }
    }
    public void SetDataUI()
    {
        filterSprite.sprite = filter.GetSprite();        
        filterDescription.text = "Level: " + filter.GetLevel() + "\n"
            + "Multiplier: " + filter.GetMultiplier() + "\n";
       
        textCostFilter.text = "Cost: " + GameManager.instance.ConvertValueForUI(filter.GetCostToUpgrade());
       
    }

    public void CalculateCostUpgrade()
    {
        filter.SetCostToUpgrade(GameManager.instance.CalculeCostToUpgrade(filter.GetId(), filter.GetLevel()));
    }

}
