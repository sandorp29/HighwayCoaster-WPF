namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;
    using HighwayCoaster.Resources;

    public class MainWindowViewModel : ViewModelBase
    {
        FileSources sc = new FileSources(DesignerProperties.GetIsInDesignMode(new DependencyObject()));
        internal Player loggedInPlayer;
        internal IGameLogic gameLogic;
        internal ContentControl windowContent;

        public MainWindowViewModel()
        {
            gameLogic = new GameLogic();
            ChangeWindowState(MainWindowState.Login);
        }

        public ContentControl WindowContent => this.windowContent;

        public string Background
        {
            get
            {
                return this.sc.BackgroundLoop;
            }

        }

        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(this.sc.LogoIMG, UriKind.Relative));
            }
        }

        public void ChangeWindowState(MainWindowState windowState)
        {
            switch (windowState)
            {
                case MainWindowState.Login:
                    this.windowContent = new LoginView();
                    break;
                case MainWindowState.Highscore:
                    this.windowContent = new HighscoreView();
                    break;
                case MainWindowState.MainMenu:
                    this.windowContent = new MainMenuView();
                    break;
                case MainWindowState.CarSelection:
                    this.windowContent = new CarSelectionView();
                    break;
                case MainWindowState.Play:
                    this.windowContent = new PlayView();
                    break;
                default:
                    break;
            }
        }
    }
}
