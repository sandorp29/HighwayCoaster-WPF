namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Logic;

    public class HighscoreViewModel : ViewModelBase
    {
        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public ICommand CancelCommand { get; private set; }

        public HighscoreViewModel()
        {
            this.CancelCommand = new RelayCommand(this.CancelMethod);
        }

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
    }
}
