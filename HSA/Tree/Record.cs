using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Tree
{
    class Record
    {

        public int NumberBedrooms { get; set; }

        public double NumberBathrooms { get; set; }

        public double NumberSqftLiving { get; set; }

        public double NumberSqftLot { get; set; }

        public double NumberFloor { get; set; }

        public bool ValidationWaterfront { get; set; }

        public int NumberView { get; set; }

        public int NumberCondition { get; set; }

        public int NumberGrade { get; set; }

        public double NumberSqftAbove { get; set; }

        public double NumberSqftBasement { get; set; }

        public int NumberYearRenovated { get; set; }

        public int NumberYearBuilt { get; set; }

        public int NumberZipCode { get; set; }

        public double NumberSqftLiving15 { get; set; }

        public double NumberSqftLot15 { get; set; }

        public string PriceRange { get; set; }

        public Record(int numberBedrooms, double numberBathrooms, double numberSqftLiving, double numberSqftLot, double numberFloor, bool validationWaterfront, int numberView, int numberCondition, int numberGrade, double numberSqftAbove, double numberSqftBasement,int numberYearBuilt, int numberYearRenovated, int numberZipCode, double numberSqftLiving15, double numberSqftLot15)
        {
            NumberBedrooms = numberBedrooms;
            NumberBathrooms = numberBathrooms;
            NumberSqftLiving = numberSqftLiving;
            NumberSqftLot = numberSqftLot;
            NumberFloor = numberFloor;
            ValidationWaterfront = validationWaterfront;
            NumberView = numberView;
            NumberCondition = numberCondition;
            NumberGrade = numberGrade;
            NumberSqftAbove = numberSqftAbove;
            NumberSqftBasement = numberSqftBasement;
            NumberYearBuilt = numberYearBuilt;
            NumberYearRenovated = numberYearRenovated;
            NumberZipCode = numberZipCode;
            NumberSqftLiving15 = numberSqftLiving15;
            NumberSqftLot15 = numberSqftLot15;
        }
    }
}
