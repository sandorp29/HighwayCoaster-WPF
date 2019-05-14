// <copyright file="MainMenuViewModel.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Logic;

    /// <summary>
    /// View model for main menu window
    /// </summary>
    public class MainMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        public MainMenuViewModel()
        {
            this.PlayGameCommand = new RelayCommand(this.PlayGameMethod);
            this.CarSelectCommand = new RelayCommand(this.CarSelectMethod);
            this.HighscoreCommand = new RelayCommand(this.HighscoreMethod);
            this.ExitCommand = new RelayCommand(this.ExitMethod);
        }

        /// <summary>
        /// Gets Play game command.
        /// </summary>
        public ICommand PlayGameCommand { get; private set; }

        /// <summary>
        /// Gets Car select command.
        /// </summary>
        public ICommand CarSelectCommand { get; private set; }

        /// <summary>
        /// Gets Highscore command.
        /// </summary>
        public ICommand HighscoreCommand { get; private set; }

        /// <summary>
        /// Gets Exit command.
        /// </summary>
        public ICommand ExitCommand { get; private set; }

        /// <summary>
        /// Gets or sets gamelogic object.
        /// </summary>
        public IGameLogic GameLogic { get; set; }

        /// <summary>
        /// Gets or sets main window view model bject.
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// Gets the Bitmap image of the logo
        /// </summary>
        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(this.GameLogic.SC.LogoImg, UriKind.Relative));
            }
        }

        /// <summary>
        /// Method to start playing the game
        /// </summary>
        public void PlayGameMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.Play);
        }

        /// <summary>
        /// Method to enter the car selection view
        /// </summary>
        public void CarSelectMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.CarSelection);
        }

        /// <summary>
        /// Method to enter the highscore view.
        /// </summary>
        public void HighscoreMethod()
        {
            this.GameLogic.PrevWindow = true;
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.Highscore);
        }

        /// <summary>
        /// method to close the game.
        /// </summary>
        public void ExitMethod()
        {
            Environment.Exit(0);
        }
    }
}
