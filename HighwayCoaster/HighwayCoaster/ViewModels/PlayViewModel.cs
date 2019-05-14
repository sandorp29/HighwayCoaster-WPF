// <copyright file="PlayViewModel.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using HighwayCoaster.Logic;
    using HighwayCoaster.ViewModels.ViewModelHelpers;

    /// <summary>
    /// View model for play view
    /// </summary>
    public class PlayViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayViewModel"/> class.
        /// </summary>
        public PlayViewModel()
        {
            this.GA = new GameArea();
        }

        /// <summary>
        /// Gets or sets the game area
        /// </summary>
        public GameArea GA { get; set; }

        /// <summary>
        /// Gets or sets the gamelogic object
        /// </summary>
        public IGameLogic GameLogic { get; set; }

        /// <summary>
        /// Gets or sets Main view model object
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// Sets upgame area
        /// </summary>
        public void Start()
        {
            this.GA.Setup(this.GameLogic, this.MainWindowViewModel);
        }
    }
}
