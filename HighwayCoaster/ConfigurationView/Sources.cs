using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationView
{
    public class Sources
    {
        //public string BackgroundIMG { get { return AppDomain.CurrentDomain.BaseDirectory + @"\Resources\1.jpg"; } }
        //public string LogoIMG { get { return AppDomain.CurrentDomain.BaseDirectory + @"\Resources\LOGO.png"; } }
        public string LogoIMG { get { return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName) + @"\ConfigurationView\Resources\LOGO.png"; } }
        public string BackgroundIMG { get { return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName) + @"\ConfigurationView\Resources\1.jpg"; } }
    }
}
