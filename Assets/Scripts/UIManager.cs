using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Standard variables like x and theta, not the variableClass.
    public Text variableDisplay;
    public RectTransform variableDisplayPanel;
    public Dictionary<string, Text> variableDisplayDictionary = new Dictionary<string, Text>(); //Dictionary of the varName to the text that displays it.

    public void createVariableDisplayText(string varName, string displayString) //displayString already contains the variable value, formatted in GM
    {
        var e = Instantiate(variableDisplay);

        e.text = displayString;
        
        e.transform.SetParent(
            variableDisplayPanel,
            worldPositionStays:false);

        variableDisplayDictionary[varName] = e;
    }

    public void updateVariabeDisplayText(string varName, string newDisplayString)
    {
        if (variableDisplayDictionary.ContainsKey(varName))
        {
            variableDisplayDictionary[varName].text = newDisplayString;
        }
        else
        {
            Debug.Log("Cannot update variable text, the referenced text does not exist in the dictionary!");
        }
    }
}
