using Microsoft.ML.Data;

namespace HSA.Tree
{
    public class HouseSaleDataRegression
    {
        [LoadColumn(1)]
        public float Price { get; set; }
                
        [LoadColumn(2)]
        public float Bedrooms { get; set; }

        [LoadColumn(3)]
        public float Bathrooms { get; set; }

        [LoadColumn(4)]
        public float Sqft_living { get; set; }

        [LoadColumn(5)]
        public float Sqft_lot { get; set; }

        [LoadColumn(6)]
        public float Floors { get; set; }

        [LoadColumn(7)]
        public float Waterfronts { get; set; }

        [LoadColumn(8)]
        public float View { get; set; }

        [LoadColumn(9)]
        public float Condition { get; set; }

        [LoadColumn(10)]
        public float Grade { get; set; }

        [LoadColumn(11)]
        public float Sqft_above { get; set; }

        [LoadColumn(12)]
        public float Sqft_basement { get; set; }

        [LoadColumn(13)]
        public float Yr_built { get; set; }

        [LoadColumn(14)]
        public float Zipcode { get; set; }

        [LoadColumn(15)]
        public float Sqft_living15 { get; set; }

        [LoadColumn(16)]
        public float Sqft_lot15 { get; set; }
    }

    class PricePrediction 
    {
        [ColumnName("Score")]
        public float Price { get; set; }
    }

}