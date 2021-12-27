using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VariableSO[] variableSos;
    public Dictionary<string, VariableClass> variables = new Dictionary<string, VariableClass>();
    //The String is the name of the variable, easier to access this way.
    
    
    public double totalTime = 0;

    public double deltaX { get; set; }
    public double X { get; set; }
    public double maxX { get; set; }
    public double deltaTheta { get; set; }
    public double Theta { get; set; }
    public double Omega { get; set; }
    void Start()
    {
        Application.targetFrameRate = 60;
        foreach (var variable in variableSos)
        { //Initialize the variable classes into the dictionary
            variables[variable.name] = new VariableClass(variable.name, (double)variable.initialValue);
        }
    }
    
    void Update()
    {
        updateStandardVariables();
    }

    private double deltaXFunction(int tier)
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

    private double deltaThetaFunction(int tier)
    {
        if (tier == 1)
        { //https://www.desmos.com/calculator/oshbwca2nv
            var a = totalTime;//Make code simpler
            return (Math.Pow( 1+Math.Pow(a/10,  2+Math.Log( 1+Math.Pow(a/10,4), Math.E )/10 ), 1+ Math.Sqrt(a/10000)  ))
                /(double)100000;
        }
        else
        {
            Debug.Log("Something went wrong for delta Theta!");
            return -1;
        }
    }

    private void updateStandardVariables()
    {
        //Updating stuff according to the equations.
        totalTime += Time.deltaTime;
        
        deltaX = deltaXFunction(1);
        X += deltaX * Time.deltaTime;
        maxX = Math.Max(X, maxX);
        
        Debug.Log(Theta + " " + totalTime);

        deltaTheta = deltaThetaFunction(1);
        Theta += deltaTheta * Time.deltaTime;
        
        Omega = maxX - Theta;
    }

    public void updateVariable(string varName, double newValue)
    {
        if (variables.ContainsKey(varName))
        {
            if (variables[varName].GetType() == newValue.GetType())
            {
                variables[varName].value = newValue;
            }
        }
    }

    /*private decimal BIMax(decimal x, decimal y)
    {
        if (x > y)
            return x;
        else
            return y;
    }*/ //Not needed as we are not using BigInteger, but decimals now.y
}
