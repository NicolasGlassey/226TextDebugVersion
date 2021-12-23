using System;
using System.Collections.Generic;

namespace TextManager
{
    public class TextFormater
    {
        #region public methods
        public string Reverse(string textToReverse)
        {
            string textReversed = "";
            //Detecte sentences
            string[] sentencesToReverse = textToReverse.Split(".");

            foreach (string sentenceToReverse in sentencesToReverse)
            {
                if(sentenceToReverse != "")
                {
                    //Save comas' position
                    int sentenceLength = sentenceToReverse.Length;
                    //Clean text to reverse
                    string sentenceToReverseCleaned = sentenceToReverse.Replace(".", "");

                    //Split sentence in word
                    string[] words = sentenceToReverseCleaned.Split(" ");

                    //Coma move
                    bool moveComa = false;
                    for (int i = 0; i < words.Length; i++)
                    {
                        bool protection = false;
                        if (moveComa && !protection)
                        {
                            words[i] = words[i] + ",";
                            moveComa = false;
                            protection = true;
                        }
                        if (words[i].Contains(",") && !protection)
                        {
                            words[i] = words[i].Replace(",", "");
                            moveComa = true;
                            protection = true;
                        }
                    }

                    //Update Upper and Lower Case
                    int firstWordIndex = 0;
                    if (words[0] == "")
                    {
                        firstWordIndex++;
                    }
                    words[firstWordIndex] = words[firstWordIndex].ToLower();
                    
                    string lastWord = words[words.Length - 1];
                    words[words.Length - 1] = lastWord.Substring(0, 1).ToUpper() + lastWord.Substring(1, lastWord.Length - 1);

                    //Rebuilt sentence in reverse order
                    string sentenceReversed = "";
                    for (int i = words.Length - 1; i >= 0; i--)
                    {
                        if (words[i] != "")
                        {
                            sentenceReversed += words[i] + " ";
                        }    
                    }
                    if(textReversed != "")
                    {
                        textReversed += " ";
                    }
                    textReversed += sentenceReversed.Trim() + ".";
                }

            }
            return textReversed;
        }
        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
