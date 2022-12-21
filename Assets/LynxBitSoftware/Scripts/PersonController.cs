using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    //SCO
    public Constructor constructor;
    [SerializeField]
    private GameObject testItem;
    //Conveyor 
    public ConveyorController conveyor;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", constructor.GetTimeToProduce(), constructor.GetTimeToProduce());
    }

    public void SpawnItem() 
    {
        Vector3 itemSpawnPoint = conveyor.conveyorWaypointsList[constructor.GetId()-1].transform.position;
        testItem.GetComponent<SpriteRenderer>().sprite = constructor.GetItem().GetSpriteItem();
        GameObject itemSpawned = Instantiate(testItem, itemSpawnPoint, Quaternion.identity);
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
}
