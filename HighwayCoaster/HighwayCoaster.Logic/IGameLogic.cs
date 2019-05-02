namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media.Imaging;
    using HighwayCoaster.Repository;
    using HighwayCoaster.Resources;

    public interface IGameLogic : IDisposable
    {
        bool PrevWindow { get; set; }

        List<Player> AllPlayers { get; }

        List<Car> AllCars { get; }

        IEnumerable<Player> GetPlayers { get; }

        IEnumerable<Car> GetCars { get; }

        GameAreaLogic GAreaLogic { get; }

        Player LoggedInPlayer { get; }

        FileSources Sc { get; }

        List<Player> HighScoreHelper { get; }

        void Login(string userName, string password);

        bool Register(string userName, string password);

        void DeleteHighscore(decimal playerId);

        void DeleteUser(decimal playerId);

        void SaveHighscore(decimal playerId, int highScore);

        void ChangeCar(decimal playerId, decimal carId);

        void SetupGameAreaLogic(double areaHeight, double areaWidth);
    }
}
