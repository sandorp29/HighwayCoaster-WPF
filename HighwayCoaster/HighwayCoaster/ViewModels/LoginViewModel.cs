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
        }

        public string UserName
        {
            get => this.userName;

            set
            {
                this.userName = value;
                (LoginCommand as RelayCommand).RaiseCanExecuteChanged();
                (RegisterCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => this.password;

            set
            {
                this.password = value;
                (LoginCommand as RelayCommand).RaiseCanExecuteChanged();
                (RegisterCommand as RelayCommand).RaiseCanExecuteChanged();
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
            GameLogic.Login(UserName, Password);

            if (GameLogic.LoggedInPlayer != null)
            {
                this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
            }
        }

        public void RegisterMethod()
        {
            if (GameLogic.Register(UserName, Password))
            {
                LoginMethod();
            }
        }
    }
}
