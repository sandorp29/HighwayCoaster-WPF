namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Controls.ModalControls;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;
    using HighwayCoaster.Resources;
    using HighwayCoaster.ViewModel;

    public class MainWindowViewModel : ViewModelBase
    {
        private IGameLogic gameLogic;
        private ContentControl windowContent;
        private Car selectedCar;
        private Player selectedPlayer;
        private List<string> resolutions;
        private string selectedResolution;

        public MainWindowViewModel()
        {
            this.gameLogic = new GameLogic();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => this.gameLogic.Dispose();

            this.ChangeWindowState(MainWindowState.Login);
            this.ResizeMode = ResizeMode.NoResize;

            this.resolutions = new List<string>() { "800x450", "960x540", "1024x576", "1280x720", "1366x768", "1600x900" };
            selectedResolution = resolutions.First();
        }

        public string Background
        {
            get
            {
                return this.gameLogic.Sc.BackgroundLoop;
            }

        }

        public List<string> Resolutions
        {
            get
            {
                return resolutions;
            }
        }

        public string SelectedResolution
        {
            get
            {
                return selectedResolution;
            }

            set
            {
                this.WindowWidth = int.Parse(value.Split('x')[0]);
                this.RaisePropertyChanged("WindowWidth");
                this.WindowHeight = int.Parse(value.Split('x')[1]);
                this.RaisePropertyChanged("WindowHeight");
                selectedResolution = value;
            }
        }

        public ContentControl WindowContent { get => this.windowContent; private set => this.windowContent = value; }

        public ResizeMode ResizeMode { get; set; }

        public int WindowWidth { get; set; }

        public int WindowHeight { get; set; }

        public Player SelectedPlayer { get => selectedPlayer; set => selectedPlayer = value; }

        public void OpenModal(string msg)
        {
            new MessageWindow(Window.GetWindow(this.windowContent), msg).ShowDialog();
        }

        public void SubscribeEventOnWindow(KeyEventHandler func)
        {
            Window.GetWindow(this.windowContent).KeyDown += func;
            Window.GetWindow(this.windowContent).KeyUp += func;
        }

        public void UnsubscribeEventOnWindow(KeyEventHandler func)
        {
            Window.GetWindow(this.windowContent).KeyDown -= func;
            Window.GetWindow(this.windowContent).KeyUp -= func;
        }

        public void ChangeWindowState(MainWindowState windowState)
        {
            switch (windowState)
            {
                case MainWindowState.Login:
                    this.WindowContent = new LoginView(this.gameLogic, this);
                    break;
                case MainWindowState.Highscore:
                    this.WindowContent = new HighscoreView(this.gameLogic, this);
                    break;
                case MainWindowState.MainMenu:
                    this.WindowContent = new MainMenuView(this.gameLogic, this);
                    break;
                case MainWindowState.CarSelection:
                    this.WindowContent = new CarSelectionView(this.gameLogic, this);
                    break;
                case MainWindowState.Play:
                    this.WindowContent = new PlayView(this.gameLogic, this);
                    this.RaisePropertyChanged("WindowContent");
                    ServiceLocator.Current.GetInstance<PlayViewModel>().Start();
                    break;
                default:
                    break;
            }

            this.RaisePropertyChanged("WindowContent");
            this.RaisePropertyChanged("ResizeMode");
        }
    }
}
