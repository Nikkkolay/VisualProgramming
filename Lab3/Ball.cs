using System;

namespace Lab3
{
    public class Ball : Body
    {
        public double Radius { get; }

        public Ball(double radius)
        {
            Radius = radius;
        }

        public override double CalcArea()
        {
            return 4 * Math.PI * Radius * Radius;
        }

        public override double CalcVolume()
        {
            return 4.0 / 3 * Math.PI * Radius * Radius * Radius;
        }
    }
}