
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HighwayCoaster.Repository;

namespace HighwayCoaster.Logic
{
    public class UserLogic : ILogic
    {
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
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetCars()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetPlayers()
        {
            throw new NotImplementedException();
        }

        

        public Player Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveHighscore(decimal playerId, int highScore)
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
