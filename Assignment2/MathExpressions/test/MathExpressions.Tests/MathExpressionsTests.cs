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
        public void TestFindOperator()
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

        //=========================

        //[TestMethod]
        //public void ValidateExpr_returns_false_if_expression_is_invalid()
        //{
        //    MathExpressions me = new MathExpressions();
        //    string ex = "2^5";
        //    me.SetExpression(ex);
        //    string expectedOutput = "Your entry is invalid, please try again...";
        //    Assert.AreEqual(expectedOutput, me.ValidateExpr(me.GetExpression()));
        //}


        //private bool ValidateExpr()
        //{
        //    bool good = false;
        //    Console.WriteLine("You entered {0}", this.expr);
        //    this.op = FindOperator(this.expr);
        //    if (this.op == '\0')
        //    {
        //        Console.WriteLine("Your entry is invalid, please try again...");
        //        this.expr = Console.ReadLine();
        //    }
        //    else
        //    {
        //        good = true;
        //    }

        //    return good;
        //}

        //=========================

        public bool ValidateFirstOperandInRange(string firstOperand)
        {
            int max = Int32.MaxValue;
            int min = Int32.MinValue;
            if (int.Parse(firstOperand) > max) return false;
            if (int.Parse(firstOperand) < min) return false;
            return true;
        }

        public bool ValidateLastOperandInRange(string lastOperand)
        {
            return ValidateFirstOperandInRange(lastOperand);
        }


        public bool checkDivideByZero(string lastOperand)
        {
            if (lastOperand == "0") return true;
            else return false;
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
        public void Last_operand_in_range_returns_true()
        {
            MathExpressions me = new MathExpressions();
            string lastOperand = "6";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, me.ValidateFirstOperandInRange(lastOperand));
        }


        [TestMethod]
        public void Check_divide_by_zero_returns_false_when_lastOperand_is_0()
        {
            MathExpressions me = new MathExpressions();
            string lastOperand = "0";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, me.checkDivideByZero(lastOperand));
        }


        //        [TestMethod]
        //        public void TestPrintIntro()
        //        {

        //            string expectedOutput = $@">>Hello from the Math Expression Console!
        //>>Please enter a math expression of the form <int><operator><int>.
        //>>The operator can be +, -, *, or /, and the int can be negative.";

        //            IntelliTect.TestTools.Console.ConsoleAssert.Expect(
        //                expectedOutput, MathExpressions.PrintIntro);
        //        }

    }
}


/*

    Support the four basis arithmetic operators:
addition (+)
subtractions (-)
multiplication (*)
division (/)
    
Integers may be positive or negative.

Test potential failure cases:
zero
int.MinValue
or int.MaxValue

Remember that a unit test should test only a single condition, not multiple conditions. 
For example rather than writing a unit test for addition, create separate unit tests to handle

=============================================================================
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter03.Listing03_03.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Main_WriteInventions()
        {
            const string expected =
@"Bifocals (1784)
Phonograph (1877)";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(
                expected, Program.Main);
        }
    }
}
===============================================================================
*/
