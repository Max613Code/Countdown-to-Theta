using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public UpgradeSO[] upgradeSos;
    public Dictionary<String, UpgradeClass> upgrades = new Dictionary<string, UpgradeClass>();

    void Start()
    {
        foreach (var upgrade in upgradeSos)
        {
            if (upgrade.type == "regular")
            {
                upgrades[upgrade.upgradeName] = new UpgradeClass(upgrade.upgradeName, upgrade.variableName,upgrade.costVariable,
                    upgrade.upgradeText, upgrade.upgradeTextFormatVariableName, upgrade.initialCost, upgrade.type,
                    upgrade.rateOfCost,
                    upgrade.rateOfEffect);
                
            }
            else if (upgrade.type == "custom")
                upgrades[upgrade.upgradeName] = new UpgradeClass(upgrade.upgradeName, upgrade.variableName, upgrade.costVariable,
                    upgrade.upgradeText, upgrade.upgradeTextFormatVariableName, upgrade.initialCost,upgrade.type, upgrade.customUpgradeNum);

            Reference.UI.createUpdateT1(upgrades[upgrade.upgradeName]);
            
            
            
        }
    }

    public void purchase(string upgradeName, int amount)
    {
        if (upgrades.ContainsKey(upgradeName) == false) //Don't want to get a null reference error and be confused.
        {
            Debug.Log("Upgrade dictionary does not contain the upgrade you are trying to buy!");
        }
        var upgrade = upgrades[upgradeName];

        if (upgrade.upgradeType == "regular")
        {
            if (Reference.GM.variables[upgrade.costVariable].value >= upgrade.cost) //Check if we can even afford the upgrade
            {
                Reference.GM.variables[upgrade.costVariable].value -= upgrade.cost;
                
                updateVariableLevel(Reference.GM.variables[upgrade.costVariable],1);
                
                upgrade.cost *= upgrade.rateOfCost;
                Reference.GM.variables[upgrade.variableName].value *= upgrade.rateOfEffect; //Just updating the regular stuff
                
                Reference.UI.updateUpgradeText(upgradeName);

            }
        } 
        else if (upgrade.upgradeType == "custom")
        {
            if (Reference.GM.variables[upgrade.costVariable].value >= upgrade.cost) //Check if we can even afford the upgrade
            {
                Reference.GM.variables[upgrade.costVariable].value -= upgrade.cost;
                
                updateVariableLevel(Reference.GM.variables[upgrade.variableName],1);
               
                upgrade.cost *= 1.4; //Can change this sometime later to be maybe a custom function
                Reference.GM.variables[upgrade.variableName].value = customUpgradeFunction(Reference.GM.variables[upgrade.variableName], upgrade.customUpgradeNum); //Just updating the regular stuff
                
                Reference.UI.updateUpgradeText(upgradeName);

            }
        }
    }
    
    public double customUpgradeFunction(VariableClass var, int whichCustom)
    {
        
        //Debug.Log(var.name + " " + whichCustom);
        if (var.name == "b0V1" && whichCustom == 1) //Best way i could think of for having custom upgrade functions, 
        {
            Debug.Log(var.value + var.level * var.level / 10 + " " + var.level);
            return var.value + (double)var.level * (double)var.level/10;
        }
        else
        {
            Debug.Log("Custom upgrade function not found!");
        }

        return 0;
    }

    public double customCostFunc(VariableClass var, int whichCustom)
    {
        //To be implemented
        return 0;
    }

    public void updateVariableLevel(VariableClass var, int amount)
    {
        var.level += amount;
        var.purchasedLevel += amount;
    }
}
