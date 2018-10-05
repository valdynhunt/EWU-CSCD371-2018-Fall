using System;
using System.Linq.Expressions;

namespace MathExpressions
{
    public class MathExpressions
    {
        private string expr;
        private string tempExpr;
        private char op;
        private string[] parts;
        private bool isSubtraction;
        private double result;
        private bool negNumAtBeginning;
        private string firstOperand;
        private string lastOperand;

        public MathExpressions()
        {

        }

        public void CalcLoop()
        {
            int numMinuses;
            PrintIntro();
            GetInput();
            Console.WriteLine("1");
            if (op == '-')
            {
                numMinuses = SubtractionAlsoHasNegNumbers();
                if (numMinuses > 1)
                {
                    if (negNumAtBeginning && numMinuses == 2) // negative first operand
                    {
                        tempExpr = expr.Substring(1);
                        parts = this.tempExpr.Split(this.op);

                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (i == 0)
                            {
                                firstOperand = "-" + parts[i];
                                parts[i] = firstOperand;
                            }
                            if (i == 1) lastOperand = parts[i];
                            Console.Write("part" + i);
                            Console.WriteLine(parts[i]);
                        }

                    }
                    else if (numMinuses == 2) {
                        int index = expr.IndexOf(op);
                        firstOperand = expr.Substring(0, index - 1);
                        lastOperand = expr.Substring(index + 1);

                    }
                    else // both operands are negative
                    {
                        tempExpr = expr.Substring(1);
                        int nextMinus = tempExpr.IndexOf(op);
                        firstOperand = expr.Substring(0, nextMinus);
                        lastOperand = expr.Substring(nextMinus + 1);
                    }

                    if (numMinuses == 1) SplitString();
                    ValidateOperands();
                    result = int.Parse(parts[0]) - int.Parse(parts[1]);
                    Console.WriteLine("2");

                    Console.WriteLine("result: " + result);
                    // EvaluateExpression();
                }
            }
            else
            {
                SplitString();
                ValidateOperands();
                EvaluateExpression();
                Console.WriteLine("3");

            }
        }

        public string GetExpression()
        {
            return this.expr;
        }


        public void SetExpression(string ex)
        {
            this.expr = ex;
        }

        public void GetInput()
        {

            this.expr = Console.ReadLine();
            this.op = FindOperator(expr);
            bool good = ValidateExpr(expr);

            while (!good)
            {
                this.expr = Console.ReadLine();
                this.op = FindOperator(expr);
                good = ValidateExpr(expr);
            }
        }

        public void SplitString()
        {
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
                if (int.TryParse(operand, out int res))
                {
                    Console.WriteLine(res.ToString());
                }
                else
                {
                    Console.WriteLine("Your input expression was not valid....");
                }
                Console.WriteLine("result is: " + res);
            }


            // int ans = 5 + 3;
            // Evaluate the form for all of the four operators below
            // +, -, *, /
            return false;
        }

        public void EvaluateExpression()
        {
            if (op == '+') result = int.Parse(parts[0]) + int.Parse(parts[1]);
            else if (op == '*') result = int.Parse(parts[0]) * int.Parse(parts[1]);
            else if (op == '/') result = int.Parse(parts[0]) / (double) int.Parse(parts[1]);
            else if (op == '-') result = int.Parse(parts[0]) - int.Parse(parts[1]);

            Console.WriteLine("result: " + result);
        }





        public bool ValidateExpr(string expr)
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

        private int SubtractionAlsoHasNegNumbers()
        {
            int index = 0;
            int count = 0;
            int exprLength = expr.Length;
            // get count of how many minus
            if (expr[0] == '-')
            {
                negNumAtBeginning = true;
                count++;
            }

            tempExpr = "";
            for (int i = 1; i < expr.Length; i++)
            {
                tempExpr = expr.Substring(i);
                if (tempExpr[0] == '-') count++;
            }

            return count;
        }

        public static char FindOperator(string expr)
        {
            if (expr.Contains('+')) return '+';
            else if (expr.Contains('*')) return '*';
            else if (expr.Contains('/')) return '/';
            else if (expr.Contains('-')) return '-';
            else return '\0';
        }

        public static void PrintIntro()
        {
            Console.WriteLine("Hello from the Math Expression Console!");
            Console.WriteLine("Please enter a math expression of the form <int><operator><int>.");
            Console.WriteLine("The operator can be +, -, *, or /, and the int can be negative.");
        }

        public static void Main(string[] args)
        {
            MathExpressions me = new MathExpressions();
            me.CalcLoop();

        }
    }
}
