// <copyright file="CarObject.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Logic.Helpers
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using HighwayCoaster.Repository;

    /// <summary>
    /// CarObject class
    /// </summary>
    public class CarObject
    {
        private Rect carBody;
        private Point frontWheelPoint;
        private Point rearWheelPoint;
        private double wheelSize;
        private double angle;
        private int areaWidth;
        private int areaHeight;
        private int wheelRotation;
        private Car car;
        RectangleGeometry collisionBody;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarObject"/> class.
        /// Initalizes a CarObject
        /// </summary>
        /// <param name="car">The car that should be initalized</param>
        /// <param name="areaWidth">Width of the area</param>
        /// <param name="areaHeight">Height of the area</param>
        public CarObject(Car car, int areaWidth, int areaHeight)
        {
            this.wheelRotation = 0;

            this.car = car;

            this.areaWidth = areaWidth;
            this.areaHeight = areaWidth;

            this.carBody = new Rect(areaWidth / 6, areaHeight / 2.32, areaWidth / 9.4, areaHeight / 18.37);

            this.wheelSize = this.carBody.Width / 10;
            this.angle = 0;

            this.frontWheelPoint = new Point(Math.Round(this.carBody.Left + this.wheelSize + (this.carBody.Width / 1.4)), this.carBody.Bottom - (this.wheelSize / 1.5));
            this.rearWheelPoint = new Point(Math.Round(this.frontWheelPoint.X - (this.carBody.Width / 1.54)), this.carBody.Bottom - (this.wheelSize / 1.5));

            this.carBody.X = ((this.frontWheelPoint.X + this.rearWheelPoint.X) / 2) - (this.carBody.Width - (this.carBody.Width / 1.95));
            this.carBody.Y = ((this.frontWheelPoint.Y + this.rearWheelPoint.Y) / 2) - (this.carBody.Height - (this.wheelSize / 1.5));

            this.collisionBody = new RectangleGeometry(this.CarBody)
            {
                Transform = new RotateTransform(this.Angle, this.CarBody.Left + (this.CarBody.Width / 2), this.CarBody.Top + (this.CarBody.Height / 2))
            };
        }

        /// <summary>
        /// Gets the rectangle of the car body
        /// </summary>
        public Rect CarBody { get => this.carBody; private set => this.carBody = value; }

        /// <summary>
        /// Gets the center point of the front wheel
        /// </summary>
        public Point FrontWheelPoint { get => this.frontWheelPoint; private set => this.frontWheelPoint = value; }

        /// <summary>
        /// Gets the center of the rear wheel
        /// </summary>
        public Point RearWheelPoint
        {
            get => this.rearWheelPoint; private set { this.rearWheelPoint = value; }
        }

        /// <summary>
        /// Gets the size of the wheel
        /// </summary>
        public double WheelSize { get => this.wheelSize; private set => this.wheelSize = value; }

        /// <summary>
        /// Gets the image of the car
        /// </summary>
        public BitmapImage CarBodyImage { get => new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + this.car.ViewResourcesPath)); }

        /// <summary>
        /// Gets the image of the wheel
        /// </summary>
        public BitmapImage CarWheelImage { get => new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + this.car.WheelResource)); }

        /// <summary>
        /// Gets the actual angle of the car
        /// </summary>
        public double Angle { get => this.angle; private set => this.angle = value; }

        /// <summary>
        /// Gets the rotation of the wheel
        /// </summary>
        public int WheelRotation { get => this.wheelRotation; private set => this.wheelRotation = value; }

        /// <summary>
        /// Gets the collision body of the car.
        /// </summary>
        public RectangleGeometry CollisionBody { get => this.collisionBody; }

        /// <summary>
        /// Makes a step with the car
        /// </summary>
        /// <param name="line">The line where the car should be placed on</param>
        /// <param name="ySpeed">The speed of the y axis change</param>
        public void Step(Geometry line, double ySpeed)
        {
            Geometry frontWheelIntersection = Geometry.Combine(line.GetWidenedPathGeometry(new Pen(null, Math.Round((double)(this.areaWidth / 266.6666666666667)))), new EllipseGeometry(this.frontWheelPoint, this.wheelSize, this.wheelSize), GeometryCombineMode.Intersect, null);
            Geometry rearWheelIntersection = Geometry.Combine(line.GetWidenedPathGeometry(new Pen(null, Math.Round((double)(this.areaWidth / 266.6666666666667)))), new EllipseGeometry(this.rearWheelPoint, this.wheelSize, this.wheelSize), GeometryCombineMode.Intersect, null);

            if (frontWheelIntersection.GetArea() == 0)
            {
                this.frontWheelPoint.Y += ySpeed;
            }
            else if (frontWheelIntersection.GetArea() > 0 && frontWheelIntersection.GetArea() < this.WheelSize * ySpeed)
            {
                // do nothing
            }
            else
            {
                this.frontWheelPoint.Y -= ySpeed;
            }

            this.rearWheelPoint.X = (this.frontWheelPoint.X - (this.carBody.Width / 1.54)) + Math.Abs((this.rearWheelPoint.Y - this.frontWheelPoint.Y) * this.CarBody.Height / this.CarBody.Width);

            if (rearWheelIntersection.GetArea() == 0)
            {
                this.rearWheelPoint.Y += ySpeed;
            }
            else if (rearWheelIntersection.GetArea() > 0 && rearWheelIntersection.GetArea() < this.WheelSize * ySpeed)
            {
                // do nothing
            }
            else
            {
                this.rearWheelPoint.Y -= ySpeed;
            }

            var radian = Math.Atan2(this.rearWheelPoint.Y - this.frontWheelPoint.Y, this.frontWheelPoint.X - this.rearWheelPoint.X);

            this.angle = 360 - (((radian * (180 / Math.PI)) + 360) % 360);

            double xCorrection = 0;
            double yCorrection = 0;

            if (this.angle > 0 && this.angle < 180)
            {
                double tempAngle = this.angle;
                xCorrection += this.carBody.Width / 2 * (tempAngle / 360);
                yCorrection -= this.carBody.Height / 2.5 * (tempAngle / 360);
            }
            else if (this.angle >= 180 && this.angle < 360)
            {
                double tempAngle = 360 - this.angle;
                xCorrection -= this.carBody.Width / 2 * (tempAngle / 360);
                yCorrection += this.carBody.Height / 2.5 * (tempAngle / 360);
            }

            this.carBody.X = ((this.frontWheelPoint.X + this.rearWheelPoint.X) / 2) - (this.carBody.Width - (this.carBody.Width / 1.95)) + xCorrection;
            this.carBody.Y = ((this.frontWheelPoint.Y + this.rearWheelPoint.Y) / 2) - (this.carBody.Height - (this.wheelSize / 1.5)) + yCorrection;

            if (this.wheelRotation >= 360)
            {
                this.wheelRotation = 0;
            }
            else
            {
                this.wheelRotation += this.areaWidth / 160;
            }

            this.collisionBody = new RectangleGeometry(this.CarBody)
            {
                Transform = new RotateTransform(this.Angle, this.CarBody.Left + (this.CarBody.Width / 2), this.CarBody.Top + (this.CarBody.Height / 2))
            };
        }
    }
}
