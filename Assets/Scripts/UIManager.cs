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

    public UnlockableDisplayScript unlockableDisplay;
    public RectTransform unlockableDisplayPanel;
    
    public void createUpdateT1(UpgradeClass upgrade) //Kind of same thing
    {
        var e = Instantiate(upgradeT1Display);
//Debug.Log(upgrade.variableName);
        e.VariableUpgradeDisplay =
            String.Format(upgrade.upgradeText, Reference.GM.variables[upgrade.upgradeTextFormat].getFormatted(true)); //Creates the text that also displays the value of the variable
        e.CostUpgradeDisplay = Math.Round(upgrade.cost, 3).ToString("0.000") + Reference.GM.variables[upgrade.costVariable].displaySymbol;
        
        e.transform.SetParent(
            upgradeT1DisplayPanel,
            worldPositionStays:false);

        e.upgradeName = upgrade.upgradeName;

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

    public void updateUpgradeText(string upgradeName) //Update the stuff and like the text for the variable
    {
        var e = upgradeDisplayDictionary[upgradeName];
        var upgrade = Reference.UM.upgrades[upgradeName];
        e.VariableUpgradeDisplay =
            String.Format(upgrade.upgradeText, Reference.GM.variables[upgrade.upgradeTextFormat].getFormatted(true)); //Creates the text that also displays the value of the variable
        e.CostUpgradeDisplay = Math.Round(upgrade.cost, 3).ToString("0.000") + Reference.GM.variables[upgrade.costVariable].displaySymbol; //Formatting also borrowed from the var class
    }



    public void createUnlockable(UnlockableClass unlockable)
    {
        var e = Instantiate(unlockableDisplay);
        e.toUnlockUpgradeDisplay = unlockable.unlockableDisplayText;
        e.CostUpgradeDisplay = Math.Round((double)unlockable.cost, 3).ToString("0.000") + Reference.GM.variables[unlockable.costVariable].displaySymbol;
        
        e.transform.SetParent(
            unlockableDisplayPanel,
            worldPositionStays:false);

        e.unlockableName = unlockable.unlockableName;
    }
}
