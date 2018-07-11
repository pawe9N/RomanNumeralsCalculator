﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RomanNumeralsCalculator.Classes;

namespace RomanNumeralsCalculator.Tests
{
    [TestFixture]
    class RPNTests
    {
        [TestCase("1+2*(3-1)/2", "1 2 3 1 - * 2 / +")]
        [TestCase("1+(1*(2+1/(3+1/3)*2+(1*(3-1))))", "1 1 2 1 3 1 3 / + / 2 * + 1 3 1 - * + * +")]
        [TestCase("1+2+3*5-7+8/9", "1 2 + 3 5 * + 7 - 8 9 / +")]
        [TestCase("10+100*2/3*(100-1)", "10 100 2 * 3 / 100 1 - * +")]
        [TestCase("( 20 + 2 ) / 11 * 4 - 3 % 3", "20 2 + 11 / 4 * 3 3 % -")]
        public void ConvertToRPN_ValidExpression_ReturnRPN(string expression, string expected)
        {
            string result = RPN.ConvertToRPN(expression);

            Assert.AreEqual(expected, result);
        }

        [TestCase("4 3 * 6 / 2 + 1 -", 3)]
        [TestCase("1 2 3 1 - * 2 / +", 3)]
        [TestCase("20 2 + 11 / 4 * 3 -", 5)]
        public void SolveRPN_ValidExpression_ReturnRPN(string expression, int expected)
        {
            int result = RPN.SolveRPN(expression);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SolveRPN_FractionWhileSolving_ReturnRPN()
        {
            var ex = Assert.Throws<ArgumentException>(() => RPN.SolveRPN("2 1 2 / *")) ;

            StringAssert.Contains("This isn't roman numeral!", ex.Message);
        }
    }
}
