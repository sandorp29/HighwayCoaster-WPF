// <copyright file="HighscoreViewModel.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;

    /// <summary>
    /// View model for highscore view
    /// </summary>
    public class HighscoreViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreViewModel"/> class.
        /// </summary>
        public HighscoreViewModel()
        {
            this.CancelCommand = new RelayCommand(this.CancelMethod);
            this.DeleteCommand = new RelayCommand(this.DeleteMethod, () => this.GameLogic.LoggedInPlayer != null && this.GameLogic.LoggedInPlayer.IsAdmin == true);
        }

        /// <summary>
        /// Gets or sets game logc object
        /// </summary>
        public IGameLogic GameLogic { get; set; }

        /// <summary>
        /// Gets or sets main window view model object
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// Gets Cancel command
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        /// Gets or sets delete Command
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Gets Highscorelist observable collecion
        /// </summary>
        public ObservableCollection<Player> HighscoreList { get => this.GameLogic.HighScoreHelper; }

        /// <summary>
        /// Gets or sets selected player
        /// </summary>
        public Player SelectedPlayer { get; set; }

        /// <summary>
        /// Gets delete button visibility
        /// </summary>
        public Visibility IsDeleteButtonActive { get => (this.GameLogic.LoggedInPlayer != null && this.GameLogic.LoggedInPlayer.IsAdmin == true) ? Visibility.Visible : Visibility.Hidden; }

        /// <summary>
        /// Method for cancel to main menu
        /// </summary>
        public void CancelMethod()
            {
                if (this.GameLogic.PrevWindow == true)
                {
                    this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
                }
                else
                {
                    this.MainWindowViewModel.ChangeWindowState(MainWindowState.Login);
                }
            }

        /// <summary>
        /// Method or deleting highscore
        /// </summary>
        public void DeleteMethod()
        {
            this.GameLogic.DeleteHighscore(this.SelectedPlayer.PlayerId);
            this.RaisePropertyChanged("HighscoreList");
        }
    }
}
