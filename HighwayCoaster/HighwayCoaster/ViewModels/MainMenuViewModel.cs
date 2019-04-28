using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HighwayCoaster.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HighwayCoaster.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public MainMenuViewModel()
        {
        }

        public ICommand PlayGameCommand { get; private set; }

        public ICommand CarSelectCommand { get; private set; }

        public ICommand HighscoreCommand { get; private set; }

        public ICommand ExitCommand { get; private set; }

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public void PlayGameMethod(object o)
        {
        }

        public void CarSelectMethod(object o)
        {
        }

        public void HighscoreMethod(object o)
        {
        }

        public void ExitMethod(object o)
        {
        }

        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(this.GameLogic.Sc.LogoIMG, UriKind.Relative));
            }
        }
    }
}
