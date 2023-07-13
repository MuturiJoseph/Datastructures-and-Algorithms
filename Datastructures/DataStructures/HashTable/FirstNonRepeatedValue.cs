using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures
{
    public class DataStructures
    {
        public char FirstNonRepeatedValue(string sentence)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (var ch in sentence.ToLower().ToCharArray())
            {
                var count = map.ContainsKey(ch) ? map[ch] : 0;
                map.Remove(ch);
                map.Add(ch, count + 1);
            }


            foreach (var c in map)
                if (map[c.Key] == 1)
                    return c.Key;

            return char.MinValue;


            //var result = sentence
            //    .ToLower()
            //    .Replace(" ", "");
            //var array = result.ToArray();
            //string firstNonRepeating = "";
            //int count = 1;

            //Dictionary<int,char> map = new Dictionary<int,char>();

            //for(int i  = 0; i < array.Length; i++)
            //{
            //    map.Add(i+1,array[i]);
            //}

            //while(firstNonRepeating == "")
            //{
            //    var toRemove = map[count];
            //    map.Remove(count);
            //    if (!map.ContainsValue(toRemove))
            //        firstNonRepeating = toRemove.ToString();
            //    count++;
            //}

            //Console.WriteLine(firstNonRepeating);
        }
    }
}

