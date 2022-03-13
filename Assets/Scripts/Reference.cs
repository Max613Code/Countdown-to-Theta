using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public static class Reference
{
    public static GameManager GM;
    public static UIManager UI;
    public static UpgradeManager UM;
    public static UnlockableManager UNM;
    public static Graph GraphScript;

    public static void find()
    { //Set up references so that scripts do not have to constantly call GameObject.Find, and can easily access important scripts.
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        UI = GameObject.Find("Main Canvas").GetComponent<UIManager>();
        UM = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        UNM = GameObject.Find("UnlockableManager").GetComponent<UnlockableManager>();
        GraphScript = GameObject.Find("GraphPanel").GetComponent<Graph>();
    }
    
}
