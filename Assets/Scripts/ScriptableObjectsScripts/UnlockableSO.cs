using UnityEngine;
using System.Numerics;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnlockableSO", order = 3)]
public class UnlockableSO : ScriptableObject //Will unlock a upgrade, modify it or something, or unlock a variable or both i guess idk.
{
    [SerializeField] public string unlockableName; //Use this to fetch from a dictionary
    
    public string upgradeName;//Which upgrade it will affect
    public string newCustomUpgradeEffectName;
    public string newUpgradeText;

    public string unlockedVariable;
    
    public string costVariable;
    public int cost { get; set; }
}