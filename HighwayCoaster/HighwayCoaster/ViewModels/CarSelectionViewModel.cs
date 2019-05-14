// <copyright file="CarSelectionViewModel.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

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

    /// <summary>
    /// View model for car selection window
    /// </summary>
    public class CarSelectionViewModel
    {
        private Car selectedCar;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarSelectionViewModel"/> class
        /// </summary>
        public CarSelectionViewModel()
        {
            this.SelectCommand = new RelayCommand(this.SelectMethod, () => this.GameLogic != null && this.SelectedCar != null ? (this.GameLogic.LoggedInPlayer.Highscore >= this.SelectedCar.PointRequirement) : false);
            this.CancelCommand = new RelayCommand(this.CancelMethod);
        }

        /// <summary>
        /// Gets or sets Game logic object
        /// </summary>
        public IGameLogic GameLogic { get; set; }

        /// <summary>
        /// Gets or sets Main view model object
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// Gets or sets selected car
        /// </summary>
        public Car SelectedCar
        {
            get => this.selectedCar;
            set
            {
                this.selectedCar = value;
                (this.SelectCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets select command
        /// </summary>
        public ICommand SelectCommand { get; private set; }

        /// <summary>
        /// Gets Cancel command
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        /// Methodr selecting car
        /// </summary>
        public void SelectMethod()
        {
            this.GameLogic.ChangeCar(this.GameLogic.LoggedInPlayer.PlayerId, this.SelectedCar.CarId);
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
        }

        /// <summary>
        /// Cncel metd back to main menu
        /// </summary>
        public void CancelMethod()
        {
            this.MainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
        }
    }
}
