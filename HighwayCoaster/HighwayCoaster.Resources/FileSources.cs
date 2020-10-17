// <copyright file="FileSources.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Resources
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// FileSources class
    /// </summary>
    public class FileSources
    {
        private string resourceFolderPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSources"/> class.
        /// </summary>
        public FileSources()
        {
            this.resourceFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\";
        }

        /// <summary>
        /// Gets the path of the LogoIMG
        /// </summary>
        public string LogoImg
        {
            get { return this.resourceFolderPath + @"LOGO.png"; }
        }

        /// <summary>
        /// Gets the BackgroundLoop video path
        /// </summary>
        public string BackgroundLoop
        {
            get { return this.resourceFolderPath + @"backgroundloop.wmv"; }
        }

        /// <summary>
        /// Gets the ObstacleImg
        /// </summary>
        public string ObstacleImg
        {
            get { return this.resourceFolderPath + @"obstacle.png"; }
        }
    }
}
