using HighwayCoaster.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HighwayCoaster.Logic
{
    public class GameAreaLogic
    {
        private int areaHeight;
        private int areaWidth;
        private bool gameOver;
        private int score;
        private PathGeometry line;
        private PathFigure pathFigure;
        Direction previousDirection;

        List<BezierSegment> segments;

        public GameAreaLogic(int areaHeight, int areaWidth)
        {
            previousDirection = Direction.None;
            this.areaHeight = areaHeight;
            this.areaWidth = areaWidth;
            this.gameOver = false;
            this.score = 0;

            this.line = new PathGeometry();

            this.pathFigure = new PathFigure();
            this.pathFigure.StartPoint = new Point(0, areaHeight / 2);

            segments = new List<BezierSegment>();
            segments.Add(new BezierSegment(new Point(0, areaHeight / 2), new Point(areaWidth / 6, areaHeight / 2), new Point(areaWidth / 3, areaHeight / 2), true));

            pathFigure.Segments = new PathSegmentCollection(segments);

            this.line.Figures.Add(this.pathFigure);
        }

        public bool GameOver { get => this.gameOver; }

        public int Score { get => this.score; }

        public PathGeometry Line { get => line; }

        public void Step(Direction direction)
        {
            BezierSegment lastSegment = segments.Last();

            for (int i = 0; i < segments.Count - 1; i++)
            {
                segments[i].Point1 = new Point(segments[i].Point1.X - 5, segments[i].Point1.Y);
                segments[i].Point2 = new Point(segments[i].Point2.X - 5, segments[i].Point2.Y);
                segments[i].Point3 = new Point(segments[i].Point3.X - 5, segments[i].Point3.Y);
            }

            if (previousDirection != direction)
            {
                BezierSegment newSegment = new BezierSegment(lastSegment.Point3, lastSegment.Point3, lastSegment.Point3, true);
                segments.Add(newSegment);
                pathFigure.Segments = new PathSegmentCollection(segments);
                lastSegment = segments.Last();
            }

            switch (direction)
            {
                case Direction.Up:
                    lastSegment.Point1 = new Point(lastSegment.Point1.X - 5, lastSegment.Point1.Y);
                    lastSegment.Point2 = new Point(lastSegment.Point2.X - 2.5, lastSegment.Point2.Y );
                    lastSegment.Point3 = new Point(lastSegment.Point3.X, lastSegment.Point3.Y - 5);
                    break;
                case Direction.Down:
                    lastSegment.Point1 = new Point(lastSegment.Point1.X - 5, lastSegment.Point1.Y);
                    lastSegment.Point2 = new Point(lastSegment.Point2.X - 2.5, lastSegment.Point2.Y);
                    lastSegment.Point3 = new Point(lastSegment.Point3.X, lastSegment.Point3.Y + 5);
                    break;
                case Direction.None:
                    lastSegment.Point1 = new Point(lastSegment.Point1.X - 5, lastSegment.Point1.Y);
                    lastSegment.Point2 = new Point(lastSegment.Point2.X - 2.5, lastSegment.Point2.Y);
                    lastSegment.Point3 = new Point(lastSegment.Point3.X, lastSegment.Point3.Y);
                    break;
                default:
                    break;
            }

            previousDirection = direction;
        }
    }
}
