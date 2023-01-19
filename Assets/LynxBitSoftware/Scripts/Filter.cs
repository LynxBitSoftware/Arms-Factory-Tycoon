using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Filter", menuName = "ScriptableObjects/Filter", order = 1)]
public class Filter : ScriptableObject
{
    [SerializeField]
    private int level;
    [SerializeField]
    private double multiplier;
    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite spriteFilter;
    [SerializeField]
    private float costToUpgrade;

    public Sprite GetSprite() 
    {
        return this.spriteFilter;
    }
    public int GetLevel() 
    {
        return this.level;
    }
    public int GetId() 
    {
        return this.id;
    }
    public double GetMultiplier() 
    {
        return this.multiplier;
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
        this.spriteFilter = _sprite;
    }
    public void SetMultiplier(double _multiplier) 
    {
        this.multiplier = _multiplier;
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
