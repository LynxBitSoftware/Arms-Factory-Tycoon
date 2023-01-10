using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string alias;
    [SerializeField]
    private float costToUpgrade;

    //Setters and getters
    public void SetId(int Id)
    {
        if (Id == 0) { return; }
        this.id = Id;
    }
    public void SetAlias(string Alias)
    {
        if (Alias == null) { return; }
        this.alias = Alias;
    }

    public void SetCostToUpgrade(float cost) 
    {
        if (this.costToUpgrade < cost) 
        {
            this.costToUpgrade = cost;
        }
    }

    public int GetId()
    {
        return this.id;
    }

    public float GetCostToUpgrade() 
    {
        return this.costToUpgrade;
    }
    public string GetAlias()
    {
        return this.alias;
    }
}
