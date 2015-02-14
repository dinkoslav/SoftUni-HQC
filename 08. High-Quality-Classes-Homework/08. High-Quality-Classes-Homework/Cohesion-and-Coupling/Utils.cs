using System;

namespace CohesionAndCoupling
{
    public class Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public Figure(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = DistanceUtils.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = DistanceUtils.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = DistanceUtils.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = DistanceUtils.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
