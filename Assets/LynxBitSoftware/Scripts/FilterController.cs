using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterController : MonoBehaviour
{
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private int level;
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
        if (collision.GetComponent<ItemData>().item.GetMultiplier() != multiplier)
        {
            collision.GetComponent<ItemData>().item.SetMultiplier(multiplier);
        }
    }
}
