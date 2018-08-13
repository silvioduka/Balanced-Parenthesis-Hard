/*
Balanced Parenthesis - Hard from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-08

Create a program that checks if in a given string expression all the parenthesis are balanced. 
For Example: 
(test) - valid 
(no() - invalid 
()(()) - valid 
(123(456)(7))( - invalid 
(val()id) - valid 

Also, take into account the "\" escape sequences: 
(nope\) - invalid 
(v\(al) - valid 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParenthesis
{
    class Program
    {
        static string input = @"{{[(123(456)}(7))(v\(al)\]]"; // Insert here a string to check if all the parenthesis are balanced

        static void Main(string[] args)
        {
            Stack<char> p = new Stack<char>();

            int rb = 0, sb = 0, cb = 0;
            char o = ' ';
            bool valid = true;

            foreach (char c in input)
            {
                if (o != '\\')
                {
                    if (c == '(') { rb++; p.Push(c); }
                    if (c == ')') { rb--; if (p.Pop() != '(') valid = false; }
                    if (c == '[') { sb++; p.Push(c); }
                    if (c == ']') { sb--; if (p.Pop() != '[') valid = false; }
                    if (c == '{') { cb++; p.Push(c); }
                    if (c == '}') { cb--; if (p.Pop() != '}') valid = false; }
                }

                o = c;
            }

            Console.WriteLine($"Input string: {input}\nParenthesis {((p.Count == 0 && valid == true) ? "are" : "are NOT")} balanced!");
            if (valid == false) Console.WriteLine($"WRONG Parenthesis order!");
            if (rb != 0) Console.WriteLine($"Missing {Math.Abs(rb)} of {((rb < 0) ? "(" : ")")}");
            if (sb != 0) Console.WriteLine($"Missing {Math.Abs(sb)} of {((sb < 0) ? "[" : "]")}");
            if (cb != 0) Console.WriteLine($"Missing {Math.Abs(cb)} of {((cb < 0) ? "{" : "}")}");
        }
    }
}