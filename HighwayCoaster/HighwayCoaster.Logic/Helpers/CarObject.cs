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
        int wheelRotation;

        public CarObject(Car car, int areaWidth, int areaHeight)
        {
            wheelRotation = 0;

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
            rearWheelPoint = new Point(Math.Round(frontWheelPoint.X - carBody.Width / 1.54), carBody.Bottom - wheelSize/1.5);
        }

        public void Step(PathGeometry line, double ySpeed)
        {
            Geometry frontWheelIntersection = Geometry.Combine(line.GetWidenedPathGeometry(new Pen(null, Math.Round((double)(areaWidth / 266.6666666666667)))), new EllipseGeometry(frontWheelPoint, wheelSize, wheelSize), GeometryCombineMode.Intersect, null);
            Geometry rearWheelIntersection = Geometry.Combine(line.GetWidenedPathGeometry(new Pen(null, Math.Round((double)(areaWidth / 266.6666666666667)))), new EllipseGeometry(rearWheelPoint, wheelSize, wheelSize), GeometryCombineMode.Intersect, null);

            if (frontWheelIntersection.GetArea() == 0)
            {
                frontWheelPoint.Y += ySpeed;
            }
            else if (frontWheelIntersection.GetArea() > 0 && frontWheelIntersection.GetArea() < WheelSize*ySpeed)
            {
                // do nothing
            }
            else
            {
                frontWheelPoint.Y -= ySpeed;
            }

            rearWheelPoint.X = (frontWheelPoint.X - carBody.Width / 1.54) + Math.Abs((rearWheelPoint.Y - frontWheelPoint.Y)*CarBody.Height/CarBody.Width);


            if (rearWheelIntersection.GetArea() == 0)
            {
                rearWheelPoint.Y += ySpeed;
            }
            else if (rearWheelIntersection.GetArea() > 0 && rearWheelIntersection.GetArea() < WheelSize*ySpeed)
            {
                // do nothing
            }
            else
            {
                rearWheelPoint.Y -= ySpeed;
            }

            var radian = Math.Atan2((rearWheelPoint.Y - frontWheelPoint.Y), (frontWheelPoint.X - rearWheelPoint.X));

            this.angle = 360 - (((radian * (180 / Math.PI)) + 360) % 360);

            carBody.X = ((frontWheelPoint.X + rearWheelPoint.X) / 2) - (carBody.Width - carBody.Width / 1.95);
            carBody.Y = ((frontWheelPoint.Y + rearWheelPoint.Y) / 2) - (carBody.Height - wheelSize / 1.5);

            if (wheelRotation == 360)
            {
                wheelRotation = 0;
            }
            else
            {
                wheelRotation += 5;
            }
        }

        public Rect CarBody { get => carBody; private set => carBody = value; }

        public Point FrontWheelPoint { get => frontWheelPoint; private set => frontWheelPoint = value; }

        public Point RearWheelPoint { get => rearWheelPoint; private set { rearWheelPoint = value; } }

        public double WheelSize { get => wheelSize; private set => wheelSize = value; }

        public BitmapImage CarBodyImage { get => carBodyImage; private set => carBodyImage = value; }

        public BitmapImage CarWheelImage { get => carWheelImage; private set => carWheelImage = value; }

        public double Angle { get => angle; private set => angle = value; }

        public int WheelRotation { get => wheelRotation; set => wheelRotation = value; }
    }
}
