using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public static class decimalMathFunctions
{
    public static decimal BigIntPow(decimal x, decimal y)
    {
        return 0;
    }

    public static decimal IntPow(decimal x, int y)
    {
        decimal result = 1;
        for (int _ = 0; _ < y; _++)
        {
            result *= x;
        }

        return 0;
    }
}
