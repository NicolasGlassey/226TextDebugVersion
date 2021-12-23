using NUnit.Framework;
using System;
using System.Collections.Generic;
using TextManager;

namespace TestTextManager
{
    /// <summary>
    /// This test class validates the correct behavior of the StatWordPerformer class.
    /// </summary>
    /// <remarks>Source https://www.dialexa.com/our-insights/2019/12/9/five-software-development-best-practices</remarks>
    public class TestStatWordPerformer
    {
        #region private attributes
        private StatWordPerfomer statWordPerformer = null;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            this.statWordPerformer = new StatWordPerfomer();
        }

        [Test]
        public void T001_Count_SingleSentence_Success()
        {
            //given
            string sentenceToAnalyze = "Strive to keep your code simple.";
            int expectedResult = 6;
            int actualResult;

            //when
            actualResult = this.statWordPerformer.Count(sentenceToAnalyze);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T002_Count_MultipleSentences_Success()
        {
            //given
            string sentenceToAnalyze = "Strive to keep your code simple. The code simplicity movement goes hand in hand with other software principles such as DRY (Don’t Repeat Yourself).";
            int expectedResult = 24;
            int actualResult;

            //when
            actualResult = this.statWordPerformer.Count(sentenceToAnalyze);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T003_Count_EmptyText_ThrowEmptySentenceException()
        {
            //given
            string sentenceToAnalyze = "";
            int actualResult;
            //when
            Assert.Throws<EmptySentenceException>(() => actualResult = this.statWordPerformer.Count(sentenceToAnalyze));

            //then
            //Exception is thrown
        }

        [Test]
        public void T004_Average_NominalCase_Success()
        {
            //given
            string sentenceToAnalyze = "Code simplicity is an idea that came from Max Kanat-Alexander, a software developer at Google and Community Lead and Release Manager of the Bugzilla project.";
            float expectedResult = 5.24f;
            float actualResult;

            //when
            actualResult = this.statWordPerformer.Average(sentenceToAnalyze);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T005_Average_TooShortSentence_Success()
        {
            //given
            string sentenceToAnalyze = "Code simplicity";
            float actualResult;

            //when
            Assert.Throws<TooShortSentenceException>(() => actualResult = this.statWordPerformer.Average(sentenceToAnalyze));

            //then
            //Exception is thrown
        }

        [Test]
        public void T006_Repetition_NominalCase_Success()
        {
            //given
            string sentenceToAnalyze = "Strive to keep your code simple.";
            List<Tuple<string, int>> expectedResults = new List<Tuple<string, int>>{
                {new Tuple<string,int>("e", 5)},
                {new Tuple<string,int>("o", 3)},
                {new Tuple<string,int>("i", 2)},   
                {new Tuple<string,int>("p", 2)},
                {new Tuple<string,int>("r", 2)},
                {new Tuple<string,int>("s", 2)},
                {new Tuple<string,int>("t", 2)}
            };
            List<Tuple<string, int>> actualResults;

            //when
            actualResults = this.statWordPerformer.Repetition(sentenceToAnalyze);

            //then
            Assert.AreEqual(expectedResults.Count, actualResults.Count);

            for (int i = 0; i < expectedResults.Count; i++)
            {
                Assert.AreEqual(expectedResults[i].Item1, actualResults[i].Item1);
                Assert.AreEqual(expectedResults[i].Item2, actualResults[i].Item2);
            }
        }
    }
}