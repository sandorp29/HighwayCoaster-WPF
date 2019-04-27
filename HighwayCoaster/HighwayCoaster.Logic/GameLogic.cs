namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using HighwayCoaster.Repository;

    public class GameLogic : IGameLogic
    {
        private IGameRepository repo;

        public GameLogic(IGameRepository repo)
        {
            this.repo = repo;
        }

        public GameLogic()
        {
            this.repo = new GameRepository();
        }

        public event EventHandler OnGameOver;

        public event EventHandler OnGameTicks;

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

        public Player Login(string userName, string password)
        {
            Player loggedOnPlayer = this.GetPlayers
                .ToList()
                .Find(x => x.Username.Equals(userName) && Enumerable.SequenceEqual(x.PW, GameRepository.CreateMD5(password)));

            return loggedOnPlayer;
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

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
