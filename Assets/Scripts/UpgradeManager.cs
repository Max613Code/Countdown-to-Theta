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
}
