// See https://aka.ms/new-console-template for more information

using Structs.Lib;

Inch in3 = new Inch(3M);
Meter met3 = new Meter(3M);

Meter in3plmet3met = in3 + (Inch)met3;
System.Console.WriteLine("3 inchs + 3 meters = " + in3plmet3met + " Meters");

Inch in3plmet3in = (Meter)in3 + met3;
System.Console.WriteLine("3 inchs + 3 meters = " + in3plmet3in + " Inches");