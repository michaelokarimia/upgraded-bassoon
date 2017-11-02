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

            var outputWords = new List<List<string>>();
                

            var dictionary = GetListOfAnagrams(wordsToCheck);

            foreach (var item in dictionary)
            {
                var strList = new List<string>();

                strList.AddRange(item.Value);

                outputWords.Add(strList);
            }


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

        private static Dictionary<string, string[]> GetListOfAnagrams(string[] wordsToCheck)
        {
            if(wordsToCheck == null || wordsToCheck.Length < 2)
            { throw new ArgumentNullException(); }

            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();

            List<List<string>> resultList = new List<List<string>>(); 

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

                // dictonaray key match means there's an anagram already
                if (dictionary.ContainsKey(sortedCurrentWord))
                {
                    //should already be in the list so retrieve it and add the new word to the string array 
                    var oldStrArr = dictionary[sortedCurrentWord];

                    //expand new array to be one element larger
                    var replacementStrArr = new string[oldStrArr.Length + 1];

                    oldStrArr.CopyTo(replacementStrArr, 0);

                    //put new element on the end
                    replacementStrArr[replacementStrArr.Length - 1] = current;

                    dictionary[sortedCurrentWord] = replacementStrArr;

                }
                else
                {   // it's a new word so add the word as new item to dict with it's sorted chars as the key
                    dictionary.Add(sortedCurrentWord, new string[] { current });
                }

            }

          

            return dictionary;
        }
    }
    
}