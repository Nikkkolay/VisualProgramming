using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab5
{
    public class ZControlPanel : Panel
    {
        public event Action ZDrawn;

        private bool _isDraw;
        private double _eps = 15;
        private double _eps2 = 40;
        private List<Point> _poits;

        public ZControlPanel()
        {
            Background = new SolidColorBrush(Colors.Red);
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            _poits = new List<Point>();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            _isDraw = true;
        }

        protected override void OnMouseMove(MouseEventArgs arg)
        {
            base.OnMouseMove(arg);

            if (!_isDraw) return;

            _poits.Add(arg.GetPosition(this));
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            _isDraw = false;

            if(CheckZ())
            {
                ZDrawn?.Invoke();
            }

            _poits.Clear();
        }

        private bool CheckZ()
        {
            var ControlP1 = _poits[0];
            var ControlP7 = _poits[_poits.Count - 1];
            var index = 1;

            while (Math.Abs(_poits[index].Y - _poits[0].Y) <= _eps)
            {
                if (index == _poits.Count - 1)
                    return false;
                index++;
            }

            var n1 = index;

            var ControlP3 = _poits[index - 1];
            var ControlP2 = new Point();
            var p2X = (ControlP1.X + ControlP3.X) / 2;

            for (int i = 0; i < index; i++)
            {
                if(_poits[i].X >= p2X)
                {
                    ControlP2 = _poits[i];
                    break;
                }
            }


            while (Math.Abs((_poits[index].Y - _poits[_poits.Count - 1].Y)) > _eps)
            {
                if (index == _poits.Count - 1)
                    return false;
                index++;
            }

            var ControlP5 = _poits[index - 1];

            var p4X = p2X;
            var p4Y = (ControlP1.Y + ControlP7.Y) / 2;

            var ControlP4 = new Point();

            for (int i = n1; i < index; i++)
            {
                if (_poits[i].X <= p4X && _poits[i].Y >= p4Y)
                {
                    ControlP4 = _poits[i];
                    break;
                }
            }

            var ControlP6 = new Point();
            var p6X = (ControlP5.X + ControlP7.X) / 2;

            for (int i = index; i < _poits.Count; i++)
            {
                if (_poits[i].X >= p6X)
                {
                    ControlP6 = _poits[i];
                    break;
                }
            }

            return CheckControlPoints(
                ControlP1,
                ControlP2,
                ControlP3,
                ControlP4,
                ControlP5,
                ControlP6,
                ControlP7);
        }

        private bool CheckControlPoints(Point p1, Point p2, Point p3, Point p4, Point p5, Point p6, Point p7)
        {
            if (Math.Abs(p1.Y - p2.Y) > _eps2 || Math.Abs(p1.Y - p3.Y) > _eps2)
                return false;

            if (Math.Abs(p5.Y - p6.Y) > _eps2 || Math.Abs(p5.Y - p7.Y) > _eps2)
                return false;

            if (Math.Abs(p1.X - p5.X) > _eps2)
                return false;

            if (Math.Abs(p2.X - p4.X) > _eps2 || Math.Abs(p2.X - p6.X) > _eps2)
                return false;

            if (Math.Abs(p3.X - p7.X) > _eps2)
                return false;

            return true;
        }

        private double Distance(Point a, Point b) => Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
    }
}
