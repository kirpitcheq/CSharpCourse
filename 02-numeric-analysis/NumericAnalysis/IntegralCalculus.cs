using System;

namespace NumericAnalysis;

public class IntegralCalculus
{
    public static double Calculate(Func<double, double> func, double x1, double x2, double precision) {
        uint i = 1;
        double preval = TrapMeth(func, x1, x2, i);
        double exp;
        do{
            i*=2;
            double nowval = TrapMeth(func, x1, x2, i);
            exp = Math.Abs(preval - nowval);
            preval = nowval;
            System.Console.WriteLine(exp);
        }while(exp > precision);

        return preval;
    }
    public static double TrapMeth(Func<double, double> func, double x1, double x2, uint segmentsnumb) {
        if(segmentsnumb == 0)
            throw new ArgumentOutOfRangeException(segmentsnumb.GetType().Name, null, "segmentsnumb must be more than 0");
        double sum = 0;
        double step = (x2-x1) / segmentsnumb;
        if(segmentsnumb != 1) {
            double prelast = x2-step;
            for(double i = x1+step; i <= prelast; i+=step){
                sum += func(i);
            }
        }
        sum+=(func(x1)+func(x2))/2;
        sum*=step;
        return sum;
    }
}

/*
    Ошибки были следующими:
        - неправильное определение диапазона шага для цикла for() в функции TrapMeth
        - неправильная установка начального значения итерации i в цикле do{}while(exp>precision), а также последующее увеличение счётчика итерации
*/