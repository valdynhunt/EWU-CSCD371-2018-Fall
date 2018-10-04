using System;
using System.Linq.Expressions;

namespace MathExpressions
{
    public class MathExpressions
    {

        public static void Main(string[] args)
        {
            printIntro();
            bool noGood = true;
            string expr;
            char op;
            expr = Console.ReadLine();
            op = FindOperator(expr);

            while (noGood)
            {
                Console.Write("You entered {0}! ", expr);
                if (op == '\0') Console.WriteLine("Your entry is invalid, please try again...");
                else noGood = false;
            }

            string[] parts = expr.Split(op);
            for (int i = 0; i < parts.Length; i++)
            {
                Console.WriteLine(parts[i]);
            }

            if (int.TryParse(expr, out int result))
            {
                Console.WriteLine(result.ToString());
            } else
            {
                Console.WriteLine("Your input expression was not valid.");
            }
           // int ans = 5 + 3;
            // Evaluate the form for all of the four operators below
            // +, -, *, /
        }

        private static char FindOperator(string expr)
        {
            if (expr.Contains('+')) return '+';
            else if (expr.Contains('-')) return '-';
            else if (expr.Contains('*')) return '*';
            else if (expr.Contains('/')) return '/';
            else return '\0';
        }

        public static void printIntro()
        {
            Console.WriteLine("Hello from the Math Expression Console!");
            Console.WriteLine("Please enter a math expression of the form <int><operator><int>.");
            Console.WriteLine("The operator can be +, -, *, or /, and the int can be negative.");
        }
    }
}
