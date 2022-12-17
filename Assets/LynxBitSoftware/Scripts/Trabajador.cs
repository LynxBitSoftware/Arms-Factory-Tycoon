using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trabajador : Person
{
    [SerializeField]
    private int level;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float salary;

    //Setters and Getters
    public void SetLevel(int Level) 
    {
        this.level = Level;
    }
    public void SetSpeed(float Speed) 
    {
        this.speed = Speed;
    }
    public void SetSalary(float Salary)
    {
        this.salary = Salary;
    }
    public int GetLevel()
    {
        return this.level;
    }
    public float GetSpeed()
    {
        return this.speed;
    }
    public float GetSalary() 
    {
        return this.salary;
    }
}
