using UnityEngine;
using System.Numerics;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnlockableSO", order = 3)]
public class UnlockableSO : ScriptableObject //Will unlock a upgrade, modify it or something, or unlock a variable or both i guess idk.
{
    [SerializeField] public string unlockableName; //Use this to fetch from a dictionary

    public string[] newUpgrades;
    
    public string[] upgradeNames;//Which upgrade it will affect
    public string[] newCustomUpgradeEffectNames; //Name of the custom upgrade function thing effect that the upgrade now will be using
    public string[] newUpgradeTexts;

    public string[] unlockedVariables;
    
    public string costVariable;
    [SerializeField] public int cost;

    public string unlockableDisplayText;
}