namespace HighwayCoaster.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameRepository : IGameRepository
    {
        private HighwayCoasterDatabaseEntities en;
        private bool disposedValue = false; // To detect redundant calls

        public GameRepository()
        {
            this.en = new HighwayCoasterDatabaseEntities();
        }

        public IEnumerable<Car> GetCars
        {
            get
            {
                return this.en.Car.AsEnumerable();
            }
        }

        public IEnumerable<Player> GetPlayers
        {
            get
            {
                return this.en.Player.AsEnumerable();
            }
        }

        public static byte[] CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return hashBytes;
            }
        }

        public void ChangeCar(decimal playerId, decimal carId)
        {
            this.en.Player.Find(playerId).CarId = carId;
            this.en.SaveChanges();
        }

        public void DeleteHighscore(decimal playerId)
        {
            this.en.Player.Find(playerId).Highscore = null;
            this.en.SaveChanges();
        }

        public void DeleteUser(decimal playerId)
        {
            this.en.Player.Remove(this.en.Player.Find(playerId));
            this.en.SaveChanges();
        }

        public void Register(Player newPlayer)
        {
            this.en.Player.Add(newPlayer);
            this.en.SaveChanges();
        }

        public void SaveHighscore(decimal playerId, int highScore)
        {
            this.en.Player.Find(playerId).Highscore = highScore;
            this.en.SaveChanges();
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
                    this.en.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
