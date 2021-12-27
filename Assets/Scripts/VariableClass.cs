using System.Numerics;

public class VariableClass
{
    public string name { get; }
    public double value { get; set; }
    public double initialValue { get; set; } //In case we need to reset or something idk.
    public int level { get; set; }
    
    public string displaySymbol { get; set; }

    public VariableClass(string name, double value, string displaySymbol) //Regular initializer.
    {
        this.name = name;
        this.value = value;
        this.initialValue = value;
        this.level = 1;
        this.displaySymbol = displaySymbol;
    }

}
