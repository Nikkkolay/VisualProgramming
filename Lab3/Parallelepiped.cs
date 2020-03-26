namespace Lab3
{
    public class Parallelepiped : Body
    {
        public double FirstSideBase { get; }
        public double SecondSideBase { get; }
        public double Height { get; }

        public Parallelepiped(double firstSideBase, double secondSideBase, double height)
        {
            FirstSideBase = firstSideBase;
            SecondSideBase = secondSideBase;
            Height = height;
        }

        public override double CalcArea()
        {
            return 2 * (FirstSideBase * SecondSideBase + FirstSideBase * Height + SecondSideBase * Height);
        }

        public override double CalcVolume()
        {
            return FirstSideBase * SecondSideBase * Height;
        }
    }
}