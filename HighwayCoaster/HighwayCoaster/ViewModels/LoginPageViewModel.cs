using HighwayCoaster.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFZH.Helpers;

namespace HighwayCoaster.ViewModels
{
    class LoginPageViewModel : MainViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        UserLogic UL;
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(LoginMethod, t => UserName !=null && PassWord != null);
            RegisterCommand = new RelayCommand(RegisterMethod, t => UserName != null && PassWord != null);
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        public void LoginMethod(object o) {
            
        }

        public void RegisterMethod(object o) {

        }
    }
}
