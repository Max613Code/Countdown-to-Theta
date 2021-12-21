using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Reference
{
    public static GameObject GM;
    public static GameObject UI;
    public static GameObject UM;

    public static void find()
    { //Set up references so that scripts do not have to constantly call GameObject.Find, and can easily access important scripts.
        GM = GameObject.Find("GameManager");
        UI = GameObject.Find("Main Canvas");
        UM = GameObject.Find("UpgradeManager");
    }
}
