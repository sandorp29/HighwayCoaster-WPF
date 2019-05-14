namespace HighwayCoaster.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using CommonServiceLocator;
    using HighwayCoaster.Logic;
    using HighwayCoaster.ViewModels;

    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(IGameLogic gameLogic, MainWindowViewModel mainWindowViewModel)
        {
            ServiceLocator.Current.GetInstance<LoginViewModel>().GameLogic = gameLogic;
            ServiceLocator.Current.GetInstance<LoginViewModel>().MainWindowViewModel = mainWindowViewModel;

            this.InitializeComponent();
        }
    }
}
