using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

using Structs.Lib;
using static Structs.Lib.Metre;
namespace Structs.Tests
{
    public class MetreTests
    {
        //-----------------------------------------------------------------------------------
        public delegate Metre MetreFuncMetreInch(Metre metre, Inch inch);
        public static Metre MetreAddInchForward(Metre metre, Inch inch) => metre + inch;
        public static Metre MetreAddInchReverse(Metre metre, Inch inch) => inch + metre;
        public static Metre MetreSubInchForward(Metre metre, Inch inch) => metre - inch;
        public static Metre MetreSubInchReverse(Metre metre, Inch inch) => inch - metre;
        public static Metre MetreMulInchForward(Metre metre, Inch inch) => metre * inch;
        public static Metre MetreMulInchReverse(Metre metre, Inch inch) => inch * metre;
        public static Metre MetreDivInchForward(Metre metre, Inch inch) => metre / inch; 
        public static Metre MetreDivInchReverse(Metre metre, Inch inch) => inch / metre;
        public static IEnumerable<object[]> MetreBinMetreInchEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)MetreAddInchForward, new Metre(1.0254M) };
            yield return new object[] { 1M, 1M, (object)MetreAddInchReverse, new Metre(1.0254M) };
            yield return new object[] { 1M, 1M, (object)MetreSubInchForward, new Metre(0.9746M) };
            yield return new object[] { 1M, 1M, (object)MetreSubInchReverse, new Metre(-0.9746M) };
            yield return new object[] { 1M, 1M, (object)MetreMulInchForward, new Metre(0.0254M) };
            // yield return new object[] { 1M, 1M, (object)MetreMulInchReverse, new Metre() };
            // yield return new object[] { 1M, 1M, (object)MetreDivInchForward, new Metre() }; //how use many ops overloads?
            // yield return new object[] { 1M, 1M, (object)MetreDivInchReverse, new Metre() };
        }
        [Theory, MemberData(nameof(MetreBinMetreInchEnumerable))]
        public void MetreBinMetreMetreTests(decimal first, decimal second, Func<Metre, Inch, Metre> testfunc, Metre expected)
        {
            var firstStruct = new Metre(first); 
            var secondStruct = new Inch(second);
            Metre result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected.Value, result.Value);
        }
        //-----------------------------------------------------------------------------------
        public delegate Metre MetreFuncMetres(Metre first, Metre second);
        public static Metre MetresAdd(Metre first, Metre second) => first + second;
        public static Metre MetresSub(Metre first, Metre second) => first - second;
        public static Metre MetresMul(Metre first, Metre second) => first * second;
        public static Metre MetresDiv(Metre first, Metre second) => first / second;
        public static IEnumerable<object[]> MetresBinEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)MetresAdd, new Metre(2M) };
            yield return new object[] { 1M, 1M, (object)MetresSub, new Metre(0M) };
            yield return new object[] { 1M, 1M, (object)MetresMul, new Metre(1M) };
            yield return new object[] { 1M, 1M, (object)MetresDiv, new Metre(1M) };
        }
        [Theory, MemberData(nameof(MetresBinEnumerable))]
        public void MetresBinTests(decimal first, decimal second, Func<Metre, Metre, Metre> testfunc, Metre expected)
        {
            var firstStruct = new Metre(first); 
            var secondStruct = new Metre(second);
            Metre result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected.Value, result.Value);
        }
        //-----------------------------------------------------------------------------------
        public delegate bool BoolFuncMetres(Metre first, Metre second);
        public static bool MetresEq(Metre first, Metre second) => first == second;
        public static bool MetresNotEq(Metre first, Metre second) => first != second;
        public static bool MetresLess(Metre first, Metre second) => first < second;
        public static bool MetresLessOrEq(Metre first, Metre second) => first <= second;
        public static bool MetresMore(Metre first, Metre second) => first > second;
        public static bool MetresMoreOrEq(Metre first, Metre second) => first >= second;
        public static IEnumerable<object[]> MetresBoolEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)MetresEq, true };
            yield return new object[] { 1M, 1M, (object)MetresNotEq, false };
            yield return new object[] { 1M, 1M, (object)MetresLess, false };
            yield return new object[] { 1M, 1M, (object)MetresLessOrEq, true};
            yield return new object[] { 1M, 1M, (object)MetresMore, false };
            yield return new object[] { 1M, 1M, (object)MetresMoreOrEq, true};
        }
        [Theory, MemberData(nameof(MetresBoolEnumerable))]
        public void MetresBoolTests(decimal first, decimal second, Func<Metre, Metre, bool> testfunc, bool expected)
        {
            var firstStruct = new Metre(first); 
            var secondStruct = new Metre(second);
            var result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected, result);
        }
        //-----------------------------------------------------------------------------------
        delegate bool BoolFuncMetreInch(Inch inch, Metre metre);
        public static bool MetreEqInch(Inch inch, Metre metre) => metre == inch;
        public static bool MetreNotEqInch(Inch inch, Metre metre) => metre != inch;
        public static bool MetreLessInch(Inch inch, Metre metre) => metre < inch;
        public static bool MetreLessOrEqInch(Inch inch, Metre metre) => metre <= inch;
        public static bool MetreMoreInch(Inch inch, Metre metre) => metre > inch;
        public static bool MetreMoreOrEqInch(Inch inch, Metre metre) => metre >= inch;
        public static IEnumerable<object[]> BoolMetreInchEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)MetreEqInch, false };
            yield return new object[] { 1M, 1M, (object)MetreNotEqInch, true };
            yield return new object[] { 1M, 1M, (object)MetreLessInch, false };
            yield return new object[] { 1M, 1M, (object)MetreLessOrEqInch, false };
            yield return new object[] { 1M, 1M, (object)MetreMoreInch, true };
            yield return new object[] { 1M, 1M, (object)MetreMoreOrEqInch, true };
        }
        [Theory, MemberData(nameof(BoolMetreInchEnumerable))]
        public void BoolMetreInchTests(decimal first, decimal second, Func<Inch, Metre, bool> testfunc, bool expected)
        {
            var firstStruct = new Inch(first); 
            var secondStruct = new Metre(second);
            var result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected, result);
        }
        //-----------------------------------------------------------------------------------

    }
}