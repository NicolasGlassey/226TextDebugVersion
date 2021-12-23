using NUnit.Framework;
using System;
using System.Collections.Generic;
using TextManager;

namespace TestTextManager
{
    public class TestStatSentencePerformer
    {
        #region private attributes
        private StatSentencePerfomer statSentensePerformer = null;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            this.statSentensePerformer = new StatSentencePerfomer();
        }

        [Test]
        public void T001_Count_NominalCase_Success()
        {
            //given
            string textToAnalyze =  "Is there an \"ideal software development project,\" and, if so, " +
                                    "what are steps you should take to achieve this ideal state? " +
                                    "There are strict guidelines and different software development " +
                                    "best practices methodologies such as scrum or extreme " +
                                    "programming, but I have come to the realization that it's not " +
                                    "always possible – or wise – to strictly follow these processes.";
            int expectedResult = 2;
            int actualResult;

            //when
            actualResult = this.statSentensePerformer.Count(textToAnalyze);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T002_Count_EmptyText_ThrowEmptyTextException()
        {
            //given
            string textToAnalyze =  "                ";
            int actualResult;

            //when
            Assert.Throws<EmptyTextException>(() => actualResult = this.statSentensePerformer.Count(textToAnalyze));

            //then
            //Exception is thrown
        }

        [Test]
        public void T003_Average_NominalCase_Success()
        {
            //given
            string textToAnalyze = "Is there an \"ideal software development project,\" and, if so, " +
                                    "what are steps you should take to achieve this ideal state? " +
                                    "There are strict guidelines and different software development " +
                                    "best practices methodologies such as scrum or extreme " +
                                    "programming, but I have come to the realization that it's not " +
                                    "always possible – or wise – to strictly follow these processes. " +
                                    "It doesn’t imply that we don’t strive to accurately implement these " +
                                    "methods; we just need to stay flexible.";
            float expectedResult = 25.0f;
            float actualResult;

            //when
            actualResult = this.statSentensePerformer.Average(textToAnalyze);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T004_Average_TooShortText_ThrowTooShortTextException()
        {
            //given
            string sentenceToAnalyze = "This is the first sentence. This is the second sentence.";
            float actualResult;

            //when
            Assert.Throws<TooShortTextException>(() => actualResult = this.statSentensePerformer.Average(sentenceToAnalyze));

            //then
            //Exception is thrown
        }

        [Test]
        public void T005_Repetition_NominalCase_Success()
        {
            //given
            string textToAnalyze =  "Initially I was a skeptic of Test Driven Development (TDD) as it seemed " +
                                    "too prescriptive. Over time, I have realized that TDD gives you more " +
                                    "confidence regarding your code quality. On the other hand, Behavior " +
                                    "Driven Development (BDD) allows you to learn the features and requirements " +
                                    "directly from the customer and that alignment translates into code " +
                                    "that is closer to the users’ needs. Full integration testing ensures " +
                                    "that all components are working together as expected and increases " +
                                    "code coverage.";
            List<Tuple<string, int>> expectedResults = new List<Tuple<string, int>>{
                {new Tuple<string,int>("that", 4)},
                {new Tuple<string,int>("the", 4)},
                {new Tuple<string,int>("and", 3)},
                {new Tuple<string,int>("code", 3)},
                {new Tuple<string,int>("as", 2)},           
                {new Tuple<string,int>("development", 2)},
                {new Tuple<string,int>("driven", 2)},
                {new Tuple<string,int>("i", 2)},
                {new Tuple<string,int>("tdd", 2)},
                {new Tuple<string,int>("to", 2)},
                {new Tuple<string,int>("you", 2)}
            };

            List<Tuple<string, int>> actualResults;

            //when
            actualResults = this.statSentensePerformer.Repetition(textToAnalyze);

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