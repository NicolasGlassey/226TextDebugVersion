using System;
using System.Collections.Generic;

namespace TextManager
{
    public class StatSentencePerfomer
    {
        #region private attributes
        private char[] charEndOfSentence = { '.', '?' };
        #endregion private attributes

        #region public methods
        /// <summary>
        /// This method is designed to count the amount of sentences in a text.
        /// </summary>
        /// <param name="textToAnalyze"></param>
        /// <returns>The amount of sentences in the text</returns>
        public int Count(string textToAnalyze)
        {
            if (textToAnalyze.Replace(" ", "") != "")
            {
                return textToAnalyze.Split(charEndOfSentence).Length;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is designed to get the average (number of words per sentence) in a text..
        /// </summary>
        /// <param name="textToAnalyze">Must be a text with a minimal of three sentences.</param>
        /// <returns>The average with a two decimal places</returns>
        public float Average(string textToAnalyze)
        {
            //Is the minimal of 3 sentences reached ?
            int amountOfSentences = this.Count(textToAnalyze);

            if(amountOfSentences >= 3)
            {
                int amountOfWordsInText = textToAnalyze.Split(" ").Length+1;
                return (float)(amountOfWordsInText / amountOfSentences);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is designed to get a list of pair containing a word and its amount of occurrence in the text.
        /// Upper or bigger case are considering to be the same letter, then the same word.
        /// The result of a word appears only if minimal 2 occurences were found.
        /// </summary>
        /// <param name="textToAnalyze"></param>
        /// <returns>Pair of word and amount of occurence. Order by amount of occurences.</returns>
        public List<Tuple<string,int>> Repetition(string textToAnalyze)
        {
            string textToAnalyzeCleaned = textToAnalyze.Replace(".", "").Replace("(", "").Replace(")","").ToLower();
            List<Tuple<string, int>> repetitions = new List<Tuple<string, int>>();

            //order text items 
            string[] words = textToAnalyzeCleaned.Split(" ");
            Array.Sort(words);

            //detect repetition
            string currentWord = "";
            int currentWordOccurence = 0;
            for (int i = 0; i < words.Length; i++)
            {
                //we detect an repetition
                if (currentWord == words[i])
                {
                    currentWordOccurence++;
                }
                //we change the current value
                else
                {
                    //we save the repetition
                    if (currentWordOccurence = 2)
                    {
                        Tuple<string, int> newResult = new Tuple<string, int>(currentWord, currentWordOccurence);
                        repetitions.Add(newResult);
                    }
                    //we change current value and reinitialize counter
                    if (i + 1 < words.Length)
                    {
                        currentWord = words[i];
                        currentWordOccurence = 1;
                    }
                }
            }
            repetitions.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            return repetitions;
        }
        #endregion public methods

        #region private methods
        #endregion private methods
    }

    #region Exceptions
    public class StatSentencePerfomerException : Exception { };
    public class TooShortTextException : StatSentencePerfomerException { };
    #endregion Exceptions
}
