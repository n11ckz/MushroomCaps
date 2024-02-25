using System.Numerics;

public class ReduceArgs
{
    private const int Offset = 3;
    private const int DefaultValue = 10;

    public readonly float DecimalPoint = 0.001f;

    public char Letter { get; private set; }
    public BigInteger Divider { get; private set; }

    public ReduceArgs(char letter, int numberOfZeros)
    {
        Letter = letter;
        Divider = numberOfZeros % Offset == 0 && numberOfZeros >= Offset ?
            BigInteger.Pow(new BigInteger(DefaultValue), numberOfZeros - Offset) : DefaultValue;
    }
}