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

        readonly public override string ToString() => Value.ToString();

        readonly public override bool Equals([NotNullWhen(true)] object? obj) {
            if((obj is Inch) == false) return false;
            return ((Inch)obj).Value == this.Value;
        }

        readonly public override int GetHashCode() => Value.GetHashCode();

        const decimal INCH_TO_METRE = 0.0254M;
        const decimal METRE_TO_INCH = 1M/INCH_TO_METRE;
        // const decimal METER_TO_INCH = 39.37007874M;

        /* explicit op */
        public static explicit operator decimal(Inch m) => m.Value;
        public static implicit operator Metre(Inch inch) => new (inch.Value * INCH_TO_METRE);
        
        /* simple bin ops */
        public static Inch operator+(Inch A, Inch B) => new (A.Value + B.Value);
        public static Inch operator-(Inch A, Inch B) => new (A.Value - B.Value);
        public static Inch operator*(Inch A, Inch B) => new (A.Value * B.Value);
        public static Inch operator/(Inch A, Inch B) => new (A.Value / B.Value);

        /* simple unar ops */
        public static Inch operator+(Inch A) => new (Math.Abs(A.Value));
        public static Inch operator-(Inch A) => new (-Math.Abs(A.Value));

        /* simple comp ops */
        public static bool operator==(Inch A, Inch B) => A.Value == B.Value ;
        public static bool operator!=(Inch A, Inch B) => A.Value != B.Value ;
        public static bool operator>(Inch A, Inch B) => A.Value > B.Value ;
        public static bool operator<(Inch A, Inch B) => A.Value < B.Value ;
        public static bool operator>=(Inch A, Inch B) => A.Value >= B.Value ;
        public static bool operator<=(Inch A, Inch B) => A.Value <= B.Value ;

        public static Inch operator*(Inch A, Metre B) => new (A.Value * METRE_TO_INCH * B.Value);
#if INCH_OPS
        /* inch-meter bin ops */
        public static Inch operator+(Inch A, Meter B) => new (A.Value + METER_TO_INCH * B.Value);
        public static Inch operator-(Inch A, Meter B) => new (A.Value - METER_TO_INCH * B.Value);
        public static Inch operator*(Inch A, Meter B) => new (A.Value * METER_TO_INCH * B.Value);
        public static Inch operator/(Inch A, Meter B) => new (A.Value / METER_TO_INCH * B.Value);

         /* meter-inch bin ops */
        public static Inch operator+(Meter A, Inch B) => new (METER_TO_INCH * A.Value + B.Value);
        public static Inch operator-(Meter A, Inch B) => new (METER_TO_INCH * A.Value - B.Value);
        public static Inch operator*(Meter A, Inch B) => new (METER_TO_INCH * A.Value * B.Value);
        public static Inch operator/(Meter A, Inch B) => new (METER_TO_INCH * A.Value / B.Value);
#endif
        /* inch-meter common comp ops */
        public static bool operator==(Inch A, Metre B) => INCH_TO_METRE * A.Value == B.Value;
        public static bool operator!=(Inch A, Metre B) => INCH_TO_METRE * A.Value != B.Value;
        public static bool operator>(Inch A, Metre B) => INCH_TO_METRE * A.Value > B.Value;
        public static bool operator<(Inch A, Metre B) => INCH_TO_METRE * A.Value < B.Value;
        public static bool operator>=(Inch A, Metre B) => INCH_TO_METRE * A.Value >= B.Value;
        public static bool operator<=(Inch A, Metre B) => INCH_TO_METRE * A.Value <= B.Value;

    }
}