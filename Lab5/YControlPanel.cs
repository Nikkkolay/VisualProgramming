using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab5
{
    public class YControlPanel : Panel
    {
        public event Action<double> YPositionChanged;

        private double _lastYPosition;

        public YControlPanel()
        {
            Background = new SolidColorBrush(Colors.Red);
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            _lastYPosition = e.GetPosition(this).Y;
        }

        protected override void OnMouseMove(MouseEventArgs arg)
        {
            base.OnMouseMove(arg);
            Point point = arg.GetPosition(this);

            if (Math.Abs(point.Y - _lastYPosition) < 1e-2) return;

            _lastYPosition = point.Y;

            YPositionChanged?.Invoke(point.Y);
        }
    }
}
