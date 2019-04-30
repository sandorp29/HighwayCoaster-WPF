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


        public CarObject(Car car, int areaWidth, int areaHeight)
        {
            carBodyImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + car.ViewResourcesPath));
            carWheelImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + car.WheelResource));

            carBody = new Rect(areaWidth / 6, areaHeight / 2.32, areaWidth / 9.4, areaHeight / 18.37);

            double size = areaWidth/(carBodyImage.Width / 16);
            double size2 = areaHeight/(carBodyImage.Height / 16);

            wheelSize = carBody.Width / 10;
            angle = 0;

            frontWheelPoint = new Point(carBody.Left + wheelSize + carBody.Width / 1.4, carBody.Bottom - wheelSize/1.5);
            RearWheelPoint = new Point(carBody.Left + wheelSize + carBody.Width / 15, carBody.Bottom - wheelSize/1.5);
        }

        public void Step(List<Point> carGuidePoints)
        {
            //angle++;

            EllipseGeometry frontWG = new EllipseGeometry(frontWheelPoint, wheelSize, wheelSize);
            EllipseGeometry rearWG = new EllipseGeometry(rearWheelPoint, wheelSize, wheelSize);

            Point pointAtFront = carGuidePoints.Last(x => frontWG.FillContains(x) || x.X == carGuidePoints.Aggregate((y, z) => Math.Abs(y.X - frontWheelPoint.X) < Math.Abs(z.X - frontWheelPoint.X) ? x : y).X);
            Point pointAtRear = carGuidePoints.Last(x => rearWG.FillContains(x) || x.X == carGuidePoints.Aggregate((y, z) => Math.Abs(y.X - rearWheelPoint.X) < Math.Abs(z.X - rearWheelPoint.X) ? x : y).X);

            frontWheelPoint = new Point(frontWheelPoint.X , pointAtFront.Y - wheelSize);
            rearWheelPoint = new Point(rearWheelPoint.X, pointAtRear.Y - wheelSize);
        }

        public Rect CarBody { get => carBody; private set => carBody = value; }

        public Point FrontWheelPoint { get => frontWheelPoint; private set => frontWheelPoint = value; }

        public Point RearWheelPoint { get => rearWheelPoint; private set => rearWheelPoint = value; }

        public double WheelSize { get => wheelSize; private set => wheelSize = value; }

        public BitmapImage CarBodyImage { get => carBodyImage; private set => carBodyImage = value; }

        public BitmapImage CarWheelImage { get => carWheelImage; private set => carWheelImage = value; }

        public double Angle { get => angle; private set => angle = value; }
    }
}
