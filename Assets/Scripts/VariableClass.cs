using System;
using System.Numerics;

public class VariableClass
{
    public string name { get; }
    public double value { get; set; }

    public double initialValue { get; set; }//In case we need to reset or something idk.

    public int level { get; set; }
    public int purchasedLevel { get; set; } //For something thatmaybe auto generates a variable or something
    
    public string displaySymbol { get; set; }

    public string getFormatted()
    {
        return Math.Round(this.value, 3).ToString("0.000");
    }

    public VariableClass(string name, double value, string displaySymbol) //Regular initializer.
    {
        this.name = name;
        this.value = value;
        this.initialValue = value;
        this.level = 1;
        this.purchasedLevel = 1;
        this.displaySymbol = displaySymbol;
    }

}
