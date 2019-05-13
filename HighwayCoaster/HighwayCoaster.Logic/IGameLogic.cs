// <copyright file="IGameLogic.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using HighwayCoaster.Repository;
    using HighwayCoaster.Resources;

    /// <summary>
    /// IGameLogic interface
    /// </summary>
    public interface IGameLogic : IDisposable
    {
        /// <summary>
        /// Gets or sets a value indicating whether PrevWindow is true or fale
        /// </summary>
        bool PrevWindow { get; set; }

        /// <summary>
        /// Gets all the cars
        /// </summary>
        List<Car> AllCars { get; }

        /// <summary>
        /// Gets all the players
        /// </summary>
        IEnumerable<Player> GetPlayers { get; }

        /// <summary>
        /// Gets all the cars
        /// </summary>
        IEnumerable<Car> GetCars { get; }

        /// <summary>
        /// Gets the GameAreaLogic instance
        /// </summary>
        GameAreaLogic GAreaLogic { get; }

        /// <summary>
        /// Gets the logged in player
        /// </summary>
        Player LoggedInPlayer { get; }

        /// <summary>
        /// Gets the FileSources instance
        /// </summary>
        FileSources SC { get; }

        /// <summary>
        /// Gets the highscores
        /// </summary>
        ObservableCollection<Player> HighScoreHelper { get; }

        /// <summary>
        /// Login function
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        void Login(string userName, string password);

        /// <summary>
        /// Registration function
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Returns if the registration succeeded or not</returns>
        bool Register(string userName, string password);

        /// <summary>
        /// Delete the car (admin function)
        /// </summary>
        /// <param name="playerId">The player id of the highscore</param>
        void DeleteHighscore(decimal playerId);

        /// <summary>
        /// Saves the highscore
        /// </summary>
        /// <param name="playerId">ID of the player</param>
        /// <param name="highScore">New highscore</param>
        void SaveHighscore(decimal playerId, int highScore);

        /// <summary>
        /// Changes the car
        /// </summary>
        /// <param name="playerId">The player whos car you want to change</param>
        /// <param name="carId">The id of the selected car</param>
        void ChangeCar(decimal playerId, decimal carId);

        /// <summary>
        /// Setups the logic of the GameArea
        /// </summary>
        /// <param name="areaHeight">Area height</param>
        /// <param name="areaWidth">Area width</param>
        void SetupGameAreaLogic(int areaHeight, int areaWidth);
    }
}
