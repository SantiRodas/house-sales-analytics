using Microsoft.ML.Data;

namespace HSA.Tree
{
    public class SaleData
    {

        // ----------------------------------------------------------------------------------------------------

        // Information of the price

        [LoadColumn(1)]

        public float Price { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the bedrooms

        [LoadColumn(2)]

        public float Bedrooms { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the bathrooms

        [LoadColumn(3)]

        public float Bathrooms { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the sqft living

        [LoadColumn(4)]

        public float Sqft_living { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the sqft lot

        [LoadColumn(5)]

        public float Sqft_lot { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the floors

        [LoadColumn(6)]

        public float Floors { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the waterfronts

        [LoadColumn(7)]

        public float Waterfronts { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the view

        [LoadColumn(8)]

        public float View { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the condition

        [LoadColumn(9)]

        public float Condition { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the grade

        [LoadColumn(10)]

        public float Grade { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the sqft above

        [LoadColumn(11)]

        public float Sqft_above { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the sqft basement

        [LoadColumn(12)]

        public float Sqft_basement { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the year of built

        [LoadColumn(13)]

        public float Yr_built { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the zip code

        [LoadColumn(14)]

        public float Zipcode { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the sqft living 15

        [LoadColumn(15)]

        public float Sqft_living15 { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Information of the sqft lot 15

        [LoadColumn(16)]

        public float Sqft_lot15 { get; set; }

        // ----------------------------------------------------------------------------------------------------

    }
}