using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
                    upgrade.upgradeText, upgrade.upgradeTextFormatVariableName, upgrade.initialCost,upgrade.type, upgrade.customUpgradeEffectName, upgrade.customUpgradeCostName);

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
                
                Reference.GM.variables[upgrade.variableName].value = customUpgradeFunction(Reference.GM.variables[upgrade.variableName], upgrade, upgrade.customUpgradeEffectName); //Just updating the regular stuff
                upgrade.cost = customCostFunction(Reference.GM.variables[upgrade.variableName], upgrade,
                    upgrade.customUpgradeCostName);
                //Use the custom functions to set the referenced variable and the cost of the upgrade.
                
                Reference.UI.updateUpgradeText(upgradeName);

            }
        }
    }
    
    
    
    public double customUpgradeFunction(VariableClass var, UpgradeClass upgrade, string whichCustom)
    {
        //Debug.Log(var.name + " " + whichCustom);
        if (var.name == "b0V1" && whichCustom == "b0V1 additive square") //Best way i could think of for having custom upgrade functions, 
        {
            return var.value + (double)var.level * (double)var.level/10;
        }
        else
        {
            Debug.Log("Custom upgrade function not found!");
        }

        return 0;
    }

    public double customCostFunction(VariableClass var, UpgradeClass upgrade, string whichCustom)
    {
        Debug.Log(whichCustom);
        if (var.name == "b0V1" && whichCustom == "b0V1 lowering cost") //Best way i could think of for having custom cost functions, 
        {
            return upgrade.cost *= 1.2 + Math.Min(0.2 / (var.level / 10), 0.2);//Cost goes from 1.4 to 1.2
        }
        else
        {
            Debug.Log("Custom upgrade function not found!");
        }

        return 0;
    }

    public void updateVariableLevel(VariableClass var, int amount)
    {
        var.level += amount;
        var.purchasedLevel += amount;
    }
}
