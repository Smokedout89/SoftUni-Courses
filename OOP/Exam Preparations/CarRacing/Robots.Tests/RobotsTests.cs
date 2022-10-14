namespace Robots.Tests
{
    using System;
    using System.Xml.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        RobotManager robotManager;
        private Robot robot;

        [SetUp]
        public void Init()
        {
            robotManager = new RobotManager(10);
            robot = new Robot("Robbie", 99);
        }

        [Test]
        public void RobotConstructroTest()
        {
            robot.Battery = 40;

            Assert.AreEqual("Robbie", robot.Name);
            Assert.AreEqual(99, robot.MaximumBattery);
            Assert.AreEqual(40, robot.Battery);
        }

        [Test]
        public void RobotManagerConstructorTest()
        {
            Assert.AreEqual(10, robotManager.Capacity);
            Assert.IsNotNull(robotManager);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void RobotManagerThrowsExceptionInvalidCapacity(int capacity)
        {
            RobotManager manager;

            Assert.Throws<ArgumentException>(
                () => manager = new RobotManager(capacity),
                "Invalid capacity!");
        }

        [Test]
        public void RobotManagerSuccesfullyAddRobot()
        {
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RobotManagerAddRobotThrowsExceptions()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(robot),
                $"There is already a robot with name {robot.Name}!");

            RobotManager manager = new RobotManager(1);
            Robot robo1 = new Robot("Robcho", 100);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => manager.Add(robo1),
                "Not enough capacity!");
        }

        [Test]
        public void RobotManagerRemoveSuccesfully()
        {
            robotManager.Add(robot);

            robotManager.Remove(robot.Name);

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveThrows()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Remove("Rob"),
                $"Robot with the name Rob doesn't exist!");
        }

        [Test]
        public void RobotManagerWorkSuccessful()
        {
            robotManager.Add(robot);

            robotManager.Work("Robbie", "Buhai zdravo", 89);

            Assert.AreEqual(10, robot.Battery);
        }

        [Test]
        public void RobotManagerWorkThrows()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("Rob", "Nqma koi da buha", 19),
                $"Robot with the name Rob doesn't exist!");

            robot.Battery = 88;

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("Robbie", "Buhai zdravo", 89),
                $"{robot.Name} doesn't have enough battery!");
        }

        [Test]
        public void RobotManagerChargeShouldRecharge()
        {
            robotManager.Add(robot);
            robot.Battery = 10;

            robotManager.Charge("Robbie");

            Assert.AreEqual(99, robot.Battery);
        }

        [Test]
        public void RobotManagerChargeShouldThrow()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Charge("Rob"),
                $"Robot with the name Rob doesn't exist!");
        }
    }
}
