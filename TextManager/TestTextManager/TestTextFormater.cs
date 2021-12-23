using NUnit.Framework;
using TextManager;

namespace TestTextManager
{
    public class TestTextFormater
    {
        #region private attributes
        private TextFormater textFormater = null;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            this.textFormater = new TextFormater();
        }

        #region Single Sentence
        [Test]
        public void T001_Reverse_NominalCase_Success()
        {
            //given
            string sentenceToReverse = "Il faut agir aussi vite que possible, mais aussi lentement que nécessaire.";
            string expectedResult = "Nécessaire que lentement aussi mais, possible que vite aussi agir faut il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T002_Reverse_MultipleUpperCase_Success()
        {
            //Add word with UpperCase in the middle of sentence
            //Multiple comas

            //given
            string sentenceToReverse = "Netflix, is an over-the-top content platform and production company headquartered in Los Gatos.";
            string expectedResult = "Gatos Los in headquartered company production and platform content over-the-top an is, netflix.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T003_Reverse_MultipleComa_Success()
        {
            //Add word with UpperCase in the middle of sentence
            //Multiple comas

            //given
            string sentenceToReverse = "Il estime, en outre, que la directive sur la mise en décharge des déchets ne constitue pas un cadre approprié pour les déchets miniers.";
            string expectedResult = "Miniers déchets les pour approprié cadre un pas constitue ne déchets des décharge en mise la sur directive la que, outre en, estime il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Single Sentence

        #region Multiple Sentences
        [Test]
        public void T004_Reverse_MultipleSentence_Success()
        {
            //given
            string sentenceToReverse = "Il faut agir aussi vite que possible, mais aussi lentement que nécessaire. Il faut agir aussi vite que possible, mais aussi lentement que nécessaire.";
            string expectedResult = "Nécessaire que lentement aussi mais, possible que vite aussi agir faut il. Nécessaire que lentement aussi mais, possible que vite aussi agir faut il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Multiple Sentences

        [Test]
        public void T005_Reverse_UltimateTest_Success()
        {
            //Add word with UpperCase in the middle of sentence
            //Multiple comas

            //given
            string textToReverse = "The second sentence of the second subparagraph of Article 7 (a), a Member State proposes not to grant applicants the right to choose between an adaptation period and an aptitude test, it shall immediately communicate to the Commission the corresponding draft provision.";
            string expectedResult = "Provision draft corresponding the Commission the to communicate immediately shall it, test aptitude an and period adaptation an between choose to right the applicants grant to not proposes State Member a, (a) 7 Article of subparagraph second the of sentence second the.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(textToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}