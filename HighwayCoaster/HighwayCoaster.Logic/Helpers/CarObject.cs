using HighwayCoaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HighwayCoaster.Logic.Helpers
{
    public class CarObject
    {
        Rect carBody;
        Point frontWheelPoint;
        Point rearWheelPoint;
        double wheelSize;
        BitmapImage carBodyImage;
        BitmapImage carWheelImage;


        public CarObject(Car car, int areaWidth, int areaHeight)
        {
            carBodyImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + car.ViewResourcesPath));
            carWheelImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + car.WheelResource));

            carBody = new Rect(areaWidth / 3, areaHeight / 3, carBodyImage.Width / 6, carBodyImage.Height / 6);

            wheelSize = 15;

            frontWheelPoint = new Point(carBody.Right, carBody.Bottom);
            RearWheelPoint = new Point(carBody.Left, carBody.Bottom);
        }

        public Rect CarBody { get => carBody; private set => carBody = value; }

        public Point FrontWheelPoint { get => frontWheelPoint; private set => frontWheelPoint = value; }

        public Point RearWheelPoint { get => rearWheelPoint; private set => rearWheelPoint = value; }

        public double WheelSize { get => wheelSize; private set => wheelSize = value; }

        public BitmapImage CarBodyImage { get => carBodyImage; private set => carBodyImage = value; }

        public BitmapImage CarWheelImage { get => carWheelImage; private set => carWheelImage = value; }
    }
}
