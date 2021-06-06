using Microsoft.ML;
using System;
using System.IO;

namespace MachineLearningTest
{
    public class Program
    {
        private static string appPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private static string trainDataPath => Path.Combine(appPath, "..", "..", "Data", "kc_house_data.csv");
        private static string testDataPath => Path.Combine(appPath, "..", "..", "Data", "kc_house_data_test.csv");
        private static string modelPath => Path.Combine(appPath, "..", "..", "Models", "model.zip");

        private static MLContext mlContext;
        private static PredictionEngine<HouseSaleData, PriceRangePrediction> predEngine;
        private static ITransformer trainedModel;
        static IDataView trainingDataView;

        public static void Main(string[] args)
        {
            Console.WriteLine(appPath);
            Console.WriteLine(trainDataPath);
            Console.WriteLine(testDataPath);
            Console.WriteLine(modelPath);

            //ML environment creation

            mlContext = new MLContext(seed: 0);

            //Training data loading

            trainingDataView = mlContext.Data.LoadFromTextFile<HouseSaleData>(trainDataPath, hasHeader: true, separatorChar: ',');

            var preview = trainingDataView.Preview();
            //Data processing and pipeline definition
            int i = 9;
            var pipeline = ProcessData();

            //

            var trainingPipeline = BuildAndTrainModel(trainingDataView, pipeline);
            
            //Evaluate

            Evaluate(trainingDataView.Schema);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        public static IEstimator<ITransformer> ProcessData()
        {
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(inputColumnName: "PriceRange", outputColumnName: "Label")
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "SqftLiving", outputColumnName: "SqftLivingFeaturized")).Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "SqftLot", outputColumnName: "SqftLotFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "View", outputColumnName: "ViewFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Condition", outputColumnName: "ConditionFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Grade", outputColumnName: "GradeFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "SqftAbove", outputColumnName: "SqftAboveFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "SqftBasement", outputColumnName: "SqftBasementFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Zipcode", outputColumnName: "ZipcodeFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "SqftLiving15", outputColumnName: "SqftLiving15Featurized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "SqftLot15", outputColumnName: "SqftLot15Featurized"))
            .Append(mlContext.Transforms.Concatenate("Features","Bedrooms","Bathrooms","SqftLivingFeaturized", "SqftLotFeaturized","Floors","Waterfront", "ViewFeaturized", "ConditionFeaturized", "GradeFeaturized", "SqftAboveFeaturized", "SqftAboveFeaturized", "SqftBasementFeaturized","YrBuilt", "ZipcodeFeaturized", "SqftLiving15Featurized", "SqftLot15Featurized"))
            .AppendCacheCheckpoint(mlContext);

            return pipeline;
        }

        public static IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
        {
            var trainingPipeline = pipeline.Append(mlContext.MulticlassClassification.Trainers.LightGbm("Label", "Features"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            trainedModel = trainingPipeline.Fit(trainingDataView);

            predEngine = mlContext.Model.CreatePredictionEngine<HouseSaleData, PriceRangePrediction>(trainedModel);

            HouseSaleData houseSale = new HouseSaleData()
            {
                Bedrooms = 2,
                Bathrooms = 1,
                SqftLiving = "[692-892]",
                SqftLot = "[2021-3523]",
                Floors = 1,
                Waterfront = 0,
                View = "Very Poor",
                Condition = "Good",
                Grade = "Bad Quality And Design",
                SqftAbove = "[540-789]",
                SqftBasement = "NoBasement",
                YrBuilt = 1918,
                Zipcode = "98107",
                SqftLiving15 = "[1403-1653]",
                SqftLot15 = "[3851-4050]"
            };

            var prediction = predEngine.Predict(houseSale);

            Console.WriteLine($"========== Single Prediction just-trained-model - Result: {prediction.PriceRange} ==========");

            return trainingPipeline;
        }

        public static void Evaluate(DataViewSchema trainingDataViewSchema)
        {
            var testDataView = mlContext.Data.LoadFromTextFile<HouseSaleData>(testDataPath, hasHeader: true, separatorChar: ',');

            var testMetrics = mlContext.MulticlassClassification.Evaluate(trainedModel.Transform(testDataView));

            Console.WriteLine($"*************************************************************************************************************");
            Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"*       MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
            Console.WriteLine($"*       MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
            Console.WriteLine($"*       LogLoss:          {testMetrics.LogLoss:#.###}");
            Console.WriteLine($"*       LogLossReduction: {testMetrics.LogLossReduction:#.###}");
            Console.WriteLine($"*************************************************************************************************************");
        }
    }
}
