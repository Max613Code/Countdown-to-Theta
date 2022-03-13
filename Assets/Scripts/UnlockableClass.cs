using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableClass
{
    public string unlockableName;

    public string[] newUpgrades; //Upgrades that will be created when this is bought

    public string[] upgradeNames; //Which upgrade it is going to affect by changing the equation for calculating the value of the variable
    public string[] newCustomUpgradeEffectNames;
    public string[] newUpgradeTexts;

    public string[] unlockedVariables;

    public string costVariable;
    public int cost { get; set; }
    
    public string unlockableDisplayText { get; set; }

    public UnlockableClass(string unlockableName, string[] newUpgrades, string[] upgradeNames, string[] newCustomUpgradeEffectNames, string[] newUpgradeTexts, string[] unlockedVariables, string costVariable, int cost, string unlockableDisplayText)
    {
        this.unlockableName = unlockableName;
        this.newUpgrades = newUpgrades;
        this.upgradeNames = upgradeNames;
        this.newCustomUpgradeEffectNames = newCustomUpgradeEffectNames;
        this.newUpgradeTexts = newUpgradeTexts;
        this.unlockedVariables = unlockedVariables;
        this.costVariable = costVariable;
        this.cost = cost;
        this.unlockableDisplayText = unlockableDisplayText;
    }
}
