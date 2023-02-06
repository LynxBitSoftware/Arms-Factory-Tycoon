using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stock", menuName = "ScriptableObjects/Stock", order = 1)]
public class Stock : ScriptableObject
{
    
    [SerializeField]
    private int level;
    [SerializeField]
    private int capacity;
    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite spriteStock;
    [SerializeField]
    private float costToUpgrade;

    public Sprite GetSprite()
    {
        return this.spriteStock;
    }
    public int GetLevel()
    {
        return this.level;
    }
    public int GetId()
    {
        return this.id;
    }
    public int GetCapacity()
    {
        return this.capacity;
    }
    public void SetLevel(int _level)
    {
        this.level = _level;
    }
    public void SetId(int _id)
    {
        this.id = _id;
    }
    public void SetSprite(Sprite _sprite)
    {
        this.spriteStock = _sprite;
    }
    public void SetCapacity(int _capacity)
    {
        this.capacity = _capacity;
    }
    public float GetCostToUpgrade()
    {
        return this.costToUpgrade;
    }
    public void SetCostToUpgrade(float cost)
    {
        if (this.costToUpgrade < cost)
        {
            this.costToUpgrade = cost;
        }
    }
}
