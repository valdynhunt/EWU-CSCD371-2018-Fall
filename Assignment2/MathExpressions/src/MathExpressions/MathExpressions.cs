using System;
using System.Linq.Expressions;

namespace MathExpressions
{
    public class MathExpressions
    {
        private string expr;
        private char op;
        private string[] parts;
        private bool isSubtraction;

        public MathExpressions()
        {

        }

        public string GetExpression()
        {
            return this.expr;
        }

        public void GetInput()
        {

            this.expr = Console.ReadLine();
            this.op = FindOperator(expr);
            bool good = ValidateExpr();

            while (!good)
            {
                this.expr = Console.ReadLine();
                this.op = FindOperator(expr);
                good = ValidateExpr();
            }
        }

        public void SplitString()
        {
            if (op.Equals("-"))
            {

            }
            parts = this.expr.Split(this.op);

            for (int i = 0; i < parts.Length; i++)
            {
                Console.Write("part" + i);
                Console.WriteLine(parts[i]);
            }
        }

        public bool ValidateOperands()
        {
            foreach (string operand in parts) {
                if (int.TryParse(operand, out int result))
                {
                    Console.WriteLine(result.ToString());
                }
                else
                {
                    Console.WriteLine("Your input expression was not valid....");
                }
                Console.WriteLine("result is: " + result);
            }


            // int ans = 5 + 3;
            // Evaluate the form for all of the four operators below
            // +, -, *, /
            return false;
        }

        public void EvaluateExpression()
        {

        }


        public static void Main(string[] args)
        {
            MathExpressions me = new MathExpressions();
            PrintIntro();
            me.GetInput();
            me.SplitString();
            me.ValidateOperands();

        }


        private bool ValidateExpr()
        {
            bool good = false;
            Console.WriteLine("You entered {0}", this.expr);
            this.op = FindOperator(this.expr);
            if (this.op == '\0')
            {
                Console.WriteLine("Your entry is invalid, please try again...");
                this.expr = Console.ReadLine();
            }
            else
            {
                good = true;
            }

            return good;
        }

        private static int SubtractionAlsoHasNegNumbers()
        {
            int num = 0;
            // get count of minus
            return num;
        }

        private static char FindOperator(string expr)
        {
            if (expr.Contains('+')) return '+';
            else if (expr.Contains('-')) return '-';
            else if (expr.Contains('*')) return '*';
            else if (expr.Contains('/')) return '/';
            else return '\0';
        }

        public static void PrintIntro()
        {
            Console.WriteLine("Hello from the Math Expression Console!");
            Console.WriteLine("Please enter a math expression of the form <int><operator><int>.");
            Console.WriteLine("The operator can be +, -, *, or /, and the int can be negative.");
        }
    }
}
