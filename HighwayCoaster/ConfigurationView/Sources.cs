using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationView
{
    public class Sources
    {
        
            ////public string BackgroundIMG { get { return @"Resources/Background"; } }
            //public string LogoIMG { get { return @"Resources/LOGO.png"; } }
        public string BackgroundIMG { get { return AppDomain.CurrentDomain.BaseDirectory + @"\Resources\1.jpg"; } }
        public string LogoIMG { get { return AppDomain.CurrentDomain.BaseDirectory + @"\Resources\LOGO.png"; } }
    }
}
