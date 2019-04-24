namespace HighwayCoaster.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Repository : IRepository
    {

        HighwayCoasterDatabaseEntities en;

        public Repository()
        {
            this.en = new HighwayCoasterDatabaseEntities();
        }

        public void ChangeCar(decimal playerId, decimal carId)
        {
            throw new NotImplementedException();
        }

        public void DeleteHighscore(decimal playerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(decimal playerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetCars()
        {
            return this.en.Car.AsEnumerable();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return this.en.Player.AsEnumerable();
        }

        public Player Login(string userName, string password)
        {
            Player logedOnPlayer = new Player();
            foreach (var item in this.en.Player)
            {
                if (item.Username == userName /*&& item.PW == password*/)
                {
                    logedOnPlayer = item;
                }
                else
                {
                    throw new Exception("Not a valid User");
                }
            }

            return logedOnPlayer;
        }

        public bool Register(string userName, string password)
        {
            Player newPlayer = new Player();
            newPlayer.Username = userName;
            return true;
        }

        public void SaveHighscore(decimal playerId, int highScore)
        {
            foreach (var item in this.en.Player)
            {
                if (item.PlayerId == playerId)
                {
                    item.Highscore = highScore;
                    this.en.SaveChanges();
                }
            }
        }
    }
}
