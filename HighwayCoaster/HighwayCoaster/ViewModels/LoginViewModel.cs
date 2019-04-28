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
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Logic;

    public class LoginViewModel : MainWindowViewModel
    {
        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand(this.LoginMethod, () => this.UserName == null && this.PassWord != null);
            this.RegisterCommand = new RelayCommand(this.RegisterMethod, () => this.UserName != null && this.PassWord != null);
        }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public ICommand LoginCommand { get; private set; }

        public ICommand RegisterCommand { get; private set; }

        public ICommand HighscoreCommand { get; private set; }

        public void LoginMethod()
        {
            MainMenuView mm = new MainMenuView();
        }

        public void RegisterMethod()
        {
            this.gameLogic.Register(this.UserName, this.PassWord);
        }
    }
}
