using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures.Stacks
{
    public class BalancedString
    {
        private List<char> leftBracket = new List<char> { '(', '{', '[' };
        private List<char> rightBracket = new List<char> { ')', '}', ']' };
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var ch in s)
            {
                if (IsLeftBracket(ch))
                    stack.Push(ch);

                if (IsRightBracket(ch))
                {
                    if (!stack.Any())
                        return false;

                    var top = stack.Pop();
                    if (!BracketsMatch(top, ch))
                        return false;
                }
            }
            return !stack.Any();
        }
        private bool IsLeftBracket(char ch)
        {
            return leftBracket.Contains(ch);
        }
        private bool IsRightBracket(char ch)
        {
            return rightBracket.Contains(ch);
        }
        private bool BracketsMatch(char left, char right)
        {
            return leftBracket.IndexOf(left) == rightBracket.IndexOf(right);
        }
    }
}
