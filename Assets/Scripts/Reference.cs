using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public static double customUpgradeFunc(VariableClass var, int whichCustom)
    {
        if (var.name == "b0V1" && whichCustom == 1) //Best way i could think of for having custom upgrade functions, called from UM.
        {
            return var.value + var.level * var.level/10;
        }

        return 0;
    }
}
