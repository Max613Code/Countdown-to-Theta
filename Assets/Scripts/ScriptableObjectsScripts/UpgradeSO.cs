using UnityEngine;
using System.Numerics;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UpgradeSO", order = 2)]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] public string upgradeName; //Must be unique, used to fetch info from UM from a dictionary as like the variables.
    public string variableName;
    [Header("Upgrade Type (regular, custom)")] [SerializeField]
    public string type = "regular";
    
    [Header("Regular")]

    [SerializeField] public float rateOfCost;
    [SerializeField] public float rateOfEffect;
}