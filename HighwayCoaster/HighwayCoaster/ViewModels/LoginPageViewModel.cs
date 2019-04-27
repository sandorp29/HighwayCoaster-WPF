namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Logic;

    public class LoginPageViewModel : MainViewModel
    {
        private GameLogic uL;

        public LoginPageViewModel()
        {
            this.LoginCommand = new RelayCommand(this.LoginMethod, () => this.UserName != null && this.PassWord != null);
            this.RegisterCommand = new RelayCommand(this.RegisterMethod, () => this.UserName != null && this.PassWord != null);
        }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public ICommand LoginCommand { get; private set; }

        public ICommand RegisterCommand { get; private set; }

        public void LoginMethod()
        {
            MainMenu mm = new MainMenu();
        }

        public void RegisterMethod()
        {
            this.uL.Register(this.UserName, this.PassWord);
        }
    }
}
