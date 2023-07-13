using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures
{
    public class FirstRepeatedChar
    {
        public char firstRepeatedCha(string sentence)
        {
            HashSet<char> set = new HashSet<char>();

            foreach(var cha in sentence.Replace(" ", "").ToCharArray())
            {
                if (set.Contains(cha))
                    return cha;
                set.Add(cha);
            }

            return char.MinValue;
        }
    }
}
