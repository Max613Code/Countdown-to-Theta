using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UpgradeClass
{

    public string upgradeName { get; set; }
    public string variableName { get; set; } //Which variable this upgrade is referencing.
    public string upgradeText { get; set; }
    public string upgradeTextFormat { get; set; } //upgradeText has {0} which would be replaced by the variable it is referencing.
    
    public string upgradeType { get; set; }
    
    //Regular
    public double rateOfCost { get; set; }
    public double rateOfEffect { get; set; }
    
    //Custom
    public int customUpgradeNum { get; set; } //Which custom functoni from that function it uses. can be 1,2,3,4,...

    public UpgradeClass([NotNull] string upgradeName, [NotNull] string variableName, [NotNull] string upgradeText,
        [NotNull] string upgradeTextFormat, [NotNull] string upgradeType, double rateOfCost, double rateOfEffect)
    {
        this.upgradeName = upgradeName ?? throw new ArgumentNullException(nameof(upgradeName));
        this.variableName = variableName ?? throw new ArgumentNullException(nameof(variableName));
        this.upgradeText = upgradeText ?? throw new ArgumentNullException(nameof(upgradeText));
        this.upgradeTextFormat = upgradeTextFormat ?? throw new ArgumentNullException(nameof(upgradeTextFormat));
        this.upgradeType = upgradeType ?? throw new ArgumentNullException(nameof(upgradeType));
        this.rateOfCost = rateOfCost;
        this.rateOfEffect = rateOfEffect;
    }

    public UpgradeClass([NotNull] string upgradeName, [NotNull] string variableName, [NotNull] string upgradeText,
        [NotNull] string upgradeTextFormat, [NotNull] string upgradeType, int customUpgradeNum) //For custom upgrade types not regular, like function overiding for this.
    {
        this.upgradeName = upgradeName ?? throw new ArgumentNullException(nameof(upgradeName));
        this.variableName = variableName ?? throw new ArgumentNullException(nameof(variableName));
        this.upgradeText = upgradeText ?? throw new ArgumentNullException(nameof(upgradeText));
        this.upgradeTextFormat = upgradeTextFormat ?? throw new ArgumentNullException(nameof(upgradeTextFormat));
        this.upgradeType = upgradeType ?? throw new ArgumentNullException(nameof(upgradeType));
        this.customUpgradeNum = customUpgradeNum;
    }
}
