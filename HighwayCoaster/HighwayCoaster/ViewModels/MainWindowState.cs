// <copyright file="MainWindowState.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains the posible states of the main window
    /// </summary>
    public enum MainWindowState
    {
        /// <summary>
        /// login state
        /// </summary>
        Login,

        /// <summary>
        /// Highscore state
        /// </summary>
        Highscore,

        /// <summary>
        /// Main menu state
        /// </summary>
        MainMenu,

        /// <summary>
        /// Car select state
        /// </summary>
        CarSelection,

        /// <summary>
        /// Play view state
        /// </summary>
        Play
    }
}
