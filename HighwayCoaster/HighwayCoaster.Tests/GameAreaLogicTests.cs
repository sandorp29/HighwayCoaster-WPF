// <copyright file="GameAreaLogicTests.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Tests
{
    using System;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// GameAreaLogicTests class
    /// </summary>
    [TestFixture]
    public class GameAreaLogicTests : IDisposable
    {
        private GameAreaLogic gAreaLogic;
        private Mock<IGameRepository> mockRepo;
        private Player testPlayer;
        private Car testCar;
        private GameLogic gameLogic;

        /// <summary>
        /// Setup for the GameAreaLogicTests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.mockRepo = new Mock<IGameRepository>();
            this.testCar = new Car() { CarId = 1, PointRequirement = 10000, ViewResourcesPath = "C:\\", WheelResource = "C:\\" };
            this.testPlayer = new Player() { PlayerId = 1, CarId = 1, Highscore = 1000, IsAdmin = false, Username = "prog4", PW = GameRepository.CreateMD5("jelszo") };
            this.gameLogic = new GameLogic(this.mockRepo.Object);

            this.mockRepo.Setup(x => x.GetPlayers).Returns(new[] { this.testPlayer });
            this.mockRepo.Setup(x => x.GetCars).Returns(new[] { this.testCar });

            this.gameLogic.Login("prog4", "jelszo");
        }

        /// <summary>
        /// Test for GameAreaLogic.StepObstacle()
        /// </summary>
        [Test]
        public void TestObstacleStep()
        {
            this.gAreaLogic = new GameAreaLogic(400, 800, this.gameLogic);

            int maxObstacles = 0;

            DateTime dateTime = DateTime.Now.AddSeconds(5);

            while (dateTime >= DateTime.Now)
            {
                this.gAreaLogic.StepObstacle();

                if (maxObstacles < this.gAreaLogic.Obstacles.Count)
                {
                    maxObstacles = this.gAreaLogic.Obstacles.Count;
                }
            }

            Assert.That(maxObstacles > 2);
        }

        /// <summary>
        /// Tests if the line moves up and doesn't go out of the GameArea
        /// </summary>
        [Test]
        public void TestLineMoveUp()
        {
            this.gAreaLogic = new GameAreaLogic(400, 800, this.gameLogic);

            double carHeight = this.gAreaLogic.CarObj.CarBody.Y;

            DateTime dateTime = DateTime.Now.AddSeconds(2);

            while (dateTime >= DateTime.Now)
            {
                this.gAreaLogic.StepLine(Logic.Helpers.Direction.Up);
                this.gAreaLogic.StepCar();
            }

            Assert.That(carHeight > this.gAreaLogic.CarObj.CarBody.Y && this.gAreaLogic.CarObj.CarBody.Y > 0);
        }

        /// <summary>
        /// Tests if the line moves down and doesn't go out of the GameArea
        /// </summary>
        [Test]
        public void TestLineMoveDown()
        {
            this.gAreaLogic = new GameAreaLogic(400, 800, this.gameLogic);

            double carHeight = this.gAreaLogic.CarObj.CarBody.Y;

            DateTime dateTime = DateTime.Now.AddSeconds(2);

            while (dateTime >= DateTime.Now)
            {
                this.gAreaLogic.StepLine(Logic.Helpers.Direction.Down);
                this.gAreaLogic.StepCar();
            }

            Assert.That(carHeight < this.gAreaLogic.CarObj.CarBody.Y && this.gAreaLogic.CarObj.CarBody.Y < 400);
        }

        /// <summary>
        /// Tests if the score increases
        /// </summary>
        [Test]
        public void TestIfScoreIncreases()
        {
            this.gAreaLogic = new GameAreaLogic(400, 800, this.gameLogic);

            int score = this.gAreaLogic.Score;

            DateTime dateTime = DateTime.Now.AddSeconds(2);

            while (!this.gAreaLogic.GameOver && dateTime >= DateTime.Now)
            {
                this.gAreaLogic.Step(Logic.Helpers.Direction.None);
            }

            Assert.That(score < this.gAreaLogic.Score);
        }

        /// <summary>
        /// Test for assurance about the game can end
        /// </summary>
        [Test]
        public void TestIfEnds()
        {
            this.gAreaLogic = new GameAreaLogic(400, 800, this.gameLogic);

            DateTime dateTime = DateTime.Now.AddSeconds(5);

            while (!this.gAreaLogic.GameOver && dateTime >= DateTime.Now)
            {
                this.gAreaLogic.Step(Logic.Helpers.Direction.None);
            }

            Assert.That(this.gAreaLogic.GameOver);
        }

        /// <summary>
        /// Dispose function
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose function
        /// </summary>
        /// <param name="disposing">Gets if the disposal already started</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.gameLogic.Dispose();
            }
        }
    }
}
