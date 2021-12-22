using System.Numerics;

public class VariableClass
{
    public string name { get; }
    public decimal value { get; set; }
    public decimal initialValue { get; set; } //In case we need to reset or something idk.
    public int level { get; set; }

    public VariableClass(string name, decimal value) //Regular initializer.
    {
        this.name = name;
        this.value = value;
        this.initialValue = value;
        this.level = 1;
    }

}
