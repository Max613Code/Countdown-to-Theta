using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UpgradeClass  //Need to update cost, cost impacted variable, levels and stuff, and impacted level.
{

    public string upgradeName { get; set; }
    
    public bool enabled { get; set; } //if we should make it at the start
    public string variableName { get; set; } //Which variable this upgrade is referencing.
    public string upgradeText { get; set; }
    public string upgradeTextFormat { get; set; } //upgradeText has {0} which would be replaced by the variable it is referencing.
    public string costVariable { get; set; } //Name of which variable it costs 
    public double cost { get; set; } 
    public double initialCost { get; set; }

    public string upgradeType { get; set; }
    
    //Regular
    public double rateOfCost { get; set; }
    public double rateOfEffect { get; set; }
    
    //Custom
    public string customUpgradeEffectName { get; set; } //Which custom functoni from that function it uses.                                                 
    public string customUpgradeCostName { get; set; }//Which cost function it uses, regular for just the regular rateOfCost one.

    public UpgradeClass([NotNull] string upgradeName, [NotNull] bool enabled, [NotNull] string variableName, [NotNull] string costVariable, [NotNull] string upgradeText,
        [NotNull] string upgradeTextFormat, double initialCost, [NotNull] string upgradeType, double rateOfCost, double rateOfEffect)
    {
        this.upgradeName = upgradeName ?? throw new ArgumentNullException(nameof(upgradeName));
        this.enabled = enabled;
        this.variableName = variableName ?? throw new ArgumentNullException(nameof(variableName));
        this.costVariable = costVariable ?? throw new ArgumentNullException(nameof(costVariable));
        this.upgradeText = upgradeText ?? throw new ArgumentNullException(nameof(upgradeText));
        this.upgradeTextFormat = upgradeTextFormat ?? throw new ArgumentNullException(nameof(upgradeTextFormat));
        this.initialCost = initialCost; 
        this.cost = initialCost;
        this.upgradeType = upgradeType ?? throw new ArgumentNullException(nameof(upgradeType));
        this.rateOfCost = rateOfCost;
        this.rateOfEffect = rateOfEffect;
    }

    public UpgradeClass([NotNull] string upgradeName, [NotNull] bool enabled, [NotNull] string variableName, [NotNull] string costVariable, [NotNull] string upgradeText,
        [NotNull] string upgradeTextFormat, double initialCost, [NotNull] string upgradeType, string customUpgradeEffectName, string customUpgradeCostName) //For custom upgrade types not regular, like function overiding for this.
    {
        this.upgradeName = upgradeName ?? throw new ArgumentNullException(nameof(upgradeName));
        this.enabled = enabled;
        this.variableName = variableName ?? throw new ArgumentNullException(nameof(variableName));
        this.costVariable = costVariable ?? throw new ArgumentNullException(nameof(costVariable));
        this.upgradeText = upgradeText ?? throw new ArgumentNullException(nameof(upgradeText));
        this.upgradeTextFormat = upgradeTextFormat ?? throw new ArgumentNullException(nameof(upgradeTextFormat)); 
        this.initialCost = initialCost;
        this.cost = initialCost;
        this.upgradeType = upgradeType ?? throw new ArgumentNullException(nameof(upgradeType));
        this.customUpgradeEffectName = customUpgradeEffectName;
        this.customUpgradeCostName = customUpgradeCostName;
    }
}
