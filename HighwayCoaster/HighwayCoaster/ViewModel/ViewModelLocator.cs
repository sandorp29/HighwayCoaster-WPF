// <copyright file="ViewModelLocator.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModel
{
    /*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:HighwayCoaster"
                           x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using HighwayCoaster.ViewModels;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelLocator"/> class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainMenuViewModel>();
            SimpleIoc.Default.Register<HighscoreViewModel>();
            SimpleIoc.Default.Register<CarSelectionViewModel>();
            SimpleIoc.Default.Register<PlayViewModel>();
        }

        /// <summary>
        /// Gets main window view model
        /// </summary>
        public MainWindowViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        /// <summary>
        /// Gets login view model
        /// </summary>
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        /// <summary>
        /// Gets main menu view model
        /// </summary>
        public MainMenuViewModel Menu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainMenuViewModel>();
            }
        }

        /// <summary>
        /// Gets highscore view model
        /// </summary>
        public HighscoreViewModel Highscore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HighscoreViewModel>();
            }
        }

        /// <summary>
        /// Gets car selection view model
        /// </summary>
        public CarSelectionViewModel CarSelect
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CarSelectionViewModel>();
            }
        }

        /// <summary>
        /// Gets play view model
        /// </summary>
        public PlayViewModel Play
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlayViewModel>();
            }
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}