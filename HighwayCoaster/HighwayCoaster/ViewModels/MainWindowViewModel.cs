// <copyright file="MainWindowViewModel.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Controls.ModalControls;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;

    /// <summary>
    /// Viewmodel for Main window
    /// </summary>
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        private IGameLogic gameLogic;
        private ContentControl windowContent;
        private Player selectedPlayer;
        private List<string> resolutions;
        private string selectedResolution;
        private bool disposedValue;
        private bool debugMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.disposedValue = false;
            this.gameLogic = new GameLogic();

            this.ChangeWindowState(MainWindowState.Login);
            this.ResizeMode = ResizeMode.NoResize;

            this.resolutions = new List<string>() { "800x450", "960x540", "1024x576", "1280x720", "1366x768", "1600x900" };
            this.selectedResolution = this.resolutions.First();
        }

        /// <summary>
        /// Gets the background.
        /// </summary>
        public string Background
        {
            get
            {
                return this.gameLogic.SC.BackgroundLoop;
            }
        }

        /// <summary>
        /// Gets all the resolution.
        /// </summary>
        public List<string> Resolutions
        {
            get
            {
                return this.resolutions;
            }
        }

        /// <summary>
        /// Gets or sets the selected rsolution.
        /// </summary>
        public string SelectedResolution
        {
            get
            {
                return this.selectedResolution;
            }

            set
            {
                this.WindowWidth = int.Parse(value.Split('x')[0]);
                this.RaisePropertyChanged("WindowWidth");
                this.WindowHeight = int.Parse(value.Split('x')[1]);
                this.RaisePropertyChanged("WindowHeight");
                this.selectedResolution = value;
            }
        }

        /// <summary>
        /// Gets the window content.
        /// </summary>
        public ContentControl WindowContent { get => this.windowContent; private set => this.windowContent = value; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is in debug mode
        /// </summary>
        public bool DebugMode { get => this.debugMode; set => this.debugMode = value; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public ResizeMode ResizeMode { get; set; }

        /// <summary>
        /// Gets or sets window width
        /// </summary>
        public int WindowWidth { get; set; }

        /// <summary>
        /// Gets or sets Window height.
        /// </summary>
        public int WindowHeight { get; set; }

        /// <summary>
        /// Gets or sets selected player.
        /// </summary>
        public Player SelectedPlayer { get => this.selectedPlayer; set => this.selectedPlayer = value; }

        /// <summary>
        /// Opens pop up window.
        /// </summary>
        /// <param name="msg">message</param>
        public void OpenModal(string msg)
        {
            new MessageWindow(Window.GetWindow(this.windowContent), msg).ShowDialog();
        }

        /// <summary>
        /// Subscribe event on window.
        /// </summary>
        /// <param name="func">Function event handler</param>
        public void SubscribeEventOnWindow(KeyEventHandler func)
        {
            Window.GetWindow(this.windowContent).KeyDown += func;
            Window.GetWindow(this.windowContent).KeyUp += func;
        }

        /// <summary>
        /// Unsubscribe event on window.
        /// </summary>
        /// <param name="func">function event handler</param>
        public void UnsubscribeEventOnWindow(KeyEventHandler func)
        {
            Window.GetWindow(this.windowContent).KeyDown -= func;
            Window.GetWindow(this.windowContent).KeyUp -= func;
        }

        /// <summary>
        /// Change the main window state.
        /// </summary>
        /// <param name="windowState">windowstate</param>
        public void ChangeWindowState(MainWindowState windowState)
        {
            switch (windowState)
            {
                case MainWindowState.Login:
                    this.WindowContent = new LoginView(this.gameLogic, this);
                    break;
                case MainWindowState.Highscore:
                    this.WindowContent = new HighscoreView(this.gameLogic, this);
                    break;
                case MainWindowState.MainMenu:
                    this.WindowContent = new MainMenuView(this.gameLogic, this);
                    break;
                case MainWindowState.CarSelection:
                    this.WindowContent = new CarSelectionView(this.gameLogic, this);
                    break;
                case MainWindowState.Play:
                    this.WindowContent = new PlayView(this.gameLogic, this);
                    this.RaisePropertyChanged("WindowContent");
                    ServiceLocator.Current.GetInstance<PlayViewModel>().Start();
                    break;
                default:
                    break;
            }

            this.RaisePropertyChanged("WindowContent");
            this.RaisePropertyChanged("ResizeMode");
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
                    this.gameLogic.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
