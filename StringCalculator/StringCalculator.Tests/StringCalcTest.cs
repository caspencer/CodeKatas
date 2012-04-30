using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalcTest
    {
        [Fact]
        public void Add_ShouldReturn0ForEmptyString()
        {
            var calc = new StringCalc();
            Assert.Equal(0, calc.Add(string.Empty));
        }

        [Fact]
        public void Add_ShouldReturn1For_1()
        {
            var calc = new StringCalc();
            Assert.Equal(1, calc.Add("1"));
        }

        [Fact]
        public void Add_ShouldReturn3For_1_2()
        {
            var calc = new StringCalc();
            Assert.Equal(3, calc.Add("1,2"));
        }

        [Fact]
        public void Add_ShouldReturn3For_1_newline_2()
        {
            var calc = new StringCalc();
            Assert.Equal(3, calc.Add("1\n2"));
        }

        [Fact]
        public void Add_ShouldSupportChangingDelimiter()
        {
            var calc = new StringCalc();
            Assert.Equal(3, calc.Add("//;\n1;2")); // "//[delimiter]\n[numbers]"
        }

        [Fact]
        public void Add_ShouldThrowExceptionOnNegative()
        {
            var calc = new StringCalc();
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calc.Add("-1"));
            Assert.Equal("negatives not allowed: -1\r\nParameter name: input", exception.Message);
        }

        [Fact]
        public void Add_ShouldThrowExceptionOnMultipleNegatives()
        {
            var calc = new StringCalc();
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calc.Add("-1,-2"));
            Assert.Equal("negatives not allowed: -1,-2\r\nParameter name: input", exception.Message);
        }

        [Fact]
        public void Add_ShouldIgnoreNumbersGreaterThan1000()
        {
            var calc = new StringCalc();
            Assert.Equal(2, calc.Add("2,1001"));
        }

        [Fact]
        public void Add_ShouldSupportMultiCharacterDelimiters()
        {
            var calc = new StringCalc();
            Assert.Equal(6, calc.Add("//[***]\n1***2***3")); // "//[delimiter]\n[numbers]"
        }

        [Fact]
        public void Add_ShouldSupportMultipleDelimiters()
        {
            var calc = new StringCalc();
            Assert.Equal(6, calc.Add("//[*][%]\n1*2%3")); // "//[delim1][delim2]\n[numbers]"
        }

        [Fact]
        public void Add_ShouldSupportMultipleMultiCharacterDelimiters()
        {
            var calc = new StringCalc();
            Assert.Equal(6, calc.Add("//[***][%%%]\n1***2%%%3")); // "//[delim1][delim2]\n[numbers]"
        }
    }
}