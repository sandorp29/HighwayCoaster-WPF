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
        double angle;
        int areaWidth;
        int areaHeight;

        public CarObject(Car car, int areaWidth, int areaHeight)
        {
            this.areaWidth = areaWidth;
            this.areaHeight = areaWidth;

            carBodyImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + car.ViewResourcesPath));
            carWheelImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + car.WheelResource));

            carBody = new Rect(areaWidth / 6, areaHeight / 2.32, areaWidth / 9.4, areaHeight / 18.37);

            double size = areaWidth/(carBodyImage.Width / 16);
            double size2 = areaHeight/(carBodyImage.Height / 16);

            wheelSize = carBody.Width / 10;
            angle = 0;

            frontWheelPoint = new Point(Math.Round(carBody.Left + wheelSize + carBody.Width / 1.4), carBody.Bottom - wheelSize/1.5);
            rearWheelPoint = new Point(Math.Round(carBody.Left + wheelSize + carBody.Width / 15), carBody.Bottom - wheelSize/1.5);
        }

        public void Step(List<Point> carGuidePoints)
        {
            Point pointAtFront = carGuidePoints.First(x => x.X == frontWheelPoint.X);
            Point pointAtRear = carGuidePoints.First(x => x.X == rearWheelPoint.X);

            FrontWheelPoint = new Point(frontWheelPoint.X , pointAtFront.Y - wheelSize - wheelSize/3);
            RearWheelPoint = new Point(rearWheelPoint.X, pointAtRear.Y - wheelSize - wheelSize/3);

            var radian = Math.Atan2((rearWheelPoint.Y - frontWheelPoint.Y), (frontWheelPoint.X - rearWheelPoint.X));

            angle = 360 - (radian * (180 / Math.PI) + 360) % 360;

            carBody.Y = carGuidePoints.First(x => x.X == Math.Round(carBody.Left + carBody.Width / 2)).Y - carBody.Height - wheelSize/1.5;
        }

        public Rect CarBody { get => carBody; private set => carBody = value; }

        public Point FrontWheelPoint { get => frontWheelPoint; private set => frontWheelPoint = value; }

        public Point RearWheelPoint { get => rearWheelPoint; private set { rearWheelPoint = value; } }

        public double WheelSize { get => wheelSize; private set => wheelSize = value; }

        public BitmapImage CarBodyImage { get => carBodyImage; private set => carBodyImage = value; }

        public BitmapImage CarWheelImage { get => carWheelImage; private set => carWheelImage = value; }

        public double Angle { get => angle; private set => angle = value; }
    }
}
