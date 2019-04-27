namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HighwayCoaster.Repository;

    public interface IGameLogic
    {
        event EventHandler OnGameOver;

        event EventHandler OnGameTicks;

        IEnumerable<Player> GetPlayers { get; }

        IEnumerable<Car> GetCars { get; }

        Player Login(string userName, string password);

        bool Register(string userName, string password);

        void DeleteHighscore(decimal playerId);

        void DeleteUser(decimal playerId);

        void SaveHighscore(decimal playerId, int highScore);

        void ChangeCar(decimal playerId, decimal carId);

        void StartGame();
    }
}
