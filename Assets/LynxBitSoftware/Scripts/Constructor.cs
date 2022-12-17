using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Constructor", menuName = "ScriptableObjects/Constructor", order = 1)]
public class Constructor : Trabajador
{
    [SerializeField]
    private float timeToProduce;

    //Setters and Getters
    public void SetTimeToProduce(float TimeToProduce)
    {
        this.timeToProduce = TimeToProduce;
    }
    public float GetTimeToProduce() 
    {
        return this.timeToProduce;
    }
}
