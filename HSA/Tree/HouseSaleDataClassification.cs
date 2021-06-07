using Microsoft.ML.Data;

namespace HSA.Tree
{
    public class HouseSaleDataClassification
    {
        [LoadColumn(2)]
        public float Bedrooms { get; set; }

        [LoadColumn(3)]
        public float Bathrooms { get; set; }

        [LoadColumn(4)]
        public string SqftLiving { get; set; }

        [LoadColumn(5)]
        public string SqftLot { get; set; }

        [LoadColumn(6)]
        public float Floors { get; set; }

        [LoadColumn(7)]
        public float Waterfront { get; set; }

        [LoadColumn(8)]
        public string View { get; set; }

        [LoadColumn(9)]
        public string Condition { get; set; }

        [LoadColumn(10)]
        public string Grade { get; set; }

        [LoadColumn(11)]
        public string SqftAbove { get; set; }

        [LoadColumn(12)]
        public string SqftBasement { get; set; }

        [LoadColumn(13)]
        public float YrBuilt { get; set; }

        [LoadColumn(14)]
        public string Zipcode { get; set; }

        [LoadColumn(15)]
        public string SqftLiving15 { get; set; }

        [LoadColumn(16)]
        public string SqftLot15 { get; set; }

        [LoadColumn(17)]
        public string PriceRange { get; set; }
    }

    public class PriceRangePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PriceRange { get; set; }
    }
}
