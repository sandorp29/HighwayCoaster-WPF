namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using HighwayCoaster.Repository;
    using HighwayCoaster.Resources;

    public class GameLogic : IGameLogic
    {
        private FileSources sc = new FileSources(DesignerProperties.GetIsInDesignMode(new DependencyObject()));
        private IGameRepository repo;
        private Player loggedInPlayer;
        private bool disposedValue = false; // To detect redundant calls
        private bool prevWindow;
        private List<Player> allPlayers;

        public GameLogic(IGameRepository repo)
        {
            this.repo = repo;
        }

        public GameLogic()
        {
            this.repo = new GameRepository();
        }

        public IEnumerable<Car> GetCars
        {
            get
            {
                return this.repo.GetCars;
            }
        }

        public IEnumerable<Player> GetPlayers
        {
            get
            {
                return this.repo.GetPlayers;
            }
        }

        public Player LoggedInPlayer { get => this.loggedInPlayer; }

        public FileSources Sc { get => sc; }

        public GameAreaLogic GAreaLogic { get; private set; }

        public bool PrevWindow { get => prevWindow; set => prevWindow = value; }

        public List<Player> AllPlayers { get => GetPlayers.ToList(); }

        public void ChangeCar(decimal playerId, decimal carId)
        {
            this.repo.ChangeCar(playerId, carId);
        }

        public void DeleteHighscore(decimal playerId)
        {
            this.repo.DeleteHighscore(playerId);
        }

        public void DeleteUser(decimal playerId)
        {
            this.repo.DeleteUser(playerId);
        }

        public void Login(string userName, string password)
        {
            loggedInPlayer = this.GetPlayers
                .ToList()
                .Find(x => x.Username.Equals(userName) && Enumerable.SequenceEqual(x.PW, GameRepository.CreateMD5(password)));
        }

        public bool Register(string userName, string password)
        {
            try
            {
                Player newPlayer = new Player()
                {
                    Username = userName,
                    PW = GameRepository.CreateMD5(password),
                    CarId = this.GetCars.First(y => y.PointRequirement == this.GetCars.Min(x => x.PointRequirement)).CarId,
                    IsAdmin = false,
                    Highscore = null,
                    Car = this.GetCars.First(y => y.PointRequirement == this.GetCars.Min(x => x.PointRequirement))
                };

                this.repo.Register(newPlayer);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SaveHighscore(decimal playerId, int highScore)
        {
            this.repo.SaveHighscore(playerId, highScore);
        }

        public void SetupGameAreaLogic(int areaHeight, int areaWidth)
        {
            this.GAreaLogic = new GameAreaLogic(areaHeight, areaWidth, loggedInPlayer.Car);
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.repo.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
