// <copyright file="LoginView.xaml.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginView"/> class.
        /// Constructor for Login view
        /// </summary>
        /// <param name="gameLogic">game logic object</param>
        /// <param name="mainWindowViewModel">main window viewmodel object</param>
        public LoginView(IGameLogic gameLogic, MainWindowViewModel mainWindowViewModel)
        {
            ServiceLocator.Current.GetInstance<LoginViewModel>().GameLogic = gameLogic;
            ServiceLocator.Current.GetInstance<LoginViewModel>().MainWindowViewModel = mainWindowViewModel;

            this.InitializeComponent();
        }
    }
}
