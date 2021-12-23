using System;
using System.Collections.Generic;
using System.Linq;

namespace TextManager
{
    /// <summary>
    /// This class is designed to offer metrics on texte.
    /// Note : The text expected as parameter must respect basic structrual rules of any common languages.
    /// </summary>
    public class StatWordPerfomer
    {
        #region public methods
        /// <summary>
        /// This method is designed to count the amount of word in a text.
        /// Punctuation is not taken into account.
        /// </summary>
        /// <param name="textToAnalyze"></param>
        /// <returns>The amount of words in the text</returns>
        public int Count(string textToAnalyze)
        {
            int counter = textToAnalyze.Split(" ").Length;
            if (counter > 1)
            {
                return counter;
            }
            else
            {
                throw new EmptySentenceException();
            }
        }

        /// <summary>
        /// This method is designed to get the average (number of letters per word) in a text..
        /// Punctuation is not taken into account.
        /// </summary>
        /// <param name="textToAnalyze">Must be a sentence with a minimal of three words.</param>
        /// <returns>The average with a two decimal places</returns>
        public float Average(string textToAnalyze)
        {
            string textToAnalyseCleaned = textToAnalyze.Replace(".", "").Replace(",","");
            string[] textSplitted = textToAnalyseCleaned.Split(" ");
            if(textSplitted.Length >= 3)
            {
                float sumWordLength = 0;
                foreach (string word in textSplitted)
                {
                    sumWordLength += word.Length;
                    
                }
                return sumWordLength / textSplitted.Length;
            }
            else
            {
                throw new TooShortSentenceException();
            }
        }

        /// <summary>
        /// This method is designed to get a list of pair containing a letter and its amount of occurrence in the text.
        /// Poncution is taken into account.
        /// Upper or bigger case are considering to be the same letter.
        /// The result of a letter appears only if minimal 2 occurences were found.
        /// </summary>
        /// <param name="textToAnalyze"></param>
        /// <returns>Order by amount of occurences.</returns>
        public List<Tuple<string, int>> Repetition(string textToAnalyze)
        {
            string textToAnalyzeCleaned = textToAnalyze.Replace(".", "").Replace(" ", "").ToLower();
            List<Tuple<string, int>> repetitions = new List<Tuple<string, int>>();

            //order text items 
            List<char> charList = new List<char>();
            foreach (char letter in textToAnalyzeCleaned)
            {
                charList.Add(letter);
            }
            charList.Sort();

            //detect repetition
            char currentValue = ' ';
            int currentValueOccurence = 0;
            for (int i = 0; i < charList.Count(); i++)
            {
                //we detect an repetition
                if (currentValue == charList[i])
                {
                    currentValueOccurence++;
                }
                //we change the current value
                else
                {
                    //we save the repetition
                    if (currentValueOccurence >= 2)
                    {
                        Tuple<string, int> newResult = new Tuple<string, int>(currentValue.ToString(), currentValueOccurence);
                        repetitions.Add(newResult);
                    }
                    //we change current value and reinitialize counter
                    if (i + 1 < charList.Count())
                    {
                        currentValue = charList[i];
                        currentValueOccurence = 1;
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
    public class StatWordPerfomerException : Exception { };
    public class EmptySentenceException : StatWordPerfomerException { };
    public class TooShortSentenceException : StatWordPerfomerException { };
    #endregion Exceptions
}
