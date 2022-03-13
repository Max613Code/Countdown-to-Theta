using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableManager : MonoBehaviour
{
    public UnlockableSO[] unlockableSos;
    public Dictionary<String, UnlockableClass> unlockables = new Dictionary<string, UnlockableClass>();

    void Start()
    {
        foreach (var unlockable in unlockableSos)
        {
            unlockables[unlockable.name] = new UnlockableClass(unlockable.unlockableName, unlockable.newUpgrades, unlockable.upgradeNames,
                unlockable.newCustomUpgradeEffectNames, unlockable.newUpgradeTexts, unlockable.unlockedVariables,
                unlockable.costVariable, unlockable.cost, unlockable.unlockableDisplayText);
            
            Reference.UI.createUnlockable(unlockables[unlockable.name]);
        }
    }

    public bool purchase(string unlockableName)
    {
        if (unlockables.ContainsKey(unlockableName) == false)
        {
            Debug.Log("Unlockable Dictionary does not contain the unlockable you are trying to buy!");
            return false; //Will destroy if this returns truye for the unlockable actual object
        }

        var unlockable = unlockables[unlockableName];

        if (Reference.GM.variables[unlockable.costVariable].value >= unlockable.cost)
        {
            Reference.GM.variables[unlockable.costVariable].value -= unlockable.cost;

            for (int i = 0; i < unlockable.newUpgrades.Length; i++)
            {
                Reference.UM.enable(Reference.UM.upgrades[unlockable.newUpgrades[i]]); //Enable the upgrade we are adding and make it
            }
            
            for (int i = 0; i < unlockable.upgradeNames.Length; i++)
            {
                var upgrade = Reference.UM.upgrades[unlockable.upgradeNames[i]];
                upgrade.customUpgradeEffectName = unlockable.newCustomUpgradeEffectNames[i];
                upgrade.upgradeText = unlockable.newUpgradeTexts[i];
            }
            
            for (int i = 0; i < unlockable.unlockedVariables.Length; i++)
            {
                Reference.GM.variables[unlockable.unlockedVariables[i]].enabled = true;
            }
        }

        return true;
    }
}
