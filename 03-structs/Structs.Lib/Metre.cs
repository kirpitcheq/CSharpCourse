using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Structs.Lib
{
    public struct Metre
    {
        public decimal Value { get; private set; }
        public Metre(decimal value){
            this.Value = value;
        }

        public override readonly string ToString() => Value.ToString();

        public override readonly bool Equals([NotNullWhen(true)] object? obj) {
            if(obj is Metre == false) return false;
            return ((Metre)obj).Value == this.Value;
        }

        public override readonly int GetHashCode() => Value.GetHashCode();

        const decimal INCH_TO_METRE = 0.0254M;
        const decimal METRE_TO_INCH = 39.3700787401574803M;

        /* explicit op */
        public static implicit operator decimal(Metre m) => m.Value;
        public static explicit operator Inch(Metre meter) => new(meter.Value * (1M / INCH_TO_METRE));
        // public static implicit operator Inch(Meter meter) 
        //     => new(meter.Value * METRE_TO_INCH);
        /* simple bin ops */
        public static Metre operator+(Metre A, Metre B) => new(A.Value + B.Value);
        public static Metre operator-(Metre A, Metre B) => new(A.Value - B.Value);
        public static Metre operator*(Metre A, Metre B) => new(A.Value * B.Value);
        public static Metre operator/(Metre A, Metre B) => new(A.Value / B.Value);
        /* simple unar ops */
        public static Metre operator+(Metre A) => new(A.Value);
        public static Metre operator-(Metre A) => new(-A.Value);
        /* simple comp ops */
        public static bool operator==(Metre A, Metre B) => A.Value == B.Value;
        public static bool operator!=(Metre A, Metre B) => A.Value != B.Value;
        public static bool operator>(Metre A, Metre B) => A.Value > B.Value;
        public static bool operator<(Metre A, Metre B) => A.Value < B.Value;
        public static bool operator>=(Metre A, Metre B) => A.Value >= B.Value;
        public static bool operator<=(Metre A, Metre B) => A.Value <= B.Value;

        /* meter-inch bin ops */
        public static Metre operator+(Metre A, Inch B) => new(A.Value + INCH_TO_METRE * B.Value);
        public static Metre operator-(Metre A, Inch B) => new(A.Value - INCH_TO_METRE * B.Value);
        public static Metre operator*(Metre A, Inch B)
            => new(A.Value * INCH_TO_METRE * B.Value);
        public static Metre operator/(Metre A, Inch B) => new(A.Value / (INCH_TO_METRE * B.Value));

        /* inch-meter bin ops */
        public static Metre operator +(Inch A, Metre B) => new (INCH_TO_METRE * A.Value + B.Value); 
        public static Metre operator-(Inch A, Metre B) => new (INCH_TO_METRE * A.Value - B.Value);
        // public static Metre operator*(Inch A, Metre B) => new (INCH_TO_METRE * A.Value * B.Value);
        public static Metre operator/(Inch A, Metre B) => new (INCH_TO_METRE * A.Value / B.Value);
#if COMMON_OLD
#endif
        /* meter-inch common comp ops */
        public static bool operator==(Metre A, Inch B) => A.Value == INCH_TO_METRE * B.Value;
        public static bool operator!=(Metre A, Inch B) => A.Value != INCH_TO_METRE * B.Value;
        public static bool operator>(Metre A, Inch B) => A.Value > INCH_TO_METRE * B.Value;
        public static bool operator<(Metre A, Inch B) => A.Value < INCH_TO_METRE * B.Value;
        public static bool operator>=(Metre A, Inch B) => A.Value >= INCH_TO_METRE * B.Value;
        public static bool operator<=(Metre A, Inch B) => A.Value <= INCH_TO_METRE * B.Value;
        
        /* metre-decimal bin ops */
        public static Metre operator+(Metre A, decimal B) => new(A.Value + B);
        public static Metre operator-(Metre A, decimal B) => new(A.Value - B);
        public static Metre operator*(Metre A, decimal B) => new(A.Value * B);
        public static Metre operator/(Metre A, decimal B) => new(A.Value / B);

        /* decimal-metre bin ops */
        public static Metre operator+(decimal A, Metre B) => new (A + B.Value); 
        public static Metre operator-(decimal A, Metre B) => new (A - B.Value);
        public static Metre operator*(decimal A, Metre B) => new (A * B.Value);
        public static Metre operator/(decimal A, Metre B) => new (A / B.Value);

    }
}