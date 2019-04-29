namespace HighwayCoaster.Repository
{
    using System;
    using System.Collections.Generic;

    public interface IGameRepository: IDisposable
    {
        IEnumerable<Player> GetPlayers { get; }

        IEnumerable<Car> GetCars { get; }

        void Register(Player player);

        void DeleteHighscore(decimal playerId);

        void DeleteUser(decimal playerId);

        void SaveHighscore(decimal playerId, int highScore);

        void ChangeCar(decimal playerId, decimal carId);
    }
}
