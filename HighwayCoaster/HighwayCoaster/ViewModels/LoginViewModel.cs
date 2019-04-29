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

    public class LoginViewModel : ViewModelBase
    {
        private string userName;
        private string password;

        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand(this.LoginMethod, () => !string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password));
            this.RegisterCommand = new RelayCommand(this.RegisterMethod, () => !string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password));
            this.PasswordChanged = new RelayCommand<object>(this.OnPasswordChangedMethod);
            this.HighscoreCommand = new RelayCommand(this.HighscoreMethod);
        }

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

        public ICommand LoginCommand { get; private set; }

        public ICommand RegisterCommand { get; private set; }

        public ICommand PasswordChanged { get; private set; }

        public ICommand HighscoreCommand { get; private set; }

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(this.GameLogic.Sc.LogoIMG, UriKind.Relative));
            }
        }

        public void OnPasswordChangedMethod(object obj)
        {
            this.Password = (obj as PasswordBox).Password;
        }

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

        public void HighscoreMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.Highscore);
        }
    }
}
