// <copyright file="ImgPathConverter.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Controls.ControlConverters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Class that converts images from path
    /// </summary>
    public class ImgPathConverter : IValueConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="targetType">targetType</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>object</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                ImageSource imageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + (value as string)));
                return imageSource;
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// Cver back
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="targetType">targetType</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
