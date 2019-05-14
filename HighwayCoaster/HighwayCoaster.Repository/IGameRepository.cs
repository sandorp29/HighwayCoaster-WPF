// <copyright file="IGameRepository.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Repository
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for repository
    /// </summary>
    public interface IGameRepository : IDisposable
    {
        /// <summary>
        /// Gets all the players
        /// </summary>
        IEnumerable<Player> GetPlayers { get; }

        /// <summary>
        /// Gets all the cars
        /// </summary>
        IEnumerable<Car> GetCars { get; }

        /// <summary>
        /// Method to registerplayer
        /// </summary>
        /// <param name="player">Registered player</param>
        void Register(Player player);

        /// <summary>
        /// Method to delete the selected players highscore
        /// </summary>
        /// <param name="playerId">id of the player</param>
        void DeleteHighscore(decimal playerId);

        /// <summary>
        /// Method to save highscores
        /// </summary>
        /// <param name="playerId">id of the player</param>
        /// <param name="highScore">highscore of the player</param>
        void SaveHighscore(decimal playerId, int highScore);

        /// <summary>
        /// Method to change car
        /// </summary>
        /// <param name="playerId">id of the player</param>
        /// <param name="carId">id of the car</param>
        void ChangeCar(decimal playerId, decimal carId);
    }
}
