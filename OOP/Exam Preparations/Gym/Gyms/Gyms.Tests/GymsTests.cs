using System;

namespace Gyms.Tests
{
    using NUnit.Framework;
    public class GymsTests
    {
        [Test]
        public void TestAthleteCreation()
        {
            Athlete athlete = new Athlete("Jorkata");

            Assert.AreEqual("Jorkata", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void TestGymCreation()
        {
            Gym gym = new Gym("Batkite", 10);

            Assert.AreEqual("Batkite", gym.Name);
            Assert.AreEqual(10, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void TestGymCreation_WithNullName_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    Gym gym = new Gym(null, 10);
                });
        }

        [Test]
        public void TestGymCreation_WithEmptyString_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 10);
            });
        }

        [Test]
        public void TestGymCreation_WithNegativCapacity_ThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Batkite", -1);
            });
        }

        [Test]
        public void TestGym_AddAthlete_Works()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void TestGym_AddAthlete_ThrowsException()
        {
            Gym gym = new Gym("Babankite", 2);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");
            Athlete athlete3 = new Athlete("Gladniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete3);
            });
        }

        [Test]
        public void TestGym_RemoveAthlete_Works()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void TestGym_RemoveAthlete_Throws()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Shnorhela");
            });
        }

        [Test]
        public void TestGym_InjureAthlete_Works()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var injuredAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true, athlete.IsInjured);
            Assert.AreSame(athlete, injuredAthlete);
        }

        [Test]
        public void TestGym_InjureAthlete_Throws()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Kriviq");
            });
        }

        [Test]
        public void TestGym_ReportWithInjured_Works()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var injuredAthlete = gym.InjureAthlete(athlete.FullName);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Babankite: Dolniq", gym.Report());
        }

        [Test]
        public void TestGym_ReportWithHealthy_Works()
        {
            Gym gym = new Gym("Babankite", 10);
            Athlete athlete = new Athlete("Zvqrkiq");
            Athlete athlete2 = new Athlete("Dolniq");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Babankite: Zvqrkiq, Dolniq", gym.Report());
        }

        [Test]
        public void TestGym_ReportWithEmpty_Works()
        {
            Gym gym = new Gym("Babankite", 10);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Babankite: ", gym.Report());
        }
    }
}
