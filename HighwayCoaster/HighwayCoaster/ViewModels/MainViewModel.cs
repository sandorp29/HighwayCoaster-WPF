namespace HighwayCoaster.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using GalaSoft.MvvmLight;
    using HighwayCoaster.Controls;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Resources;

    public class MainViewModel : ViewModelBase
    {
        FileSources sc = new FileSources(DesignerProperties.GetIsInDesignMode(new DependencyObject()));

        public MainViewModel()
        {
            this.WindowContent = new CarSelectionView();
        }

        public ContentControl WindowContent { get; private set; }

        public string Background
        {
            get
            {
                return this.sc.BackgroundLoop;
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
