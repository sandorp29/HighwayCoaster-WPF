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

            carBody = new Rect(areaWidth / 6, areaHeight / 2.32, areaWidth / 9.4, areaHeight / 18.37);

            double size = areaWidth/(carBodyImage.Width / 16);
            double size2 = areaHeight/(carBodyImage.Height / 16);

            wheelSize = carBody.Width / 10;

            frontWheelPoint = new Point(carBody.Left + wheelSize + carBody.Width / 1.4, carBody.Bottom - wheelSize/1.5);
            RearWheelPoint = new Point(carBody.Left + wheelSize + carBody.Width / 15, carBody.Bottom - wheelSize/1.5);
        }

        public void Step()
        {

        }

        public Rect CarBody { get => carBody; private set => carBody = value; }

        public Point FrontWheelPoint { get => frontWheelPoint; private set => frontWheelPoint = value; }

        public Point RearWheelPoint { get => rearWheelPoint; private set => rearWheelPoint = value; }

        public double WheelSize { get => wheelSize; private set => wheelSize = value; }

        public BitmapImage CarBodyImage { get => carBodyImage; private set => carBodyImage = value; }

        public BitmapImage CarWheelImage { get => carWheelImage; private set => carWheelImage = value; }
    }
}
