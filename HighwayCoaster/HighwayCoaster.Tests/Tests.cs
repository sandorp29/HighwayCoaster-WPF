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
    class Tests
    {
        private Mock<IRepository> mockRepo;
        private Player testPlayer;
        private Car testCar;
        private UserLogic uLogic;

        [SetUp]
        public void Setup()
        {
            this.mockRepo = new Mock<IRepository>();
            this.testPlayer = new Player() {PlayerId = 1, CarId = 1, Highscore = 1000, IsAdmin = false, Username = "prog4" };
            this.uLogic = new UserLogic(this.mockRepo.Object);
            this.testCar = new Car() { CarId = 1, PointRequirement = 10000, ViewResourcesPath = "C:\\" };
    }

        [Test]
        public void TestLogin()
        {
            this.mockRepo.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()));
            this.uLogic.Login("ad", "ada");
            this.mockRepo.Verify(x => x.Login(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void TestSaveHighScore()
        {
            this.mockRepo.Setup(x => x.SaveHighscore(It.IsAny<decimal>(), It.IsAny<int>()));
            this.uLogic.SaveHighscore(3, 40000);
            this.mockRepo.Verify(x => x.SaveHighscore(It.IsAny<decimal>(), It.IsAny<int>()));
        }

        [Test]
        public void TestGetAllPlayers()
        {
            List<Player> players = new List<Player>() { this.testPlayer };
            this.mockRepo.Setup(x => x.GetPlayers()).Returns(this.TestReturn(players));
            this.uLogic.GetPlayers();
            this.mockRepo.Verify(x => x.GetPlayers());
        }

        [Test]
        public void TestGetAllCars()
        {
            List<Car> cars = new List<Car>() { this.testCar };
            this.mockRepo.Setup(x => x.GetCars()).Returns(this.TestReturn(cars));
            this.uLogic.GetCars();
            this.mockRepo.Verify(x => x.GetCars());
        }

        [Test]
        public void TestDeleteUser()
        {
            this.mockRepo.Setup(x => x.DeleteUser(It.IsAny<decimal>()));
            this.uLogic.DeleteUser(3);
            this.mockRepo.Verify(x => x.DeleteUser(It.IsAny<decimal>()));
        }

        private IEnumerable<T> TestReturn<T>(List<T> list)
        {
            return list.AsEnumerable();
        }
    }
}
