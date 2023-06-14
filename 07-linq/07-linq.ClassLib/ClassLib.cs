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
    // public static IEnumerable<T> SmoothByMovingAverage<T>(this IEnumerable<T> source, int width){
    //     if(width == 0) 
    //         throw new ArgumentOutOfRangeException("Width must be more than 0");
    //     if(width == 1){
    //         foreach(var i in source){
    //              yield return i; 
    //         }
    //                         //or just return source but ->
    //         yield break;    //return and yield return not must be in same method
    //     } 

    //     for(int i = 0; i < source.Count(); i++){
    //         // for(int j = i, count = 0; count < width; j++){
    //         // }
    //         int toleft = i - width;
    //         int leftbound = width - toleft; //for more than 0
    //         int count = 0;
    //         T result = 0;
    //         while(leftbound != i){
    //             result += source[leftbound].Value;
    //             count++;
    //         }
    //         result += source[leftbound].Value;
    //         count++;
    //         result /= count;
    //         yield return result;
    //     }
    // }
}