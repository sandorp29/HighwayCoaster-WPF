namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Repository;

    public class HighscoreViewModel : ViewModelBase
    {

        public HighscoreViewModel()
        {
            this.CancelCommand = new RelayCommand(this.CancelMethod);
            this.DeleteCommand = new RelayCommand(this.DeleteMethod, () => this.GameLogic.LoggedInPlayer != null && this.GameLogic.LoggedInPlayer.IsAdmin == true);

        }

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public ICommand CancelCommand { get; private set; }

        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Player> HighscoreList { get => GameLogic.HighScoreHelper; }

        public Player SelectedPlayer { get; set; }

        public Visibility IsDeleteButtonActive { get => (this.GameLogic.LoggedInPlayer != null && this.GameLogic.LoggedInPlayer.IsAdmin == true) ? Visibility.Visible : Visibility.Hidden; }

        public void CancelMethod()
            {
                if (this.GameLogic.PrevWindow == true)
                {
                    this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
                }
                else
                {
                    this.MainWindowViewModel.ChangeWindowState(MainWindowState.Login);
                }
            }

        public void DeleteMethod()
        {
            this.GameLogic.DeleteHighscore(SelectedPlayer.PlayerId);
            this.RaisePropertyChanged("HighscoreList");
        }
    }
}
