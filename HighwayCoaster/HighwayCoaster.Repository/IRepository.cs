namespace HighwayCoaster.Repository
{
    using System.Collections.Generic;

    public interface IRepository
    {
        IEnumerable<Player> GetPlayers { get; }

        IEnumerable<Car> GetCars { get; }

        Player Login(string userName, string password);

        bool Register(string userName, string password);

        void DeleteHighscore(decimal playerId);

        void DeleteUser(decimal playerId);

        void SaveHighscore(decimal playerId, int highScore);

        void ChangeCar(decimal playerId, decimal carId);
    }
}
