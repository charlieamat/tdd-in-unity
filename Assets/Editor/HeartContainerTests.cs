using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor
{
    public class HeartContainerTests
    {
        public class TheReplenishMethod
        {
            protected Image Target;

            [SetUp]
            public void BeforeEveryTest()
            {
                Target = new GameObject().AddComponent<Image>();
            }

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var heartContainer = new HeartContainer(new List<Heart> {heart});

                heartContainer.Replenish(0);

                Assert.AreEqual(0, Target.fillAmount); 
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var heartContainer = new HeartContainer(new List<Heart> {heart});

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Empty_Hearts_Are_Replenished()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 1;
                var heartContainer = new HeartContainer(
                    new List<Heart> {new Heart(image), new Heart(Target)});

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount); 
            }

            public class HeartContainer
            {
                private readonly List<Heart> _hearts;

                public HeartContainer(List<Heart> hearts)
                {
                    _hearts = hearts;
                }

                public void Replenish(int numberOfHeartPieces)
                {
                    foreach (var heart in _hearts)
                        heart.Replenish(numberOfHeartPieces);
                }
            }
        }
    }
}