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






        //        [TestMethod]
        //        public void TestPrintIntro()
        //        {

        //            string expectedOutput = $@">>Hello from the Math Expression Console!
        //>>Please enter a math expression of the form <int><operator><int>.
        //>>The operator can be +, -, *, or /, and the int can be negative.";

        //            IntelliTect.TestTools.Console.ConsoleAssert.Expect(
        //                expectedOutput, MathExpressions.PrintIntro);
        //        }


        //        [TestMethod]
        //        public void TestPrintIntro()
        //        {

        //            string expectedOutput = $@">>Hello from the Math Expression Console!
        //>>Please enter a math expression of the form <int><operator><int>.
        //>>The operator can be +, -, *, or /, and the int can be negative.";

        //            IntelliTect.TestTools.Console.ConsoleAssert.Expect(
        //                expectedOutput, MathExpressions.PrintIntro);
        //        }


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
