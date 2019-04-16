namespace HighwayCoaster.Repository
{
    using System.Collections.Generic;

    public interface IRepository
    {
        Player Login(string userName, string password);

        bool Register(string userName, string password);

        void DeleteHighscore(decimal playerId);

        void DeleteUser(decimal playerId);

        void SaveHighscore(decimal playerId, int highScore);

        void ChangeCar(decimal playerId, decimal carId);

        IEnumerable<Player> GetPlayers();

        IEnumerable<Car> GetCars();
    }
}
