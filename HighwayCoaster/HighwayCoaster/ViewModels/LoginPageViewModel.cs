using GalaSoft.MvvmLight.Command;
using HighwayCoaster.Controls;
using HighwayCoaster.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HighwayCoaster.ViewModels
{
    class LoginPageViewModel : MainViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        UserLogic UL;
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(LoginMethod, () => UserName !=null && PassWord != null);
            RegisterCommand = new RelayCommand(RegisterMethod, () => UserName != null && PassWord != null);
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        public void LoginMethod() {
            MainMenu mm = new MainMenu();
            
            
        }

        public void RegisterMethod() {
            UL.Login();
        }
    }
}
