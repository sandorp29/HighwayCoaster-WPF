// <copyright file="GameRepository.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository class
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private HighwayCoasterDatabaseEntities en;
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRepository"/> class.
        /// </summary>
        public GameRepository()
        {
            this.en = new HighwayCoasterDatabaseEntities();
        }

        /// <inheritdoc/>
        public IEnumerable<Car> GetCars
        {
            get
            {
                return this.en.Car.AsEnumerable();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Player> GetPlayers
        {
            get
            {
                return this.en.Player.AsEnumerable();
            }
        }

        /// <summary>
        /// password encryption
        /// </summary>
        /// <param name="input">actual password in string</param>
        /// <returns>encrypted password</returns>
        public static byte[] CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return hashBytes;
            }
        }

        /// <inheritdoc/>
        public void ChangeCar(decimal playerId, decimal carId)
        {
            this.en.Player.Find(playerId).CarId = carId;
            this.en.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteHighscore(decimal playerId)
        {
            this.en.Player.Find(playerId).Highscore = null;
            this.en.SaveChanges();
        }

        /// <inheritdoc/>
        public void Register(Player newPlayer)
        {
            this.en.Player.Add(newPlayer);
            this.en.SaveChanges();
        }

        /// <inheritdoc/>
        public void SaveHighscore(decimal playerId, int highScore)
        {
            this.en.Player.Find(playerId).Highscore = highScore;
            this.en.SaveChanges();
        }

        /// <summary>
        /// Disposal method
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// disposal
        /// </summary>
        /// <param name="disposing">disposed</param>
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
