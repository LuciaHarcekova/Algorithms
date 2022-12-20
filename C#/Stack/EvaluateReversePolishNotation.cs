/*
150. Evaluate Reverse Polish Notation
Link: https://leetcode.com/problems/evaluate-reverse-polish-notation/

Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, and /. Each operand may be an integer or
another expression.

Note that division between two integers should truncate toward zero.

It is guaranteed that the given RPN expression is always valid. That means
the expression would always evaluate to a result, and there will not be any
division by zero operation.

Example 1:
Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9

Example 2:
Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6

Example 3:
Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 17 + 5
= 22
*/

public class Solution {
    public int EvalRPN(string[] tokens) {
        var ops = new Dictionary<string, Func<int, int, int>> {
            {"+", (n1, n2) => n1 + n2},
            {"-", (n1, n2) => n1 - n2},
            {"*", (n1, n2) => n1 * n2},
            {"/", (n1, n2) => n1 / n2}
        };
        Stack<int> stack = new Stack<int>();

        foreach (string s in tokens) {
            // check if it's operation
            if (ops.ContainsKey(s)) { 
                var func = ops[s];
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(func(a, b));
            } else {
                stack.Push(Int32.Parse(s));
            }
        }

        return stack.Pop();
    }
}