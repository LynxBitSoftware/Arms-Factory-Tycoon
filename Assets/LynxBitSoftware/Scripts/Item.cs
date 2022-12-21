using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemWorker", menuName = "ScriptableObjects/Item (Worker)", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string alias;
    [SerializeField]
    private Sprite spriteItem;
    [SerializeField]
    private int level;
    [SerializeField]
    private int value;

    //Getters and Setters
    public int GetId() 
    {
        return this.id;
    }
    public string GetAlias()
    {
        return this.alias;
    }
    public Sprite GetSpriteItem()
    {
        return this.spriteItem;
    }
    public int GetLevel()
    {
        return this.level;
    }
    public int GetValue()
    {
        return this.value;
    }
    public void SetId(int ID) 
    {
        this.id = ID;
    }
    public void SetAlias(string Alias)
    {
        this.alias = Alias;
    }
    public void SetSpriteItem(Sprite SpriteItem)
    {
        this.spriteItem = SpriteItem;
    }
    public void SetLevel(int Level)
    {
        this.level = Level;
    }
    public void SetValue(int Value)
    {
        this.value = Value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
