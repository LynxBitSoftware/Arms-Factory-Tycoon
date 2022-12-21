using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    //Idea is: Move the item the worker created by checkpoints going in this order with every row -> SpawnPos, FinishPos, EndOfConveyorPos
    [SerializeField]
    public List<GameObject> conveyorWaypointsList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
