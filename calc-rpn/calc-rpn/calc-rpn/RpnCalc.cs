/**
 * Post to infix RPN notation conveter copied from 
 * https://rosettacode.org/wiki/Parsing/RPN_to_infix_conversion#C.23
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    public class RpnCalc
    {
        class Operator
        {
            public Operator(char t, int p, bool i = false)
            {
                operatorChar = t;
                operatorPrecedence = p;
                IsRightAssociative = i;
            }

            public char operatorChar { get; private set; }
            public int operatorPrecedence { get; private set; }
            public bool IsRightAssociative { get; private set; }
        }
        private static IReadOnlyDictionary<char, Operator> operatorPrecedence = new Dictionary<char, Operator>
        {
            { '+', new Operator('+', 2) },
            { '-', new Operator('-', 2) },
            { '/', new Operator('/', 3) },
            { '*', new Operator('*', 3) },
            { '^', new Operator('^', 4, true) }
        };

        private class Expression
        {
            public String expressionToEvaluate;
            public Operator op;

            public Expression(String expressionString)
            {
                expressionToEvaluate = expressionString;
            }

            public Expression(String e1, String e2, Operator o)
            {
                expressionToEvaluate = String.Format("{0} {1} {2}", e1, o.operatorChar, e2);
                op = o;
            }
        }
        public static String PostfixToInfix(String postfix)
        {
            var stack = new Stack<Expression>();

            foreach (var token in Regex.Split(postfix, @"\s+"))
            {
                char c = token[0];

                var op = operatorPrecedence.FirstOrDefault(kv => kv.Key == c).Value;
                if (op != null && token.Length == 1)
                {
                    Expression rhs = stack.Pop();
                    Expression lhs = stack.Pop();

                    int opPrec = op.operatorPrecedence;

                    int lhsPrec = lhs.op != null ? lhs.op.operatorPrecedence : int.MaxValue;
                    int rhsPrec = rhs.op != null ? rhs.op.operatorPrecedence : int.MaxValue;

                    if ((lhsPrec < opPrec || (lhsPrec == opPrec && c == '^')))
                        lhs.expressionToEvaluate = '(' + lhs.expressionToEvaluate + ')';

                    if ((rhsPrec < opPrec || (rhsPrec == opPrec && c != '^')))
                        rhs.expressionToEvaluate = '(' + rhs.expressionToEvaluate + ')';

                    stack.Push(new Expression(lhs.expressionToEvaluate, rhs.expressionToEvaluate, op));
                }
                else
                {
                    stack.Push(new Expression(token));
                }

                // print intermediate result
                Console.WriteLine("{0} -> [{1}]", token,
                    string.Join(", ", stack.Reverse().Select(e => e.expressionToEvaluate)));
            }
            return stack.Peek().expressionToEvaluate;
        }

}
}
