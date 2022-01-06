using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Standard variables like x and theta, not the variableClass.
    public Text variableDisplay;
    public RectTransform variableDisplayPanel;
    public Dictionary<string, Text> variableDisplayDictionary = new Dictionary<string, Text>(); //Dictionary of the varName to the text that displays it.  

    public UpgradeT1DisplayScript upgradeT1Display; 
    public RectTransform upgradeT1DisplayPanel;
    public Dictionary<string, UpgradeT1DisplayScript> upgradeDisplayDictionary = new Dictionary<string, UpgradeT1DisplayScript>(); //Makes it easier to set textvalues, still conatins prefab

    public void createUpdateT1(UpgradeClass upgrade) //Kind of same thing
    {
        var e = Instantiate(upgradeT1Display);
Debug.Log(upgrade.variableName);
        e.VariableUpgradeDisplay =
            String.Format(upgrade.upgradeTextFormat, Reference.GM.variables[upgrade.variableName]);
        e.CostUpgradeDisplay = upgrade.cost + Reference.GM.variables[upgrade.costVariable].displaySymbol;
        
        e.transform.SetParent(
            upgradeT1DisplayPanel,
            worldPositionStays:false);

        upgradeDisplayDictionary[upgrade.upgradeName] = e;
    }

    public void createVariableDisplayText(string varName, string displayString) //displayString already contains the variable value, formatted in GM
    {
        var e = Instantiate(variableDisplay);

        e.text = displayString;
        
        e.transform.SetParent(
            variableDisplayPanel,
            worldPositionStays:false);

        variableDisplayDictionary[varName] = e;
    }

    public void updateVariabeDisplayText(string varName, string newDisplayString)
    {
        if (variableDisplayDictionary.ContainsKey(varName))
        {
            variableDisplayDictionary[varName].text = newDisplayString;
        }
        else
        {
            Debug.Log("Cannot update variable text, the referenced text does not exist in the dictionary!");
        }
    }
}
