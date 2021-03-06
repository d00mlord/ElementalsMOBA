﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public struct FVector
{
    public FInt x;
    public FInt y;

    public FVector(FVector z)
    {
        x = new FInt(z.x);
        y = new FInt(z.y);
    }

    public FVector(FInt first, FInt second)
    {
        x = first;
        y = second;
    }

    public static FVector operator +(FVector x, FVector y)
    {
        FVector z = new FVector(x.x + y.x, x.y + y.y);
        return z;
    }

    public static FVector operator *(FVector x, FInt y)
    {
        FVector z = new FVector(x.x * y, x.y * y);
        return z;
    }

    public static FVector operator /(FVector x, FInt y)
    {
        FVector z = new FVector(x.x / y, x.y / y);
        return z;
    }
}

[System.Serializable]
public class FInt
{
    public const int FLOATING_BITS = 16;

    public long rawValue;

    public FInt()
    {
    }

    public FInt(FInt other)
    {
		rawValue = other.rawValue;
    }

    public FInt(int value)
    {
        rawValue = ((long)value) << FLOATING_BITS;
    }

    public FInt(long value)
    {
        rawValue = value << FLOATING_BITS;
    }

    public FInt(float value)
    {
        rawValue = (long)(value * (1 << FLOATING_BITS));
    }

    public FInt(double value)
    {
        rawValue = (long)(value * (1 << FLOATING_BITS));
    }

    public static FInt RawFInt(int raw)
    {
        FInt z = new FInt(0);
        z.rawValue = (long)raw;
        return z;
    }

    public static FInt Zero()
    {
        return new FInt(0);
    }

    public static FInt One()
    {
        return new FInt(1);
    }

    // Largest signed long
    public static FInt Max()
    {
        FInt z = new FInt();
        z.rawValue = long.MaxValue;
        return z;
    }

    // Smallest signed long
    public static FInt Min()
    {
        FInt z = new FInt();
        z.rawValue = long.MinValue;
        return z;
    }

    public int ToInt()
    {
        return (int)(rawValue >> FLOATING_BITS);
    }

    public int Round()
    {
        long flat = rawValue >> FLOATING_BITS;
        long remainder = rawValue - (flat << FLOATING_BITS);
        if (remainder > (long)(1 << (FLOATING_BITS - 1)))
        {
            return (int)flat + 1;
        }
        return (int)flat;
    }

    public float ToFloat()
    {
        return ((float)rawValue) / (1 << FLOATING_BITS);
    }

    public FInt Abs()
    {
        FInt z = new FInt();
        z.rawValue = (rawValue < 0) ? -rawValue : rawValue;
        return z;
    }

    public int FractionalBits()
    {
        long flat = rawValue >> FLOATING_BITS;
        long remainder = rawValue - (flat << FLOATING_BITS);
        return (int)remainder;
    }

    public static FInt operator +(FInt x, FInt y)
    {
        FInt z = new FInt(x);
        z.rawValue += y.rawValue;
        return z;
    }

    public static FInt operator +(FInt x, float y)
    {
        FInt z = new FInt(x);
        z.rawValue += (long)(y * (1 << FLOATING_BITS));
        return z;
    }

    public static FInt operator +(FInt x, int y)
    {
        FInt z = new FInt(x);
        z.rawValue += ((long)y) << FLOATING_BITS;
        return z;
    }

    public static FInt operator -(FInt x, FInt y)
    {
        FInt z = new FInt(x);
        z.rawValue -= y.rawValue;
        return z;
    }

    public static FInt operator -(FInt x)
    {
        FInt z = new FInt(x);
        z.rawValue = -z.rawValue;
        return z;
    }

    public static FInt operator *(FInt x, FInt y)
    {
        FInt z = new FInt();
        z.rawValue = (x.rawValue * y.rawValue) >> FLOATING_BITS;
        return z;
    }

    public static FInt operator /(FInt x, FInt y)
    {
        FInt z = new FInt();
        z.rawValue = (x.rawValue << FLOATING_BITS) / y.rawValue;
        return z;
    }

    public override int GetHashCode()
    {
        return rawValue.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        FInt other = (FInt)obj;
        if (other == null)
        {
            return false;
        }
        return rawValue == other.rawValue;
    }

    public static bool operator ==(FInt x, FInt y)
    {
        if (object.ReferenceEquals(null, x) && object.ReferenceEquals(null, y))
        {
            return true;
        }
        else if (object.ReferenceEquals(null, x) || object.ReferenceEquals(null, y))
        {
            return false;
        }
        return x.rawValue == y.rawValue;
    }

    public static bool operator !=(FInt x, FInt y)
    {
        if (object.ReferenceEquals(null, x) && object.ReferenceEquals(null, y))
        {
            return false;
        }
        else if (object.ReferenceEquals(null, x) || object.ReferenceEquals(null, y))
        {
            return true;
        }
        return x.rawValue != y.rawValue;
    }

    public static bool operator >(FInt x, FInt y)
    {
        return x.rawValue > y.rawValue;
    }

    public static bool operator >=(FInt x, FInt y)
    {
        return x.rawValue >= y.rawValue;
    }

    public static bool operator <(FInt x, FInt y)
    {
        return x.rawValue < y.rawValue;
    }

    public static bool operator <=(FInt x, FInt y)
    {
        return x.rawValue <= y.rawValue;
    }

    public override string ToString()
    {
        return (((float)rawValue) / (1 << FLOATING_BITS)).ToString();
    }
}
