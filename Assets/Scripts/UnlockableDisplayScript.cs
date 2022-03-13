using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableDisplayScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text toUnlockDisplayText;
    [SerializeField] private UnityEngine.UI.Text costDisplayText;
    [SerializeField] public string unlockableName;

    public string toUnlockUpgradeDisplay
    {
        get
        {
            return toUnlockDisplayText.text;
        }
        set
        {
            toUnlockDisplayText.text = value;
        }
    }
    
    public string CostUpgradeDisplay
    {
        get
        {
            return costDisplayText.text;
        }
        set
        {
            costDisplayText.text = value;
        }
    }

    public void purchase()
    {
        if (Reference.UNM.purchase(unlockableName))
        {
            Destroy(this);
        }
    }
    
}