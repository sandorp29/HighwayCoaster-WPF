namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using HighwayCoaster.Repository;

    public class UserLogic : ILogic
    {
        IRepository repo;

        public UserLogic(IRepository repo)
        {
            this.repo = repo;
        }

        public UserLogic() {
            this.repo = new Repository();
        }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public event EventHandler OnGameOver;

        public event EventHandler OnGameTicks;

        public void ChangeCar(decimal playerId, decimal carId)
        {
            throw new NotImplementedException();
        }

        public void DeleteHighscore(decimal playerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(decimal playerId)
        {
            this.repo.DeleteUser(playerId);
        }

        public IEnumerable<Car> GetCars()
        {
            return this.repo.GetCars();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return this.repo.GetPlayers();
        }

        public Player Login(string userName, string password)
        {
            return this.repo.Login(userName, password);
        }

        public bool Register(string userName, string password)
        {
            return this.repo.Register(userName, password);
        }

        public void SaveHighscore(decimal playerId, int highScore)
        {
            this.repo.SaveHighscore(playerId, highScore);
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
