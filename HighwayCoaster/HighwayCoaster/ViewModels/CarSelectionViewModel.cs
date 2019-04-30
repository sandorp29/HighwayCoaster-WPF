namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using HighwayCoaster.Logic;

    public class CarSelectionViewModel
    {
        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public CarSelectionViewModel()
        {
            SelectCommand = new RelayCommand(this.SelectMethod);
            CancelCommand = new RelayCommand(this.CancelMethod);
        }

        public ICommand SelectCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public void SelectMethod() {
            this.GameLogic.ChangeCar(this.GameLogic.LoggedInPlayer.PlayerId, this.MainWindowViewModel.SelectedCar.CarId);
        }

        public void CancelMethod() {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
        }

    }
}
