using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab6
{
    public partial class PieChart : UserControl
    {
        private List<PieChartSegment> _pieChartSegments;
        private List<Path> _segments;
        private double _indentation;

        public PieChart(List<PieChartSegment> pieChartSegments, double indentation)
        {
            
            InitializeComponent();

            _pieChartSegments = pieChartSegments;
            _indentation = indentation;
            _segments = new List<Path>();

            foreach (var pieChartSegment in _pieChartSegments)
            {
                PlaseForLegends.Children.Add(new Legend(pieChartSegment.Color, pieChartSegment.Description));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            foreach(var segment in _segments)
            {
                Grid.Children.Remove(segment);
            }

            _segments = GeneratePieChartSegments(Grid.RowDefinitions[0].ActualHeight, Grid.ColumnDefinitions[0].ActualWidth, _pieChartSegments);

            foreach (var segment in _segments)
            {
                Grid.Children.Add(segment);
            }
        }

        private List<Path> GeneratePieChartSegments(double height, double width, List<PieChartSegment> pieChartSegments)
        {
            if(pieChartSegments == null || pieChartSegments.Count == 0)
            {
                throw new ArgumentException();
            }

            var segments = new List<Path>();
            var radius = Math.Min(width, height) / 2f - _indentation;
            var center = new Point(width / 2, height / 2);
            var radians = 0d;

            var startPoint = new Point(center.X, center.Y - radius);
            var index = 0;
            do
            {
                var (segment, newStartPoint) = GetCircleSegment(center, startPoint, PercentToRadian(pieChartSegments[index].Percent), radians, radius, pieChartSegments[index].Color);
                segments.Add(segment);
                startPoint = newStartPoint;
                radians += PercentToRadian(pieChartSegments[index].Percent);
                index++;
            } while (index < pieChartSegments.Count);

            return segments;
        }

        private (Path, Point) GetCircleSegment(Point center, Point startPointOnCircle, double radian, double radiansBeforeSegment, double radius, Color color)
        {
            PathGeometry pathGeom = new PathGeometry();

            Path path = new Path
            {
                Data = pathGeom,
                Fill = new SolidColorBrush(color)
            };

            PathFigure circleSegment = new PathFigure
            {
                IsFilled = true,
                IsClosed = true,
                StartPoint = center
            };

            LineSegment startLine = new LineSegment
            {
                Point = startPointOnCircle
            };

            ArcSegment arg = new ArcSegment
            {
                IsLargeArc = radian > Math.PI,
                SweepDirection = SweepDirection.Clockwise,
                Point = new Point(
                    center.X + radius * Math.Sin(radiansBeforeSegment + radian),
                    center.Y - radius * Math.Cos(radiansBeforeSegment + radian)),
                Size = new Size(radius, radius)
            };


            circleSegment.Segments.Add(startLine);
            circleSegment.Segments.Add(arg);
            pathGeom.Figures.Add(circleSegment);

            return (path, arg.Point);
        }

        private double PercentToRadian(int Percent) => (2 * Math.PI) * (Percent / 100f);
    }
}
