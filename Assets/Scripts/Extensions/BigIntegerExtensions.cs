using System.Collections.Generic;
using System.Numerics;

public static class BigIntegerExtensions
{
    private static readonly ReduceArgs _thousand = new ReduceArgs('K', 3);
    private static readonly ReduceArgs _million = new ReduceArgs('M', 6);
    private static readonly ReduceArgs _billion = new ReduceArgs('B', 9);
    private static readonly ReduceArgs _trillion = new ReduceArgs('t', 12);
    private static readonly ReduceArgs _quadrillion = new ReduceArgs('q', 15);
    private static readonly ReduceArgs _quintillion = new ReduceArgs('Q', 18);
    private static readonly Dictionary<int, ReduceArgs> _argsForReducing = new Dictionary<int, ReduceArgs>()
    {
        { 4, _thousand }, { 5, _thousand }, { 6, _thousand },
        { 7, _million }, { 8, _million }, { 9, _million },
        { 10, _billion }, { 11, _billion }, { 12, _billion },
        { 13, _trillion }, { 14, _trillion }, { 15, _trillion },
        { 16, _quadrillion }, { 17, _quadrillion }, { 18, _quadrillion },
        { 19, _quintillion }, { 20, _quintillion }, { 21, _quintillion }
    };

    public static string GetReducedNumber(this BigInteger number)
    {
        string reducedNumber = number.ToString();
        if (!_argsForReducing.TryGetValue(reducedNumber.Length, out ReduceArgs args))
            return reducedNumber;
        reducedNumber = ((int)BigInteger.Divide(number, args.Divider) * args.DecimalPoint).ToString("0.00") + args.Letter;
        return reducedNumber;
    }
}