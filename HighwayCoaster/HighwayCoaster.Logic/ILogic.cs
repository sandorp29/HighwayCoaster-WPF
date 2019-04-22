using HighwayCoaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayCoaster.Logic
{
    public interface ILogic
    {
        event EventHandler OnGameOver;

        event EventHandler OnGameTicks;

        Player Login(string userName, string password);

        bool Register(string userName, string password);

        void DeleteHighscore(decimal playerId);

        void DeleteUser(decimal playerId);

        void SaveHighscore(decimal playerId, int highScore);

        void ChangeCar(decimal playerId, decimal carId);

        IEnumerable<Player> GetPlayers();

        IEnumerable<Car> GetCars();

        void StartGame();
    }
}
