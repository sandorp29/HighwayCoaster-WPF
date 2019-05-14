// <copyright file="CarSelectionView.xaml.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using CommonServiceLocator;
    using HighwayCoaster.Logic;
    using HighwayCoaster.ViewModels;

    /// <summary>
    /// Interaction logic for CarSelectionView.xaml
    /// </summary>
    public partial class CarSelectionView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarSelectionView"/> class.
        /// </summary>
        /// <param name="gameLogic">GL object</param>
        /// <param name="mainWindowViewModel">MWVM object</param>
        public CarSelectionView(IGameLogic gameLogic, MainWindowViewModel mainWindowViewModel)
        {
            ServiceLocator.Current.GetInstance<CarSelectionViewModel>().GameLogic = gameLogic;
            ServiceLocator.Current.GetInstance<CarSelectionViewModel>().MainWindowViewModel = mainWindowViewModel;

            this.InitializeComponent();
        }
    }
}
