using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Structs.Lib
{
    public struct Inch
    {
        public decimal Value { get; private set; }
        public Inch(decimal value){
            this.Value = value;
        }

        public override string ToString() => Value.ToString();

        public override bool Equals([NotNullWhen(true)] object? obj) {
            if (ReferenceEquals(obj, null) || !(obj is Inch))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return ((Inch)obj).Value == this.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        /* explicit op */
        public static explicit operator decimal(Inch m) => m.Value;
        public static implicit operator Meter(Inch inch) => new Meter(inch.Value * 0.0254M);
        
        /* simple bin ops */
        public static Inch operator+(Inch A, Inch B) => new Inch(A.Value + B.Value);
        public static Inch operator-(Inch A, Inch B) => new Inch(A.Value - B.Value);
        public static Inch operator*(Inch A, Inch B) => new Inch(A.Value * B.Value);
        public static Inch operator/(Inch A, Inch B) => new Inch(A.Value / B.Value);

        /* simple unar ops */
        public static Inch operator+(Inch A) => new Inch(Math.Abs(A.Value));
        public static Inch operator-(Inch A) => new Inch(-Math.Abs(A.Value));

        /* simple comp ops */
        public static bool operator==(Inch A, Inch B) => A.Value == B.Value ;
        public static bool operator!=(Inch A, Inch B) => A.Value != B.Value ;
        public static bool operator>(Inch A, Inch B) => A.Value > B.Value ;
        public static bool operator<(Inch A, Inch B) => A.Value < B.Value ;
        public static bool operator>=(Inch A, Inch B) => A.Value >= B.Value ;
        public static bool operator<=(Inch A, Inch B) => A.Value <= B.Value ;

        /* inch-meter bin ops */
        public static Inch operator+(Inch A, Meter B) => new Inch(A.Value + ((Inch)B).Value);
        public static Inch operator-(Inch A, Meter B) => new Inch(A.Value - ((Inch)B).Value);
        public static Inch operator*(Inch A, Meter B) => new Inch(A.Value * ((Inch)B).Value);
        public static Inch operator/(Inch A, Meter B) => new Inch(A.Value / ((Inch)B).Value);

        /* inch-meter comp ops */
        public static bool operator==(Inch A, Meter B) => A.Value == ((Inch)B).Value ;
        public static bool operator!=(Inch A, Meter B) => A.Value != ((Inch)B).Value ;
        public static bool operator>(Inch A, Meter B) => A.Value > ((Inch)B).Value ;
        public static bool operator<(Inch A, Meter B) => A.Value < ((Inch)B).Value ;
        public static bool operator>=(Inch A, Meter B) => A.Value >= ((Inch)B).Value ;
        public static bool operator<=(Inch A, Meter B) => A.Value <= ((Inch)B).Value ;


         /* meter-inch bin ops */
        public static Inch operator+(Meter A, Inch B) => new Inch(((Meter)A).Value + B.Value);
        public static Inch operator-(Meter A, Inch B) => new Inch(((Meter)A).Value - B.Value);
        public static Inch operator*(Meter A, Inch B) => new Inch(((Meter)A).Value * B.Value);
        public static Inch operator/(Meter A, Inch B) => new Inch(((Meter)A).Value / B.Value);

        /* meter-inch comp ops */
        public static bool operator==(Meter A, Inch B) => ((Meter)A).Value == B.Value ;
        public static bool operator!=(Meter A, Inch B) => ((Meter)A).Value != B.Value ;
        public static bool operator>(Meter A, Inch B) => ((Meter)A).Value > B.Value ;
        public static bool operator<(Meter A, Inch B) => ((Meter)A).Value < B.Value ;
        public static bool operator>=(Meter A, Inch B) => ((Meter)A).Value >= B.Value ;
        public static bool operator<=(Meter A, Inch B) => ((Meter)A).Value <= B.Value ;


    }
}