using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Numerics;

namespace _07_linq;

public static class ClassLib
{
    public static System.Collections.Generic.IEnumerable<T> TakeOdd<T>(this IEnumerable<T> source) {
        foreach(var i in source){
            if(Math.Floor(Convert.ToDouble(i))%2 != 0) yield return i;
        }
    }
    public static IEnumerable<T> TakeEven<T>(this IEnumerable<T> source){
        foreach(var i in source){
            if(Math.Floor(Convert.ToDouble(i))%2 == 0) yield return i;
        }
    }
    public static IEnumerable<T> TakePositive<T>(this IEnumerable<T> source){
        foreach(var i in source){
            if(Convert.ToInt64(i) >= 0) yield return i;
        }
    }
    public static IEnumerable<T> TakeNegative<T>(this IEnumerable<T> source){
        foreach(var i in source){
            if(Convert.ToInt64(i) < 0) yield return i;
        }
    }
    public static IEnumerable<T> SmoothByMovingAverage<T>(this IEnumerable<T> source, int width) where T : struct, IEquatable<T>, IIncrementOperators<T>, IAdditionOperators<T,T,T>, IDivisionOperators<T,T,T> 
    {
        foreach (var i in source){
            var widthcounter = width;
            T temp = i;
            T counter = default(T);
            counter++;
            foreach (var j in source){
                if(i.Equals(j) || widthcounter <= 0) break;
                temp += j;
                counter++;
            }
            temp/=counter;
            yield return temp;
        }
    }
}