namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Logic;

    public class MainMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        public MainMenuViewModel()
        {
            this.PlayGameCommand = new RelayCommand(this.PlayGameMethod);
            this.CarSelectCommand = new RelayCommand(this.CarSelectMethod);
            this.HighscoreCommand = new RelayCommand(this.HighscoreMethod);
            this.ExitCommand = new RelayCommand(this.ExitMethod);
        }

        /// <summary>
        /// Gets Play game command.
        /// </summary>
        public ICommand PlayGameCommand { get; private set; }

        /// <summary>
        /// Gets Car select command.
        /// </summary>
        public ICommand CarSelectCommand { get; private set; }

        /// <summary>
        /// Gets Highscore command.
        /// </summary>
        public ICommand HighscoreCommand { get; private set; }

        /// <summary>
        /// Gets Exit command.
        /// </summary>
        public ICommand ExitCommand { get; private set; }

        /// <summary>
        /// Gets or sets gamelogic object.
        /// </summary>
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
