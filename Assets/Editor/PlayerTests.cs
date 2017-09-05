using System;
using NUnit.Framework;

namespace Editor
{
    public class PlayerTests
    {
        public class TheCurrentHealthProperty
        {
            [Test]
            public void Health_Defaults_To_0()
            {
                var player = new Player(0);

                Assert.AreEqual(0, player.CurrentHealth);
            }

            [Test]
            public void Throws_Exception_When_Current_Health_Is_Less_Than_Zero()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Player(-1));
            }

            [Test]
            public void Throws_Exception_When_Current_Health_Is_Greater_Than_Maximum_Health()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Player(2, 1));
            }
        }

        public class TheHealMethod
        {
            [Test]
            public void _0_Does_Nothing()
            {
                var player = new Player(0);

                player.Heal(0);

                Assert.AreEqual(0, player.CurrentHealth);
            }

            [Test]
            public void _1_Increments_Current_Health()
            {
                var player = new Player(0);

                player.Heal(1);

                Assert.AreEqual(1, player.CurrentHealth);
            }

            [Test]
            public void Overhealing_Is_Ignored()
            {
                var player = new Player(0, 1);

                player.Heal(2);

                Assert.AreEqual(1, player.CurrentHealth);
            }
        }

        public class TheDamageMethod
        {
            [Test]
            public void _0_Does_Nothing()
            {
                var player = new Player(1);

                player.Damage(0);
 
                Assert.AreEqual(1, player.CurrentHealth);
          }

            [Test]
            public void _1_Decrements_Current_Health()
            {
                var player = new Player(1);

                player.Damage(1);

                Assert.AreEqual(0, player.CurrentHealth);
            }

            [Test]
            public void Overkill_Is_Ignored()
            {
                var player = new Player(1);

                player.Damage(2);

                Assert.AreEqual(0, player.CurrentHealth);
            }
        }
    }
}