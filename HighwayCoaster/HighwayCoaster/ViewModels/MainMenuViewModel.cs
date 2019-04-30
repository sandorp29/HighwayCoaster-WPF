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
            this.PlayGameCommand = new RelayCommand(this.PlayGameMethod);
            this.CarSelectCommand = new RelayCommand(this.CarSelectMethod);
            this.HighscoreCommand = new RelayCommand(this.HighscoreMethod);
            this.ExitCommand = new RelayCommand(this.ExitMethod);
        }

        public ICommand PlayGameCommand { get; private set; }

        public ICommand CarSelectCommand { get; private set; }

        public ICommand HighscoreCommand { get; private set; }

        public ICommand ExitCommand { get; private set; }

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public void PlayGameMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.Play);
        }

        public void CarSelectMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.CarSelection);
        }

        public void HighscoreMethod()
        {
            this.GameLogic.PrevWindow = true;
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.Highscore);
        }

        public void ExitMethod()
        {
            Environment.Exit(0);
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
