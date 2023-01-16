using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkerController : MonoBehaviour
{
    //SCO
    public Constructor constructor;
    [SerializeField]
    private GameObject testItem;
    //Conveyor 
    public ConveyorController conveyor;
    //UI 
    public GameObject uiPerson;
    //DataCosntructor
    public TextMeshProUGUI ItemName, ItemDescription, CrafteableDescription, textCostWorker, textCostGun;
    public Image ItemSprite, ItemWorker;



    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = constructor.GetSpriteInGame();
        CalculateCostToUpgradeGun();
        CalculateCostUpgrade();
        InvokeRepeating("SpawnItem", constructor.GetTimeToProduce(), constructor.GetTimeToProduce());
    }     

   
    public void SpawnItem() 
    {
        Vector3 itemSpawnPoint = conveyor.conveyorWaypointsList[constructor.GetId()-1].transform.position;
        testItem.GetComponent<SpriteRenderer>().sprite = constructor.GetItem().GetSpriteItem();
        GameObject itemSpawned = Instantiate(testItem, itemSpawnPoint, Quaternion.identity);
        itemSpawned.GetComponent<ItemData>().item = constructor.GetItem();
        StartCoroutine(moveItemConveyor(itemSpawned));
        moveItemConveyor(itemSpawned);
    }

    IEnumerator moveItemConveyor(GameObject item) {
        Transform actualDestination = conveyor.conveyorWaypointsList[constructor.GetId()].transform;
        for (int i = 0; i < 2; i++)
        {
            while (item.transform.position != actualDestination.position)
            {
                item.transform.position = Vector3.MoveTowards(item.transform.position, actualDestination.position, Time.deltaTime * 1);
                yield return null;
            }
            actualDestination = conveyor.conveyorWaypointsList[conveyor.conveyorWaypointsList.Capacity - 1].transform;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    //When Click on GameObject
    public void OnMouseDown()
    {
        if (!uiPerson.activeSelf)
        {
            uiPerson.SetActive(true);
            SetDataUI();
        }
    }

    public void CalculateCostUpgrade() 
    {
        constructor.SetCostToUpgrade(GameManager.instance.CalculeCostToUpgrade(constructor.GetId(), constructor.GetLevel()));
    }
    public void CalculateCostToUpgradeGun()
    {
        constructor.GetItem().SetCostToUpgrade(GameManager.instance.CalculeCostToUpgrade(constructor.GetItem().GetId(), constructor.GetItem().GetLevel()));
    }

    //Set data UI
    /*
     * BackgroundITEM
                ItemName -- Alias
                ItemImage -- WorkerSprite
                ItemDescription -- level, timeToProduce, salario, itemCreado
              //  CrafteableDescription --  AliasItem, SpriteItem, ValueItem, StatsItem
                ButtonUpgrade -- CostUpgrade
                ButtonExit
        */

    public void SetDataUI()
    {
        ItemName.text = constructor.GetAlias();
        ItemWorker.sprite = constructor.GetSpriteWorker();
        ItemDescription.text = "Level: " + constructor.GetLevel() + "\n"
            + "Time to Produce: " + constructor.GetTimeToProduce() + "\n"
            + "Salary: " + constructor.GetSalary() + "\n"
            + "Item: " + constructor.GetItem().GetAlias()+"\n"
            ;
        ItemSprite.sprite = constructor.GetItem().GetSpriteItem();
        CrafteableDescription.text = "Multiplier: " + constructor.GetItem().GetMultiplier()+ "\n"
            + "Value: " + constructor.GetItem().GetValue() + "\n"
            ;
        textCostGun.text = "Cost: " + constructor.GetItem().GetCostToUpgrade();
        textCostWorker.text = "Cost: " + constructor.GetCostToUpgrade();
    }


}
