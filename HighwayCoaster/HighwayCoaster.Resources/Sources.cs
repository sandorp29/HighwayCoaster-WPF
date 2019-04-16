using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayCoaster.Resources
{
    public class Sources
    {
        
        public string LogoIMG { get { return AppDomain.CurrentDomain.BaseDirectory + @"\Resources\LOGO.png"; } }
        public string BackgroundIMG { get { return AppDomain.CurrentDomain.BaseDirectory + @"\Resources\1.jpg"; } }
    }
}
