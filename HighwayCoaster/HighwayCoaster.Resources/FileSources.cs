using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HighwayCoaster.Resources
{
    public class FileSources
    {      
        private string resourceFolderPath;

        public string LogoIMG { get { return resourceFolderPath + @"LOGO.png"; } }
        public string BackgroundIMG { get { return resourceFolderPath + @"1.jpg"; } }

        public FileSources(bool isInDesignerMode)
        {
            if (isInDesignerMode)
            {
                if (Environment.MachineName == "DESKTOP-PEM11MB")
                {
                    resourceFolderPath = @"E:\Workspace\School\dev\oenik_prog4_2019_1_x90npx_xls22h\HighwayCoaster\HighwayCoaster.Resources\Resources\";
                }
                else
                {
                    resourceFolderPath = @"C:\Users\Felhasználó\Documents\oenik_prog4_2019_1_x90npx_xls22h\HighwayCoaster\HighwayCoaster.Resources\Resources\";
                }
            }
            else
            {
                resourceFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\";
            }
        }
    }
}
