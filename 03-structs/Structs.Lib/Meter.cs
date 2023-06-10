using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Structs.Lib
{
    public struct Meter
    {
        public decimal Value { get; private set; }
        public Meter(decimal value){
            this.Value = value;
        }

        public override string ToString() => Value.ToString();

        public override bool Equals([NotNullWhen(true)] object? obj) {
            if (ReferenceEquals(obj, null) || !(obj is Meter))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return ((Meter)obj).Value == this.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        /* explicit op */
        public static explicit operator decimal(Meter m) => m.Value;
        public static implicit operator Inch(Meter meter) => new Inch(meter.Value * 39.37007874M);
        /* simple bin ops */
        public static Meter operator+(Meter A, Meter B) => new Meter(A.Value + B.Value);
        public static Meter operator-(Meter A, Meter B) => new Meter(A.Value - B.Value);
        public static Meter operator*(Meter A, Meter B) => new Meter(A.Value * B.Value);
        public static Meter operator/(Meter A, Meter B) => new Meter(A.Value / B.Value);
        /* simple unar ops */
        public static Meter operator+(Meter A) => new Meter(Math.Abs(A.Value));
        public static Meter operator-(Meter A) => new Meter(-Math.Abs(A.Value));
        /* simple comp ops */
        public static bool operator==(Meter A, Meter B) => A.Value == B.Value;
        public static bool operator!=(Meter A, Meter B) => A.Value != B.Value;
        public static bool operator>(Meter A, Meter B) => A.Value > B.Value;
        public static bool operator<(Meter A, Meter B) => A.Value < B.Value;
        public static bool operator>=(Meter A, Meter B) => A.Value >= B.Value;
        public static bool operator<=(Meter A, Meter B) => A.Value <= B.Value;
        
        /* meter-inch bin ops */
        public static Meter operator+(Meter A, Inch B) => new Meter(A.Value + ((Inch)B).Value);
        public static Meter operator-(Meter A, Inch B) => new Meter(A.Value - ((Inch)B).Value);
        public static Meter operator*(Meter A, Inch B) => new Meter(A.Value * ((Inch)B).Value);
        public static Meter operator/(Meter A, Inch B) => new Meter(A.Value / ((Inch)B).Value);
        /* meter-inch comp ops */
        public static bool operator==(Meter A, Inch B) => A.Value == ((Inch)B).Value;
        public static bool operator!=(Meter A, Inch B) => A.Value != ((Inch)B).Value;
        public static bool operator>(Meter A, Inch B) => A.Value > ((Inch)B).Value;
        public static bool operator<(Meter A, Inch B) => A.Value < ((Inch)B).Value;
        public static bool operator>=(Meter A, Inch B) => A.Value >= ((Inch)B).Value;
        public static bool operator<=(Meter A, Inch B) => A.Value <= ((Inch)B).Value;

        /* inch-meter bin ops */
        public static Meter operator+(Inch A, Meter B) => new Meter(((Inch)B).Value + B.Value);
        public static Meter operator-(Inch A, Meter B) => new Meter(((Inch)B).Value - B.Value);
        public static Meter operator*(Inch A, Meter B) => new Meter(((Inch)B).Value * B.Value);
        public static Meter operator/(Inch A, Meter B) => new Meter(((Inch)B).Value / B.Value);
        /* inch-meter comp ops */
        public static bool operator==(Inch A, Meter B) => ((Inch)B).Value == B.Value;
        public static bool operator!=(Inch A, Meter B) => ((Inch)B).Value != B.Value;
        public static bool operator>(Inch A, Meter B) => ((Inch)B).Value > B.Value;
        public static bool operator<(Inch A, Meter B) => ((Inch)B).Value < B.Value;
        public static bool operator>=(Inch A, Meter B) => ((Inch)B).Value >= B.Value;
        public static bool operator<=(Inch A, Meter B) => ((Inch)B).Value <= B.Value;

        
    }
}