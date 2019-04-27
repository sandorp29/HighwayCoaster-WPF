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

    [TestFixture]
    public class Tests
    {
        private Mock<IGameRepository> mockRepo;
        private Player testPlayer;
        private Car testCar;
        private GameLogic gameLogic;

        [SetUp]
        public void Setup()
        {
            this.mockRepo = new Mock<IGameRepository>();
            this.testPlayer = new Player() {PlayerId = 1, CarId = 1, Highscore = 1000, IsAdmin = false, Username = "prog4", PW = GameRepository.CreateMD5("jelszo") };
            this.gameLogic = new GameLogic(this.mockRepo.Object);
            this.testCar = new Car() { CarId = 1, PointRequirement = 10000, ViewResourcesPath = "C:\\" };

            this.mockRepo.Setup(x => x.GetPlayers).Returns(new[] { this.testPlayer });
            this.mockRepo.Setup(x => x.GetCars).Returns(new[] { this.testCar });
        }

        [Test]
        public void TestRegistration()
        {
            this.mockRepo.Setup(x => x.Register(It.Is<Player>(y => y.Username.Equals("teszt1")))).Throws(new Exception());

            Assert.That(this.gameLogic.Register("teszt1", "asd123") == false);
            Assert.That(this.gameLogic.Register("teszt2", "asd123") == true);
        }

        [Test]
        public void TestLogin()
        {
            Assert.That(this.gameLogic.Login("prog4", "jelszo").Username == this.testPlayer.Username);
            Assert.That(this.gameLogic.Login("prog5", "jelszo") == null);
        }

        [Test]
        public void TestGetAllPlayers()
        {
            Assert.That(this.gameLogic.GetPlayers.Count() == 1);
        }

        [Test]
        public void TestGetAllCars()
        {
            Assert.That(this.gameLogic.GetCars.Count() == 1);
        }
    }
}
