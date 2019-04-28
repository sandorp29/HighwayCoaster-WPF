using HighwayCoaster.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows;
using HighwayCoaster.Logic;
using System.Windows.Controls;
using HighwayCoaster.Controls;

namespace HighwayCoaster.ViewModels
{

    public class MainViewModel : ViewModelBase
    {
        FileSources sc = new FileSources(DesignerProperties.GetIsInDesignMode(new DependencyObject()));

        public MainViewModel()
        {
            WindowContent = new LoginView();
        }

        public ContentControl WindowContent { get; private set; }

        public ImageSource Background
        {
            get
            {
                return new BitmapImage(new Uri(this.sc.BackgroundIMG, UriKind.Relative));
            }

        }

        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(this.sc.LogoIMG, UriKind.Relative));
            }
        }
    }
}
