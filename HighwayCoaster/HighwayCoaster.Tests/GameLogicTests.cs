// <copyright file="GameLogicTests.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// GameLogicTests class
    /// </summary>
    [TestFixture]
    public class GameLogicTests : IDisposable
    {
        private Mock<IGameRepository> mockRepo;
        private Player testPlayer;
        private Car testCar;
        private GameLogic gameLogic;

        /// <summary>
        /// The GameLogicTets setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.mockRepo = new Mock<IGameRepository>();
            this.testPlayer = new Player() { PlayerId = 1, CarId = 1, Highscore = 1000, IsAdmin = false, Username = "prog4", PW = GameRepository.CreateMD5("jelszo") };
            this.gameLogic = new GameLogic(this.mockRepo.Object);
            this.testCar = new Car() { CarId = 1, PointRequirement = 10000, ViewResourcesPath = "C:\\" };

            this.mockRepo.Setup(x => x.GetPlayers).Returns(new[] { this.testPlayer });
            this.mockRepo.Setup(x => x.GetCars).Returns(new[] { this.testCar });
        }

        /// <summary>
        /// Test of the GameLogic registration
        /// </summary>
        [Test]
        public void TestRegistration()
        {
            this.mockRepo.Setup(x => x.Register(It.Is<Player>(y => y.Username.Equals("teszt1")))).Throws(new Exception());

            Assert.That(this.gameLogic.Register("teszt1", "asd123") == false);
            Assert.That(this.gameLogic.Register("teszt2", "asd123") == true);
        }

        /// <summary>
        /// Test of the GameLogic login
        /// </summary>
        [Test]
        public void TestLogin()
        {
            this.gameLogic.Login("prog5", "jelszo");

            Assert.That(this.gameLogic.LoggedInPlayer == null);

            this.gameLogic.Login("prog4", "jelszo");

            Assert.That(this.gameLogic.LoggedInPlayer == this.testPlayer);
        }

        /// <summary>
        /// Tests of the GameLogic.GetPlayers
        /// </summary>
        [Test]
        public void TestGetAllPlayers()
        {
            Assert.That(this.gameLogic.GetPlayers.Count() == 1);
        }

        /// <summary>
        /// Test of the GameLogic.GetCars
        /// </summary>
        [Test]
        public void TestGetAllCars()
        {
            Assert.That(this.gameLogic.GetCars.Count() == 1);
        }

        /// <summary>
        /// Tests if the HighscoreHelper works properly
        /// </summary>
        [Test]
        public void TestHighscoreHelpList()
        {
            Assert.That(this.gameLogic.HighScoreHelper.Count == 1);
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
