using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathExpressions.Tests
{
    [TestClass]
    public class MathExpressionsTests
    {
        [TestMethod]
        public void TestPrintIntro()
        {

            string expectedOutput = $@">>Hello from the Math Expression Console!
>>Please enter a math expression of the form <int><operator><int>.
>>The operator can be +, -, *, or /, and the int can be negative.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(
                expectedOutput, MathExpressions.PrintIntro);
        }


        [TestMethod]
        public void FindOperator_returns_operator()
        {
            string expr = "3+4";
            char expectedOutput = '+';
            Assert.AreEqual(expectedOutput, MathExpressions.FindOperator(expr));

            expr = "7*9";
            expectedOutput = '*';
            Assert.AreEqual(expectedOutput, MathExpressions.FindOperator(expr));

            expr = "8/4";
            expectedOutput = '/';
            Assert.AreEqual(expectedOutput, MathExpressions.FindOperator(expr));

            expr = "6-5";
            expectedOutput = '-';
            Assert.AreEqual(expectedOutput, MathExpressions.FindOperator(expr));
        }


        [TestMethod]
        public void ValidateExpr_returns_true_if_expression_is_valid()
        {
            MathExpressions me = new MathExpressions();
            string ex = "2*5";
            me.SetExpression(ex);
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, me.ValidateExpr(me.GetExpression()));
        }


        [TestMethod]
        public void Last_operand_in_range_returns_true()
        {
            MathExpressions me = new MathExpressions();
            string lastOperand = "6";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, me.ValidateFirstOperandInRange(lastOperand));
        }


        [TestMethod]
        public void First_operand_in_range_returns_true()
        {
            MathExpressions me = new MathExpressions();
            string firstOperand = "23546";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, me.ValidateFirstOperandInRange(firstOperand));
        }


        [TestMethod]
        public void Check_divide_by_zero_returns_true_when_lastOperand_is_0()
        {
            MathExpressions me = new MathExpressions();
            string lastOperand = "0";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, me.CheckDivideByZero(lastOperand));
        }


        [TestMethod]
        public void Check_divide_by_zero_returns_false_when_lastOperand_is_not_0()
        {
            MathExpressions me = new MathExpressions();
            string lastOperand = "7";
            bool expectedOutput = false;
            Assert.AreEqual(expectedOutput, me.CheckDivideByZero(lastOperand));
        }
    }
}


