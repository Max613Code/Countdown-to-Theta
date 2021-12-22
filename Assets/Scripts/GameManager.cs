using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VariableSO[] variableSos;
    public Dictionary<string, VariableClass> variables = new Dictionary<string, VariableClass>();
    //The String is the name of the variable, easier to access this way.
    
    
    public decimal totalTime = 0;

    public decimal deltaX { get; set; }
    public decimal X { get; set; }
    public decimal maxX { get; set; }
    public decimal deltaTheta { get; set; }
    public decimal Theta { get; set; }
    public decimal Omega { get; set; }
    void Start()
    {
        Application.targetFrameRate = 60;
        foreach (var variable in variableSos)
        { //Initialize the variable classes into the dictionary
            variables[variable.name] = new VariableClass(variable.name, (decimal)variable.initialValue);
        }
    }
    
    void Update()
    { //Updating stuff according to the equations.
        totalTime += (decimal) Time.deltaTime;
        
        deltaX = deltaXFunction(1);
        X += deltaX;
        maxX = Math.Max(X, maxX);
        
        deltaTheta = 
        
        Omega = maxX - Theta;
    }

    private decimal deltaXFunction(int tier)
    {
        if (tier == 1 && variables.ContainsKey("a0V1")) //Check if the dictionary has this variable.
        {
            return variables["a0V1"].value * totalTime;
        }
        else
        {
            Debug.Log("No valid function or variable missing!");
            return -1;
        }
    }

    private decimal deltaThetaFunction()
    {
        return 0;
    }

    /*private decimal BIMax(decimal x, decimal y)
    {
        if (x > y)
            return x;
        else
            return y;
    }*/ //Not needed as we are not using BigInteger, but decimals now.
}
