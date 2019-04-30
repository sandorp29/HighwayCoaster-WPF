using HighwayCoaster.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HighwayCoaster.Logic
{
    public class GameAreaLogic
    {
        private int areaHeight;
        private int areaWidth;
        private bool gameOver;
        private int score;
        private PathGeometry line;
        Direction previousDirection;

        List<Point> points;

        int stepCount;

        public GameAreaLogic(int areaHeight, int areaWidth)
        {
            previousDirection = Direction.None;
            this.areaHeight = areaHeight;
            this.areaWidth = areaWidth;
            this.gameOver = false;
            this.score = 0;
            stepCount = 0;

            this.line = new PathGeometry();
            points = new List<Point>();
            points.Add(new Point(0, areaHeight / 2));
            points.Add(new Point(areaWidth / 3, areaHeight / 2));
        }

        public bool GameOver { get => this.gameOver; }

        public int Score { get => this.score; }

        public PathGeometry Line { get => line; }

        public void Step(Direction direction)
        {
            stepCount++;

            if (previousDirection != direction || stepCount == 50)
            {
                points.Add(new Point(points.Last().X, points.Last().Y));
                stepCount = 0;
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points[i].X < 0 && points.Count(x => x.X < 0) > 2)
                {
                    points.RemoveAt(i);
                }
                else
                {
                    points[i] = new Point(points[i].X - 5, points[i].Y);
                }
            }

            switch (direction)
            {
                case Direction.Up:
                    if (points.Last().Y - 5 > 0)
                    {
                        points[points.Count - 1] = new Point(points.Last().X, points.Last().Y - 5);
                    }

                    break;
                case Direction.Down:
                    if (points.Last().Y + 5 < areaHeight - 45)
                    {
                        points[points.Count - 1] = new Point(points.Last().X, points.Last().Y + 5);
                    }

                    break;
                default:
                    break;
            }

            line = MakeCurve(points.ToArray(), 0.2);
            previousDirection = direction;
        }



        private Point[] MakeCurvePoints(Point[] points, double tension)
        {
            if (points.Length < 2) return null;
            double control_scale = tension / 0.5 * 0.175;

            // Make a list containing the points and
            // appropriate control points.
            List<Point> result_points = new List<Point>();
            result_points.Add(points[0]);

            for (int i = 0; i < points.Length - 1; i++)
    {
                // Get the point and its neighbors.
                Point pt_before = points[Math.Max(i - 1, 0)];
                Point pt = points[i];
                Point pt_after = points[i + 1];
                Point pt_after2 = points[Math.Min(i + 2, points.Length - 1)];

                double dx1 = pt_after.X - pt_before.X;
                double dy1 = pt_after.Y - pt_before.Y;

                Point p1 = points[i];
                Point p4 = pt_after;

                double dx = pt_after.X - pt_before.X;
                double dy = pt_after.Y - pt_before.Y;
                Point p2 = new Point(
                    pt.X + control_scale * dx,
                    pt.Y + control_scale * dy);

                dx = pt_after2.X - pt.X;
                dy = pt_after2.Y - pt.Y;
                Point p3 = new Point(
                    pt_after.X - control_scale * dx,
                    pt_after.Y - control_scale * dy);

                // Save points p2, p3, and p4.
                result_points.Add(p2);
                result_points.Add(p3);
                result_points.Add(p4);
            }

            // Return the points.
            return result_points.ToArray();
        }

        // Make a Path holding a series of Bezier curves.
        // The points parameter includes the points to visit
        // and the control points.
        private PathGeometry MakeBezierPath(Point[] points)
        {
            // Add a PathGeometry.
            PathGeometry path_geometry = new PathGeometry();

            // Create a PathFigure.
            PathFigure path_figure = new PathFigure();
            path_geometry.Figures.Add(path_figure);

            // Start at the first point.
            path_figure.StartPoint = points[0];

            // Create a PathSegmentCollection.
            PathSegmentCollection path_segment_collection =
                new PathSegmentCollection();
            path_figure.Segments = path_segment_collection;

            // Add the rest of the points to a PointCollection.
            PointCollection point_collection =
                new PointCollection(points.Length - 1);
            for (int i = 1; i < points.Length; i++)
                point_collection.Add(points[i]);

            // Make a PolyBezierSegment from the points.
            PolyBezierSegment bezier_segment = new PolyBezierSegment();
            bezier_segment.Points = point_collection;

            // Add the PolyBezierSegment to othe segment collection.
            path_segment_collection.Add(bezier_segment);

            return path_geometry;
        }

        // Make a Bezier curve connecting these points.
        private PathGeometry MakeCurve(Point[] points, double tension)
        {
            if (points.Length < 2) return null;
            Point[] result_points = MakeCurvePoints(points, tension);

            // Use the points to create the path.
            return MakeBezierPath(result_points.ToArray());
        }
    }
}
