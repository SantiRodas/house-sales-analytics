using Microsoft.ML.Data;

namespace HSA.Tree
{
    class HouseSaleDataClassification
    {
        [LoadColumn(0)]
        public float Bedrooms { get; set; }

        [LoadColumn(1)]
        public float Bathrooms { get; set; }

        [LoadColumn(2)]
        public string SqftLiving { get; set; }

        [LoadColumn(3)]
        public string SqftLot { get; set; }

        [LoadColumn(4)]
        public float Floors { get; set; }

        [LoadColumn(5)]
        public float Waterfront { get; set; }

        [LoadColumn(6)]
        public string View { get; set; }

        [LoadColumn(7)]
        public string Condition { get; set; }

        [LoadColumn(8)]
        public string Grade { get; set; }

        [LoadColumn(9)]
        public string SqftAbove { get; set; }

        [LoadColumn(10)]
        public string SqftBasement { get; set; }

        [LoadColumn(11)]
        public float YrBuilt { get; set; }

        [LoadColumn(12)]
        public string Zipcode { get; set; }

        [LoadColumn(13)]
        public string SqftLiving15 { get; set; }

        [LoadColumn(14)]
        public string SqftLot15 { get; set; }

        [LoadColumn(15)]
        public string PriceRange { get; set; }
    }

    class PriceRangePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PriceRange { get; set; }
    }
}
