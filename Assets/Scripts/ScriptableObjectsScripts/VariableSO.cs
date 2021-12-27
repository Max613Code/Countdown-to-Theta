using UnityEngine;
using System.Numerics;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VariableSO", order = 1)]
public class VariableSO : ScriptableObject
{
    public string variableName;
    public float initialValue;
    public string displaySymbol;
    public bool hasSpecialUpdatedText = false;
}