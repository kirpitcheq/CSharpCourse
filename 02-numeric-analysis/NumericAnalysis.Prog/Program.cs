// See https://aka.ms/new-console-template for more information

using NumericAnalysis;

Func<double, double> func = Math.Sin;
System.Console.WriteLine(IntegralCalculus.Calculate(func, 0, Math.PI, 0.01));