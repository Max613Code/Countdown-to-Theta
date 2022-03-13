using UnityEngine;
using System.Numerics;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UpgradeSO", order = 2)]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] public string upgradeName; //Must be unique, used to fetch info from UM from a dictionary as like the variables.
    public bool enabled;
    public string variableName;
    public string costVariable;
    public string upgradeText; //Like "a={0}"
    public string upgradeTextFormatVariableName; //Like "a0V1"
    
    [SerializeField] public float initialCost;
    
    [Header("Upgrade Type (regular, custom)")] [SerializeField]
    public string type = "regular";
    
    [Header("Regular")]

    [SerializeField] public float rateOfCost;
    [SerializeField] public float rateOfEffect;

    [Header("Custom Effect Name")] [SerializeField] //Name of the custom function to calculate the effect
    public string customUpgradeEffectName;

    [Header("Custom Cost (Function) Name")] [SerializeField]
    public string customUpgradeCostName;
}