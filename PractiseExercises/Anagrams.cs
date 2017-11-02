using System;
using System.Collections.Generic;

namespace PractiseExercises
{
    internal class Anagrams
    {



        internal static void Run()
        {
            /*
                        Given an array of strings, return the strings that are anagrams.

                        ["eat", "tan", "ate", "nat", "bat", "tea"], 
                        //the result should be
                        [
                          ["ate", "eat","tea"],
                          ["nat","tan"],
                          ["bat"]
                        ]
            */
            string[] wordsToCheck = new string[] { "eat", "tan", "ate", "nat", "bat", "tea", "pong", "rats","star", "live", "evil" };

            var outputWords = GetListOfAnagrams(wordsToCheck);


            foreach (var wordlist in outputWords)
            {
                Console.Write("[");

                string strOut = "";
                foreach (string word in wordlist)
                {
                    strOut += word + ",";
                }
                Console.Write("{0}],", strOut.TrimStart(',').TrimEnd(','));
                Console.WriteLine("");
            }

        }

        private static List<List<string>> GetListOfAnagrams(string[] wordsToCheck)
        {
            if(wordsToCheck == null || wordsToCheck.Length < 2)
            { throw new ArgumentNullException(); }

            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();

            List<List<string>> resultList = new List<List<string>>(); 

            var previous = "";

            for(int i = 0; i< wordsToCheck.Length; i++)
            {

                var current = wordsToCheck[i];

                //sort the word into letter order

                var listChar = new List<char>();
                
                listChar.AddRange(current.ToCharArray());

                listChar.Sort();

                string sortedCurrentWord = "";

                foreach (char c in listChar)
                {
                    sortedCurrentWord += c;
                }

                //only check if there is a previous
                if (!string.IsNullOrEmpty(previous))
                {
                    if(IsAnagram(previous, current) || dictionary.ContainsKey(sortedCurrentWord))
                    {
                        //should already be in the list do retrieve it and add the new word to the string array 
                        var oldStrArr = dictionary[sortedCurrentWord];

                        //expand new array to be one element larger
                        var replacementStrArr = new string[oldStrArr.Length + 1];

                        oldStrArr.CopyTo(replacementStrArr, 0);

                        //put new element on the end
                        replacementStrArr[replacementStrArr.Length - 1] = current;

                        dictionary[sortedCurrentWord] = replacementStrArr;

                    }
                }
                
                //add the new item to dict with it's sorted word as the key
                if (!dictionary.ContainsKey(sortedCurrentWord))
                {
                    dictionary.Add(sortedCurrentWord, new string[] { current });
                }

                previous = current;
            }

            foreach(var item in dictionary)
            {
                var strList = new List<string>();

                strList.AddRange(item.Value);

                resultList.Add(strList);
            }

            return resultList;
        }

        public static bool IsAnagram(string firstWord, string secondWord)
        {
            bool areAnagrams = false;

            if(firstWord.Length != secondWord.Length)
            {
                return false;
            }

            var sortedFirstWord = new List<char>();

            sortedFirstWord.AddRange(firstWord.ToCharArray());

            sortedFirstWord.Sort();

            var sortedSecondWord = new List<char>();

            sortedSecondWord.AddRange(secondWord.ToCharArray());

            sortedSecondWord.Sort();

            areAnagrams = (sortedFirstWord == sortedSecondWord);

            return areAnagrams;
                 

        }

    }
    
}