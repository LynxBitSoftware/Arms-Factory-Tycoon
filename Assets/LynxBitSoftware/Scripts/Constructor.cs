using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Constructor", menuName = "ScriptableObjects/Constructor", order = 1)]
public class Constructor : Trabajador
{
    [SerializeField]
    private double timeToProduce;
    [SerializeField]
    private Item item;
    [SerializeField]
    private Sprite spriteWorker, gameSprite;

    //Setters and Getters
    public void SetTimeToProduce(double TimeToProduce)
    {
        this.timeToProduce = TimeToProduce;
    }
    public double GetTimeToProduce()
    {
        return this.timeToProduce;

    }
    public void SetItem(Item _item)
    {
        this.item = _item;
    }
    public Item GetItem()
    {
        return this.item;
    }
    public void SetSpriteWorker(Sprite _sprite)
    {
        this.spriteWorker = _sprite;
    }
    public Sprite GetSpriteWorker()
    {
        return this.spriteWorker;
    }

    public Sprite GetSpriteInGame()
    {
        return this.gameSprite;
    }
}
