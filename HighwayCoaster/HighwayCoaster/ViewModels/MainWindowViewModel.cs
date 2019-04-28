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
        private IGameLogic gameLogic;
        private ContentControl windowContent;

        public MainWindowViewModel()
        {
            this.gameLogic = new GameLogic();
            this.ChangeWindowState(MainWindowState.CarSelection);
        }

        public string Background
        {
            get
            {
                return this.gameLogic.Sc.BackgroundLoop;
            }

        }

        public ContentControl WindowContent { get => this.windowContent; }

        public void ChangeWindowState(MainWindowState windowState)
        {
            switch (windowState)
            {
                case MainWindowState.Login:
                    this.windowContent = new LoginView(this.gameLogic, this);
                    break;
                case MainWindowState.Highscore:
                    this.windowContent = new HighscoreView(this.gameLogic, this);
                    break;
                case MainWindowState.MainMenu:
                    this.windowContent = new MainMenuView(this.gameLogic, this);
                    break;
                case MainWindowState.CarSelection:
                    this.windowContent = new CarSelectionView(this.gameLogic, this);
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
