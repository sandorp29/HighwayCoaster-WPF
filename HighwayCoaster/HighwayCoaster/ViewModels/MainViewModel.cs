using HighwayCoaster.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HighwayCoaster.ViewModels
{

    class MainViewModel
    {
        Sources sc = new Sources();

        public ImageSource Background
        {
            get
            {
                return new BitmapImage(new Uri(sc.BackgroundIMG, UriKind.Relative));
            }

        }
        public ImageSource Logo
        {
            get
            {
                return new BitmapImage(new Uri(sc.LogoIMG, UriKind.Relative));
            }
        }
    }
}
