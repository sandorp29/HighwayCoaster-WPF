// <copyright file="GameLogic.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using HighwayCoaster.Repository;
    using HighwayCoaster.Resources;

    /// <summary>
    /// GameLogic class
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private FileSources sc = new FileSources(DesignerProperties.GetIsInDesignMode(new DependencyObject()));
        private IGameRepository repo;
        private Player loggedInPlayer;
        private bool disposedValue = false; // To detect redundant calls
        private bool prevWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="repo">The actual repo instance</param>
        public GameLogic(IGameRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        public GameLogic()
        {
            this.repo = new GameRepository();
        }

        /// <summary>
        /// Gets all the cars
        /// </summary>
        public IEnumerable<Car> GetCars
        {
            get
            {
                return this.repo.GetCars;
            }
        }

        /// <summary>
        /// Gets all the players
        /// </summary>
        public IEnumerable<Player> GetPlayers
        {
            get
            {
                return this.repo.GetPlayers;
            }
        }

        /// <summary>
        /// Gets the logged in player
        /// </summary>
        public Player LoggedInPlayer { get => this.loggedInPlayer; }

        /// <summary>
        /// Gets the FileSources instance
        /// </summary>
        public FileSources SC { get => this.sc; }

        /// <summary>
        /// Gets the GameAreaLogic
        /// </summary>
        public GameAreaLogic GAreaLogic { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether PrevWindow is true or fale
        /// </summary>
        public bool PrevWindow { get => this.prevWindow; set => this.prevWindow = value; }

        /// <summary>
        /// Gets the Highscore list
        /// </summary>
        public ObservableCollection<Player> HighScoreHelper { get => this.HShelpList(); }

        /// <summary>
        /// Gets all the cars
        /// </summary>
        public List<Car> AllCars { get => this.GetCars.ToList(); }

        /// <summary>
        /// Changes the car
        /// </summary>
        /// <param name="playerId">The player whos car you want to change</param>
        /// <param name="carId">The id of the selected car</param>
        public void ChangeCar(decimal playerId, decimal carId)
        {
            this.repo.ChangeCar(playerId, carId);
        }

        /// <summary>
        /// Delete the car (admin function)
        /// </summary>
        /// <param name="playerId">The player id of the highscore</param>
        public void DeleteHighscore(decimal playerId)
        {
            this.repo.DeleteHighscore(playerId);
        }

        /// <summary>
        /// Login function
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        public void Login(string userName, string password)
        {
            this.loggedInPlayer = this.GetPlayers
                .ToList()
                .Find(x => x.Username.Equals(userName) && Enumerable.SequenceEqual(x.PW, GameRepository.CreateMD5(password)));
        }

        /// <summary>
        /// Registration function
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Returns if the registration succeeded or not</returns>
        public bool Register(string userName, string password)
        {
            try
            {
                Player newPlayer;
                if (userName == "admin")
                {
                    newPlayer = new Player()
                    {
                        Username = userName,
                        PW = GameRepository.CreateMD5(password),
                        CarId = this.GetCars.First(y => y.PointRequirement == this.GetCars.Min(x => x.PointRequirement)).CarId,
                        IsAdmin = true,
                        Highscore = 10000000,
                        Car = this.GetCars.First(y => y.PointRequirement == this.GetCars.Min(x => x.PointRequirement))
                    };
                }
                else
                {
                    newPlayer = new Player()
                    {
                        Username = userName,
                        PW = GameRepository.CreateMD5(password),
                        CarId = this.GetCars.First(y => y.PointRequirement == this.GetCars.Min(x => x.PointRequirement)).CarId,
                        IsAdmin = false,
                        Highscore = null,
                        Car = this.GetCars.First(y => y.PointRequirement == this.GetCars.Min(x => x.PointRequirement))
                    };
                }

                this.repo.Register(newPlayer);

                return true;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Saves the highscore
        /// </summary>
        /// <param name="playerId">ID of the player</param>
        /// <param name="highScore">New highscore</param>
        public void SaveHighscore(decimal playerId, int highScore)
        {
            this.repo.SaveHighscore(playerId, highScore);
        }

        /// <summary>
        /// Setups the logic of the GameArea
        /// </summary>
        /// <param name="areaHeight">Area height</param>
        /// <param name="areaWidth">Area width</param>
        public void SetupGameAreaLogic(int areaHeight, int areaWidth)
        {
            this.GAreaLogic = new GameAreaLogic(areaHeight, areaWidth, this);
        }

        /// <summary>
        /// Dispose function
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose function
        /// </summary>
        /// <param name="disposing">Gets if the disposal already started</param>
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

        private ObservableCollection<Player> HShelpList()
        {
            ObservableCollection<Player> p = new ObservableCollection<Player>();
            foreach (var item in this.GetPlayers)
            {
                if (item.Highscore != null)
                {
                    p.Add(item);
                }
            }

            p.OrderByDescending(x => x.Highscore);
            return p;
        }
    }
}
