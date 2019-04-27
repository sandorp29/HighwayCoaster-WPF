namespace HighwayCoaster.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {

        private HighwayCoasterDatabaseEntities en;

        public Repository()
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

        public Player Login(string userName, string password)
        {
            //Player loggedOnPlayer = new Player();
            //foreach (var item in this.en.Player)
            //{
            //    if (item.Username == userName /*&& item.PW == password*/)
            //    {
            //        loggedOnPlayer = item;
            //    }
            //    else
            //    {
            //        throw new Exception("Not a valid User");
            //    }
            //}

            Player loggedOnPlayer = this.en.Player.ToList().Find(x => x.Username.Equals(userName) && x.PW.Equals(CreateMD5(password)));

            return loggedOnPlayer;
        }

        public bool Register(string userName, string password)
        {
            Player newPlayer = new Player()
            {
                Username = userName,
                PW = CreateMD5(password),
                CarId = this.en.Car.Min(x => x.PointRequirement),
                IsAdmin = false,
                Highscore = null,
            };

            this.en.Player.Add(newPlayer);
            this.en.SaveChanges();

            if (this.GetPlayers.ToList().Exists(x => x.Username.Equals(userName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveHighscore(decimal playerId, int highScore)
        {
            this.en.Player.Find(playerId).Highscore = highScore;
            this.en.SaveChanges();
        }

        private static byte[] CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return hashBytes;
            }
        }
    }
}
