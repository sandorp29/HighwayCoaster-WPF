// <copyright file="LoginViewModel.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Controls.ModalControls;
    using HighwayCoaster.Logic;

    /// <summary>
    /// Viewmodel for Login View.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private string userName;
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand(this.LoginMethod, () => !string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password));
            this.RegisterCommand = new RelayCommand(this.RegisterMethod, () => !string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password));
            this.PasswordChanged = new RelayCommand<object>(this.OnPasswordChangedMethod);
            this.HighscoreCommand = new RelayCommand(this.HighscoreMethod);
        }

        /// <summary>
        /// Gets or sets the Property for Username.
        /// </summary>
        public string UserName
        {
            get => this.userName;

            set
            {
                this.userName = value;
                (this.LoginCommand as RelayCommand).RaiseCanExecuteChanged();
                (this.RegisterCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password
        {
            get => this.password;

            set
            {
                this.password = value;
                (this.LoginCommand as RelayCommand).RaiseCanExecuteChanged();
                (this.RegisterCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets Login Command,
        /// </summary>
        public ICommand LoginCommand { get; private set; }

        /// <summary>
        /// Gets Register Command.
        /// </summary>
        public ICommand RegisterCommand { get; private set; }

        /// <summary>
        /// Gets Password changed command.
        /// </summary>
        public ICommand PasswordChanged { get; private set; }

        /// <summary>
        /// Gets Highscore command
        /// </summary>
        public ICommand HighscoreCommand { get; private set; }

        /// <summary>
        /// Gets or sets Gamelogic.
        /// </summary>
        public IGameLogic GameLogic { get; set; }

        /// <summary>
        /// Gets or sets MainWindowViewModel object.
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; set; }

        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(this.GameLogic.Sc.LogoIMG, UriKind.Relative));
            }
        }

        /// <summary>
        /// OnPasswordChange method.
        /// </summary>
        /// <param name="obj">obj</param>
        public void OnPasswordChangedMethod(object obj)
        {
            this.Password = (obj as PasswordBox).Password;
        }

        /// <summary>
        /// Login method for Login Command.
        /// </summary>
        public void LoginMethod()
        {
            this.GameLogic.Login(this.UserName, this.Password);

            if (this.GameLogic.LoggedInPlayer != null)
            {
                this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
            }
            else
            {
                this.MainWindowViewModel.OpenModal("Login failed!\nThere is no player with the given username and password!");
            }
        }

        /// <summary>
        /// Register method for Register command.
        /// </summary>
        public void RegisterMethod()
        {
            if (this.GameLogic.Register(this.UserName, this.Password))
            {
                this.LoginMethod();
            }
            else
            {
                this.MainWindowViewModel.OpenModal("Registration failed!\nThere is a player already registered with the same username!");
            }
        }

        /// <summary>
        /// Highscore method for highscore command. 
        /// </summary>
        public void HighscoreMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.Highscore);
        }
    }
}
