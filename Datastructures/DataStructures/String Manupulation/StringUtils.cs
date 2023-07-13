using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datastructures.DataStructures.String_Manupulation
{
    public class StringUtils
    {
        public static int CountVowels(string str)
        {
            if (str == null)
                return 0;

            int count = 0;
            string vowels = "a,e,i,o,u";

            foreach (char ch in str.ToLower().ToCharArray())
                if(vowels.Contains(ch))
                    count++;

            return count;
        }

        public static string Reverse(string str)
        {
            if (str == null)
                return "";

            StringBuilder reversed = new StringBuilder();

            for(int i = str.Length - 1;i >= 0;i--)
                reversed.Append(str.ElementAt(i));

            return reversed.ToString();
        }

        public static string ReverseWords(string sentence)
        {
            if (sentence == null)
                return "";

            string[] words = sentence.Split(' ');
            StringBuilder reversed = new StringBuilder();

            for (int i = words.Length - 1; i >= 0; i--)
                reversed.Append(words[i] + ' ');

            return reversed.ToString().Trim();
        }

        public static bool AreRotations(string str1,string str2)
        {
            if(str1 == null || str2 == null)
                return false;

            return str1.Length == str2.Length && (str1 + str2).Contains(str2);


            //ABCD 1rotation TO RIGHT  -> DABC
            //      2//                -> CDAB
            //      3//                -> BCDA
            //      4//                -> ABCD
            //ABCDABCD

            //if(str1.Length != str2.Length)
            //    return false;

            //if(!(str1 + str2).Contains(str2))
            //    return false;

            //return true;
        }

        public static string RemoveDuplicates(string str)
        {
            if (str == null)
                return "";

            StringBuilder output = new StringBuilder();
            HashSet<char> seen = new HashSet<char>();

            foreach(char c in str)
                if (!seen.Contains(c))
                {
                    seen.Add(c);
                    output.Append(c);
                }

            return output.ToString();
        }

        public static char GetMaxOccuringChar(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException();

            //Dictionary<char,int> frequencies = new Dictionary<char,int>();

            //foreach(char ch in str)
            //{
            //    if(frequencies.ContainsKey(ch))
            //        frequencies[ch] = frequencies[ch] + 1;
            //    frequencies.Add(ch,1);
            //}
            const int ASCII_SIZE = 256;
            int[] frequencies = new int[ASCII_SIZE];

            foreach(char ch in str.Replace(" ","").ToCharArray())
                frequencies[ch]++;

            int max = 0;
            char result = ' ';
            for(var i = 0; i < frequencies.Length; i++)
                if (frequencies[i] > max)
                {
                    max = frequencies[i];
                    result = (char) i;
                }

            return result;
        }

        public static string Capitalize(string sentence)
        {
            if (sentence == null || string.IsNullOrEmpty(sentence.Trim()))
                return "";

            string pattern = "\\s+";
            string replacement = " ";
            var newSentence = Regex.Replace(sentence, pattern, replacement);

            string[] words = newSentence
                .Trim()
                .Split(' ');

            for(var i = 0;i < words.Length;i++)
                words[i] = words[i].Substring(0,1).ToUpper() + words[i].Substring(1).ToLower();

            return string.Join(" ",words);
        }

        // O(n log n)
        public static bool AreAnagrams(string str1,string str2)
        {
            if(str1 == null || str2 == null || str1.Length != str2.Length)
                return false;

            var array1 = str1.ToCharArray();
            Array.Sort(array1);

            var array2 = str2.ToCharArray();
            Array.Sort(array2);

            for(int i = 0;i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }

       //O(n)
        public static bool AreAnagrams2(string str1, string str2)
        {
            if(str1 == null || str2 == null || str1.Length != str2.Length)
                return false;

            const int ENGLISH_ALPHABET = 26;
            int[] frequencies = new int[ENGLISH_ALPHABET];

            var first = str1.ToLower();
            for(int i = 0;i < first.Length;i++)
                frequencies[first.ElementAt(i) - 'a']++;

            var second = str2.ToLower();
            for(int i = 0; i < second.Length; i++)
            {
                var index = second.ElementAt(i) - 'a';
                if (frequencies[index] == 0)
                    return false;

                frequencies[index]--;
            }

            return true;
        }

        public static bool IsPalindrome(string word)
        {
            if(word == null)
                return false;

            var left = 0;
            var right = word.Length - 1;

            while(left < right)
                if(word.ElementAt(left++) != word.ElementAt(right--))
                    return false;

            return true;
        }

    }
}
