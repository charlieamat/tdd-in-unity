using Editor.Infrastructure;
using NUnit.Framework;
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
                Target = An.Image();
            }

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                ((HeartContainer) A.HeartContainer().With(
                    A.Heart().With(Target))).Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                ((HeartContainer) A.HeartContainer()
                    .With(A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Empty_Hearts_Are_Replenished()
            {
                ((HeartContainer) A.HeartContainer()
                    .With(
                        A.Heart().With(An.Image().WithFillAmount(1)),
                        A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_In_Order()
            {
                ((HeartContainer) A.HeartContainer()
                    .With(
                        A.Heart(), A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _Distributes_Heart_Pieces_Across_Multiple_Unfilled_Hearts()
            {
                ((HeartContainer) A.HeartContainer()
                    .With(
                        A.Heart()
                            .With(An.Image().WithFillAmount(0.75f)),
                        A.Heart().With(Target))).Replenish(2);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }
        }
    }
}