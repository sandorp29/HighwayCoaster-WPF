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
        Player loggedInPlayer;

        public MainWindowViewModel()
        {
            ChangeWindowState(MainWindowState.MainMenu);
        }

        public void ChangeWindowState(MainWindowState windowState)
        {
            switch (windowState)
            {
                case MainWindowState.Login:
                    this.WindowContent = new LoginView();
                    break;
                case MainWindowState.Highscore:
                    this.WindowContent = new HighscoreView();
                    break;
                case MainWindowState.MainMenu:
                    this.WindowContent = new MainMenuView();
                    break;
                case MainWindowState.CarSelection:
                    this.WindowContent = new CarSelectionView();
                    break;
                case MainWindowState.Play:
                    this.WindowContent = new PlayView();
                    break;
                default:
                    break;
            }
        }

        public ContentControl WindowContent { get; private set; }

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
    }
}
