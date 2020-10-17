// <copyright file="GameAreaLogic.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using HighwayCoaster.Logic.Helpers;
    using HighwayCoaster.Repository;

    /// <summary>
    /// GameAreaLogic class
    /// </summary>
    public class GameAreaLogic
    {
        private double areaHeight;
        private double areaWidth;
        private double lineThickness;
        private bool gameOver;
        private int score;
        private PathGeometry line;
        private Direction previousDirection;
        private Random r;
        private Player player;
        private IGameLogic gameLogic;

        private List<Point> points;
        private List<Rect> obstacles;
        private CarObject carObj;

        private double speed;
        private double ySpeed;

        private int stepCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameAreaLogic"/> class.
        /// </summary>
        /// <param name="areaHeight">The height of the window</param>
        /// <param name="areaWidth">The width of the window</param>
        /// <param name="gameLogic">The actual GameLogic instance</param>
        public GameAreaLogic(int areaHeight, int areaWidth, IGameLogic gameLogic)
        {
            this.r = new Random();

            this.previousDirection = Direction.None;
            this.areaHeight = areaHeight;
            this.areaWidth = areaWidth;
            this.gameOver = false;
            this.score = 0;
            this.stepCount = 0;
            this.speed = areaWidth / 160;
            this.ySpeed = areaHeight / 112.5;
            this.player = gameLogic.LoggedInPlayer;
            this.gameLogic = gameLogic;
            this.lineThickness = Math.Round((double)(areaWidth / 266.6666666666667));

            this.line = new PathGeometry();
            this.points = new List<Point>();
            this.points.Add(new Point(0, areaHeight / 2));
            this.points.Add(new Point(areaWidth / 3, areaHeight / 2));

            this.obstacles = new List<Rect>();
            this.obstacles.Add(new Rect(areaWidth + (areaWidth / 14), this.r.Next(areaWidth / 14, areaHeight - 45 - (areaWidth / 14)), areaWidth / 7, areaWidth / 7));

            this.carObj = new CarObject(this.player.Car, areaWidth, areaHeight);
        }

        /// <summary>
        /// Gets a value indicating whether gets the game state
        /// </summary>
        public bool GameOver { get => this.gameOver; }

        /// <summary>
        /// Gets the score
        /// </summary>
        public int Score { get => this.score; }

        /// <summary>
        /// Gets the line that should be drawn
        /// </summary>
        public PathGeometry Line { get => this.line; }

        /// <summary>
        /// Gets the obstacles that should be drawn
        /// </summary>
        public List<Rect> Obstacles { get => this.obstacles;  }

        /// <summary>
        /// Gets the CarObj that should be drawn
        /// </summary>
        public CarObject CarObj { get => this.carObj; }

        /// <summary>
        /// Gets the thickness of the line
        /// </summary>
        public double LineThickness { get => this.lineThickness; }

        /// <summary>
        /// The step that should be called at every tick
        /// </summary>
        /// <param name="direction">Actual direction of the line</param>
        public void Step(Direction direction)
        {
            this.StepLine(direction);
            this.StepCar();
            this.StepObstacle();
            this.score++;
        }

        /// <summary>
        /// Step of the car
        /// </summary>
        public void StepCar()
        {
            this.carObj.Step(this.line, this.ySpeed);
        }

        /// <summary>
        /// Step of the obstacles
        /// </summary>
        public void StepObstacle()
        {
            for (int i = 0; i < this.obstacles.Count; i++)
            {
                this.obstacles[i] = new Rect(this.obstacles[i].X - this.speed, this.obstacles[i].Y, this.obstacles[i].Width, this.obstacles[i].Height);

                if (this.obstacles[i].X < 0 - (this.areaWidth / 8))
                {
                    this.obstacles.RemoveAt(i);
                }

                Geometry collisionGeometry = Geometry.Combine(this.carObj.CollisionBody, new RectangleGeometry(this.obstacles[i]), GeometryCombineMode.Intersect, null);

                if (collisionGeometry.GetArea() != 0)
                {
                    this.DoGameOver();
                }
            }

            if (this.obstacles.Last().X < this.areaWidth - (this.areaWidth / 4))
            {
                this.obstacles.Add(
                    new Rect(
                        this.r.Next(
                            (int)Math.Round(this.areaWidth + (this.areaWidth / 14)),
                        (int)Math.Round(this.areaWidth + (this.areaWidth / 14) + (this.areaWidth / 3))),
                        this.r.Next((int)Math.Round(this.areaWidth / 14), (int)Math.Round(this.areaHeight - 45 - (this.areaWidth / 14))),
                        this.areaWidth / 7,
                        this.areaWidth / 7));
            }
        }

        /// <summary>
        /// Step of the line
        /// </summary>
        /// <param name="direction">Actual direction of the line</param>
        public void StepLine(Direction direction)
        {
            this.stepCount++;

            if (this.previousDirection != direction || this.stepCount == this.speed * 7)
            {
                this.stepCount = 0;
            }

            for (int i = 0; i < this.points.Count - 1; i++)
            {
                if (this.points[i].X < 0 && this.points.Count(x => x.X < 0) > 2)
                {
                    this.points.RemoveAt(i);
                }
                else
                {
                    this.points[i] = new Point(this.points[i].X - this.speed, this.points[i].Y);
                }
            }

            switch (direction)
            {
                case Direction.Up:
                    if (this.points.Last().Y - this.carObj.CarBody.Height - this.carObj.WheelSize - (this.areaHeight / 20) > 0)
                    {

                        this.points.Add(new Point(this.points.Last().X, this.points.Last().Y - this.ySpeed));
                    }
                    else
                    {
                        this.points.Add(new Point(this.points.Last().X, this.points.Last().Y));
                    }

                    break;
                case Direction.Down:
                    if (this.points.Last().Y + 5 < this.areaHeight - 45)
                    {
                        this.points.Add(new Point(this.points.Last().X, this.points.Last().Y + this.ySpeed));
                    }
                    else
                    {
                        this.points.Add(new Point(this.points.Last().X, this.points.Last().Y));
                    }

                    break;
                case Direction.None:
                    this.points.Add(new Point(this.points.Last().X, this.points.Last().Y));
                    break;
                default:
                    break;
            }

            this.line = this.MakeCurve(this.points.ToArray());
            this.previousDirection = direction;
        }

        private PathGeometry MakeCurve(Point[] points)
        {
            if (points.Length < 2)
            {
                return null;
            }

            PathSegmentCollection pathSegments = new PathSegmentCollection();
            for (int i = 1; i < points.Length; i++)
            {
                pathSegments.Add(new LineSegment(points[i], true));
            }

            PathGeometry path = new PathGeometry()
            {
                Figures = new PathFigureCollection()
                {
                    new PathFigure()
                    {
                        StartPoint = points[0],
                        Segments = pathSegments
                    }
                }
            };

            return path;
        }

        private void DoGameOver()
        {
            this.gameOver = true;

            if (this.player.Highscore == null || this.player.Highscore < this.score)
            {
                this.gameLogic.SaveHighscore(this.player.PlayerId, this.score);
            }
        }
    }
}
