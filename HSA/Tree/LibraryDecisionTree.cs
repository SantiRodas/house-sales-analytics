using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace HSA.Tree
{
    class LibraryDecisionTree
    {
        private static string AppPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private static string ClassificationTrainDataPath => Path.Combine(AppPath, "..", "..", "..", "data", "kc_house_data_classification.csv");
        private static string ClassificationTestDataPath => Path.Combine(AppPath, "..", "..", "..", "data", "kc_house_data_classification_test.csv");
        private static string RegressionTrainDataPath => Path.Combine(AppPath, "..", "..", "..", "data", "kc_house_data_regression.csv");
        private static string RegressionTestDataPath => Path.Combine(AppPath, "..", "..", "..", "data", "kc_house_data_regression_test.csv");

        private MLContext mlContext;

        private PredictionEngine<HouseSaleDataClassification, PriceRangePrediction> classificationPredEngine;
        private ITransformer classificationTrainedModel;
        private IDataView classificationTrainingDataView;
        private IDataView classificationTestDataView;
        public MulticlassClassificationMetrics ClassificationTestMetrics { get; private set; }
        public MulticlassClassificationMetrics ClassificationTrainingMetrics { get; private set; }

        private PredictionEngine<HouseSaleDataRegression, PricePrediction> regressionPredEngine;
        private ITransformer regressionTrainedModel;
        private IDataView regressionTrainingDataView;
        private IDataView regressionTestDataView;
        public RegressionMetrics RegresionTestMetrics { get; private set; }
        public RegressionMetrics RegresionTrainingMetrics { get; private set; }

        public void BuildMultiClassificationTree()
        {
            Console.WriteLine(AppPath);
            Console.WriteLine(ClassificationTrainDataPath);
            Console.WriteLine(ClassificationTestDataPath);

            //ML environment creation

            mlContext = new MLContext(seed: 0);

            //Training and testing data loading

            classificationTrainingDataView = mlContext.Data.LoadFromTextFile<HouseSaleDataClassification>(ClassificationTrainDataPath, hasHeader: true, separatorChar: ',');

            classificationTestDataView = mlContext.Data.LoadFromTextFile<HouseSaleDataClassification>(ClassificationTestDataPath, hasHeader: true, separatorChar: ',');

            //Data processing and pipeline definition, pipeline is like a set of operations that are made to prepare data,
            //and define a trainer (method in which the ds tree is generated)
            
            var pipeline = ProcessClassificationData();

            //Construction of model (decision tree)

            BuildAndTrainClassificationModel(classificationTrainingDataView, pipeline);

            //Evaluate

            EvaluateClassificationModel();
        }

        private IEstimator<ITransformer> ProcessClassificationData()
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
            .Append(mlContext.Transforms.Concatenate("Features", "Bedrooms", "Bathrooms", "SqftLivingFeaturized", "SqftLotFeaturized", "Floors", "Waterfront", "ViewFeaturized", "ConditionFeaturized", "GradeFeaturized", "SqftAboveFeaturized", "SqftAboveFeaturized", "SqftBasementFeaturized", "YrBuilt", "ZipcodeFeaturized", "SqftLiving15Featurized", "SqftLot15Featurized"))
            .AppendCacheCheckpoint(mlContext);

            return pipeline;
        }

        private void BuildAndTrainClassificationModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
        {
            var trainingPipeline = pipeline.Append(mlContext.MulticlassClassification.Trainers.LightGbm("Label", "Features"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            classificationTrainedModel = trainingPipeline.Fit(trainingDataView);

            classificationPredEngine = mlContext.Model.CreatePredictionEngine<HouseSaleDataClassification, PriceRangePrediction>(classificationTrainedModel);
        }

        private void EvaluateClassificationModel()
        {
            ClassificationTrainingMetrics = mlContext.MulticlassClassification.Evaluate(classificationTrainedModel.Transform(classificationTrainingDataView));

            ClassificationTestMetrics = mlContext.MulticlassClassification.Evaluate(classificationTrainedModel.Transform(classificationTestDataView));            

            Console.WriteLine($"*************************************************************************************************************");
            Console.WriteLine($"*       Metrics for Multi-class Classification model - Training Data     ");
            Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"*       MicroAccuracy:    {ClassificationTrainingMetrics.MicroAccuracy:0.###}");
            Console.WriteLine($"*       MacroAccuracy:    {ClassificationTrainingMetrics.MacroAccuracy:0.###}");
            Console.WriteLine($"*       LogLoss:          {ClassificationTrainingMetrics.LogLoss:#.###}");
            Console.WriteLine($"*       LogLossReduction: {ClassificationTrainingMetrics.LogLossReduction:#.###}");
            Console.WriteLine($"*************************************************************************************************************");

            Console.WriteLine($"*************************************************************************************************************");
            Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"*       MicroAccuracy:    {ClassificationTestMetrics.MicroAccuracy:0.###}");
            Console.WriteLine($"*       MacroAccuracy:    {ClassificationTestMetrics.MacroAccuracy:0.###}");
            Console.WriteLine($"*       LogLoss:          {ClassificationTestMetrics.LogLoss:#.###}");
            Console.WriteLine($"*       LogLossReduction: {ClassificationTestMetrics.LogLossReduction:#.###}");
            Console.WriteLine($"*************************************************************************************************************");
        }

        public void BuildRegressionTree()
        {
            //1. Create ML.NET environment

            mlContext = new MLContext(seed: 0);

            // 2. Load training and test data

            regressionTrainingDataView = mlContext.Data.LoadFromTextFile<HouseSaleDataRegression>(RegressionTrainDataPath, separatorChar: ',', hasHeader: true);

            regressionTestDataView = mlContext.Data.LoadFromTextFile<HouseSaleDataRegression>(RegressionTestDataPath, separatorChar: ',', hasHeader: true);

            // 3. Add data transformations and regression tree algorithm

            var pipeline = mlContext.Transforms.CopyColumns(inputColumnName: "Price", outputColumnName: "Label")
            .Append(mlContext.Transforms.Concatenate(outputColumnName: "Features", "Bedrooms", "Bathrooms", "Sqft_living", "Sqft_lot", "Floors", "Waterfronts", "View", "Condition", "Grade", "Sqft_above", "Sqft_basement", "Yr_built", "Zipcode", "Sqft_living15", "Sqft_lot15"))
            .Append(mlContext.Regression.Trainers.FastTree());

            // 4. Train model and assign regression prediction engine

            regressionTrainedModel = pipeline.Fit(regressionTrainingDataView);

            regressionPredEngine = mlContext.Model.CreatePredictionEngine<HouseSaleDataRegression, PricePrediction>(regressionTrainedModel);

            //5. Evaluate model on training data

            RegresionTrainingMetrics = mlContext.Regression.Evaluate(regressionTrainedModel.Transform(regressionTestDataView), "Label", "Score");

            //6. Evaluate model on test data

            RegresionTestMetrics = mlContext.Regression.Evaluate(regressionTrainedModel.Transform(regressionTestDataView), "Label", "Score");

        }

        public float PredictRegression(HouseSaleDataRegression newHouseSale)
        {
            return regressionPredEngine.Predict(newHouseSale).Price;
        }

        public string PredictClassification(HouseSaleDataClassification newHouseSale)
        {
            return classificationPredEngine.Predict(newHouseSale).PriceRange;
        }

    }
}
