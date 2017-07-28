using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor
{
    public class HeartTests
    {
        private Image _image;
        private Heart _heart;

        [SetUp]
        public void BeforeEveryTest()
        {
            _image = new GameObject().AddComponent<Image>();
            _heart = new Heart(_image);
        }

        public class TheCurrentNumberOfHeartPiecesProperty : HeartTests
        {
            [Test]
            public void _0_Image_Fill_Is_0_Heart_Pieces()
            {
                _image.fillAmount = 0;

                Assert.AreEqual(0, _heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _25_Percent_Image_Fill_Is_1_Heart_Piece()
            {
                _image.fillAmount = 0.25f;

                Assert.AreEqual(1, _heart.CurrentNumberOfHeartPieces);
            }

            [Test]
            public void _75_Percent_Image_Fill_Is_3_Heart_Pieces()
            {
                _image.fillAmount = 0.75f;

                Assert.AreEqual(3, _heart.CurrentNumberOfHeartPieces);
            }
        }

        public class TheReplenishMethod : HeartTests
        {
            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                _image.fillAmount = 0;

                _heart.Replenish(0);

                Assert.AreEqual(0, _image.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                _image.fillAmount = 0;

                _heart.Replenish(1);

                Assert.AreEqual(0.25f, _image.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_25_Percent_Fill_To_50_Percent_Fill()
            {
                _image.fillAmount = 0.25f;

                _heart.Replenish(1);

                Assert.AreEqual(0.5f, _image.fillAmount);
            }

            [Test]
            public void _Throws_Exception_For_Negative_Number_Of_Heart_Pieces()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _heart.Replenish(-1));
            }
        }

        public class TheDepleteMethod : HeartTests
        {
            [Test]
            public void _0_Sets_Image_With_100_Percent_Fill_To_100_Percent_Fill()
            {
                _image.fillAmount = 1;

                _heart.Deplete(0);

                Assert.AreEqual(1, _image.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_100_Percent_Fill_To_75_Percent_Fill()
            {
                _image.fillAmount = 1;

                _heart.Deplete(1);

                Assert.AreEqual(0.75f, _image.fillAmount);
            }

            [Test]
            public void _2_Sets_Image_With_75_Percent_Fill_To_25_Percent_Fill()
            {
                _image.fillAmount = 0.75f;

                _heart.Deplete(2);

                Assert.AreEqual(0.25f, _image.fillAmount);
            }

            [Test]
            public void _Throws_Exception_For_Negative_Number_Of_Heart_Pieces()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _heart.Deplete(-1));
            }
        }
    }
}