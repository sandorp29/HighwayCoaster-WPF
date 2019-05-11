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
    using HighwayCoaster.Repository;

    public class CarSelectionViewModel
    {
        private Car selectedCar;

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public CarSelectionViewModel()
        {
            this.SelectCommand = new RelayCommand(this.SelectMethod, () => this.GameLogic != null && SelectedCar != null ? (this.GameLogic.LoggedInPlayer.Highscore >= SelectedCar.PointRequirement) : false);
            this.CancelCommand = new RelayCommand(this.CancelMethod);
        }

        public Car SelectedCar { get => selectedCar; set { selectedCar = value; (SelectCommand as RelayCommand).RaiseCanExecuteChanged(); } }

        public ICommand SelectCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public void SelectMethod() {
            this.GameLogic.ChangeCar(this.GameLogic.LoggedInPlayer.PlayerId, this.SelectedCar.CarId);
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
        }

        public void CancelMethod() {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
        }

    }
}
