using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeT1DisplayScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text varDisplayText;
    [SerializeField] private UnityEngine.UI.Text upgDisplayText;
    [SerializeField] public string upgradeName;

    public string VariableUpgradeDisplay
    {
        get
        {
            return varDisplayText.text;
        }
        set
        {
            varDisplayText.text = value;
        }
    }
    
    public string CostUpgradeDisplay
    {
        get
        {
            return upgDisplayText.text;
        }
        set
        {
            upgDisplayText.text = value;
        }
    }

    public void purchase()
    {
        Reference.UM.purchase(upgradeName,1);
    }
}