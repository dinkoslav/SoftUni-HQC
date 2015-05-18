namespace VehicleParkSystem.Model
{
    using System;

    public class VehicleParkSectors
    {
        private int sectors;
        private int placesPerSector;

        public VehicleParkSectors(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new DivideByZeroException("The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new DivideByZeroException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}
