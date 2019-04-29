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
    using HighwayCoaster.Controls.ModalControls;
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

            AppDomain.CurrentDomain.ProcessExit += (s, e) => this.gameLogic.Dispose();

            this.ChangeWindowState(MainWindowState.Login);
        }

        public string Background
        {
            get
            {
                return this.gameLogic.Sc.BackgroundLoop;
            }

        }

        public ContentControl WindowContent { get => this.windowContent; private set => this.windowContent = value; }

        public ResizeMode ResizeMode { get; set; }

        public void OpenModal(string msg)
        {
            new MessageWindow(Window.GetWindow(this.windowContent), msg).ShowDialog();
        }

        public void ChangeWindowState(MainWindowState windowState)
        {
            switch (windowState)
            {
                case MainWindowState.Login:
                    this.WindowContent = new LoginView(this.gameLogic, this);
                    this.ResizeMode = ResizeMode.CanResize;
                    break;
                case MainWindowState.Highscore:
                    this.WindowContent = new HighscoreView(this.gameLogic, this);
                    this.ResizeMode = ResizeMode.CanResize;
                    break;
                case MainWindowState.MainMenu:
                    this.WindowContent = new MainMenuView(this.gameLogic, this);
                    this.ResizeMode = ResizeMode.CanResize;
                    break;
                case MainWindowState.CarSelection:
                    this.WindowContent = new CarSelectionView(this.gameLogic, this);
                    this.ResizeMode = ResizeMode.CanResize;
                    break;
                case MainWindowState.Play:
                    this.WindowContent = new PlayView(this.gameLogic, this);
                    this.ResizeMode = ResizeMode.NoResize;
                    break;
                default:
                    break;
            }

            this.RaisePropertyChanged("WindowContent");
            this.RaisePropertyChanged("ResizeMode");
        }
    }
}
