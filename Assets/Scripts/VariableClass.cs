using System.Numerics;

public class VariableClass
{
    private string name { get; }
    private BigInteger value { get; set; }
    private BigInteger initialValue { get; set; } //In case we need to reset or something idk.

    public VariableClass(string name, BigInteger value)
    {
        this.name = name;
        this.value = value;
        this.initialValue = value;
    }

}
