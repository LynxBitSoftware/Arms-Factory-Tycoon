using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Distribuidor", menuName = "ScriptableObjects/Distribuidor", order = 2)]
public class Distribuidor : Trabajador
{
    [SerializeField]
    private float timeToTransport;
    [SerializeField]
    private Sprite spriteWorker;

    //Setters and Getters
    public void SetTimeToTransport(float TimeToTransport)
    {
        this.timeToTransport = TimeToTransport;
    }
    public float GetTimeToTransport()
    {
        return this.timeToTransport;
    }
    public void SetSpriteWorker(Sprite _sprite)
    {
        this.spriteWorker = _sprite;
    }
    public Sprite GetSpriteWorker()
    {
        return this.spriteWorker;
    }
}
