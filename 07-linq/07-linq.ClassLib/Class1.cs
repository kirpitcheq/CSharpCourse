using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel;

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
    // public static IEnumerable<T> SmoothByMovingAverage<T>(this IEnumerable<T> source, int width, PointNeighborhood neighborhood = PointNeighborhood.LEFT_CLOSER){
    //     if(width == 0) 
    //         throw new ArgumentOutOfRangeException("Width must be more than 0");
    //     if(width > source.Count())
    //         throw new ArgumentException("Width more than len of source");
    //     if(width == 1){
    //         foreach(var i in source){
    //              yield return i; 
    //         }
    //         yield break;
    //     } 

    //     for(int i = 0; i < source.Count(); i++){
    //         int leftbound = i;
    //         int toleft = 0;
    //         if(width % 2 == 0){
    //             toleft = neighborhood == PointNeighborhood.LEFT_CLOSER ? width / 2 : width / 2 - 1;
    //         }
    //         else 
    //             toleft = width / 2;

            
    //         for(int j = i, count = 0; count < width; j++){
    //         }

    //     }
    // }
}
public enum PointNeighborhood{LEFT_CLOSER, RIGHT_CLOSER};
