using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VariableSO[] variableSos;
    public Dictionary<string, VariableClass> variables = new Dictionary<string, VariableClass>();
    //The String is the name of the variable, easier to access this way.

    /*public double totalTime = 0;

    public double deltaX { get; set; }
    public double X { get; set; }
    public double maxX { get; set; }
    public double deltaTheta { get; set; }
    public double Theta { get; set; }
    public double Omega { get; set; }*/

    private List<VariableClass> standardDisplayVariablesToUpdate = new List<VariableClass>();

    private List<int> terms = new List<int>();
    
    
    //Graph:
    [Header("Graph")] public int graphQuality;
    
    private List<double> omegaHistory = new List<double>();
    private int graphCount = 0;
    private double graphScale = 0;
    
    
    void Start()
    {
        Reference.find();//Important, or else null exception error, have to actually find the scripts
        
        Application.targetFrameRate = 60;
        foreach (var variable in variableSos)
        { //Initialize the variable classes into the dictionary
            variables[variable.name] = new VariableClass(variable.name, (double)variable.initialValue, variable.displaySymbol);

            if (variable.hasSpecialUpdatedText) //Will update the variable on the text above the upgrade stuff.
            {
                standardDisplayVariablesToUpdate.Add(variables[variable.name]);
            }
        }

        createDisplayVariables(standardDisplayVariablesToUpdate);
        
        terms.Add(1); //At first only have the ax term
        
        initializeOmegaHistory();
        Reference.GraphScript.createPoints(omegaHistory, graphQuality);

    }
    
    void Update()
    {
        updateStandardVariables();
        updateDisplayVariables(standardDisplayVariablesToUpdate);
        updateHistoryAndGraph();
        
    }

    private double deltaXFunction(List<int> terms) //Easiser than having a bunch of cases, specify which terms 1,2,3,4... in the arraylist to have it added here. 
    {
        double result = 0;
        if (terms.Contains(1) && variables.ContainsKey("a0V1")) //Check if the dictionary has this variable.
        {
            result += variables["a0V1"].value * variables["totalTimeV0"].value;
        }

        if (terms.Contains(2) && variables.ContainsKey("b0V1"))
        {
            result += variables["b0V1"].value;
        }

        return result;
    }

    private double deltaThetaFunction(int tier)
    {
        if (tier == 1)
        { //https://www.desmos.com/calculator/oshbwca2nv
            var a = variables["totalTimeV0"].value;//Make code simpler
            return (Math.Pow( 1+Math.Pow(a/10,  2+Math.Log( 1+Math.Pow(a/10,4), Math.E )/10 ), 1+ Math.Sqrt(a/10000)  ))
                /(double)10000;
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
        variables["totalTimeV0"].value += Time.deltaTime; //This stuff should already be instantiated, or else something is wrong
        
        variables["deltaXV0"].value = deltaXFunction(terms);
        variables["XV0"].value += variables["deltaXV0"].value * Time.deltaTime;
        variables["maxXV0"].value = Math.Max(variables["XV0"].value, variables["maxXV0"].value);
        
        //Debug.Log(Theta + " " + totalTime);

        variables["deltaThetaV0"].value = deltaThetaFunction(1);
        variables["ThetaV0"].value += variables["deltaThetaV0"].value * Time.deltaTime;

        variables["OmegaV0"].value = variables["maxXV0"].value - variables["ThetaV0"].value;
    }

    public void updateVariable(string varName, double newValue)
    {
        if (variables.ContainsKey(varName))  //Just update a variable with a new value
        {
            if (variables[varName].GetType() == newValue.GetType())
            {
                variables[varName].value = newValue;
            }
        }
    }
    //Updating the UI that shows like x = 1233.3

    public void createDisplayVariables(List<VariableClass> variables) //Eg x, or the symbol theta
    {
        for (int i=0;i<variables.Count-1;i++) //Create text object for each variable to be displayed like x, theta, omega, time
        {
            Reference.UI.createVariableDisplayText(variables[i].name, variables[i].displaySymbol + String.Format(" = {0}", variables[i].getFormatted()));
        }
    }

    public void updateDisplayVariables(List<VariableClass> variables)
    {
        for (int i=0;i<variables.Count-1;i++) //Create text object for each variable to be displayed like x, theta, omega, time
        {
            Reference.UI.updateVariabeDisplayText(variables[i].name, variables[i].displaySymbol + String.Format(" = {0}", variables[i].getFormatted()));
        }
    }
    
    
    
    //Graph stuff
    public void initializeOmegaHistory()
    {
        for (int _ = 0; _< graphQuality;_++)
        {
            omegaHistory.Add(0);
        }
    }
    public void updateHistoryAndGraph()
    {
        //Debug.Log(omegaHistory.Count);
        if (graphCount == 0)
        {
            for (int i = omegaHistory.Count-1; i > 0; i--)
            {
                omegaHistory[i] = omegaHistory[i-1];
            }

            omegaHistory[0] = variables["OmegaV0"].value;
            Reference.GraphScript.updatePoints(omegaHistory, getGraphScale());
        }

        graphCount = (graphCount + 1) % 10;
    }

    public double getGraphScale() //We divide the height by this value in the graph script, make sure does not overflow and yeah.
    {
        var temp = Reference.GraphScript.graphPanel.transform as RectTransform;
        var height = temp.sizeDelta.y; //Get height of the graph panel
        if (variables["OmegaV0"].value < height)
        {
            return 1;
        }
        else
        {
            
            graphScale = Math.Max(Math.Max(omegaHistory[0] / (height), graphScale),0.001); //This works I guess, if the value goesdown then the scale does not change.
            return graphScale;
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
