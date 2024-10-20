using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;

public class QAData
{
    [LoadColumn(0)]
    public string Context { get; set; }

    [LoadColumn(1)]
    public string Question { get; set; }

    [LoadColumn(2)]
    public string Answer { get; set; }
}

public class TrainingModels
{
    private string _currentDirectory { get; set; }
    private string _dataPath = @"..\..\..\Data\questions.csv";
    protected string _qaPath = @"..\..\..\Data\Models\QAModel.zip";
    protected string _contextPath = @"..\..\..\Data\Models\ContextModel.zip";

    public TrainingModels()
    {
        _currentDirectory = Directory.GetCurrentDirectory();
        _dataPath = Path.Combine(_currentDirectory, _dataPath);
        _qaPath = Path.Combine(_currentDirectory, _qaPath);
        _contextPath = Path.Combine(_currentDirectory, _contextPath);
    }
    public void Train()
    {
        MLContext mlContext = new MLContext();
        var textLoader = mlContext.Data.CreateTextLoader(new TextLoader.Options
        {
            Separators = new[] { ',' },
            HasHeader = true,
            Columns = new[]
            {
                new TextLoader.Column(nameof(QAData.Context), DataKind.String, 0),
                new TextLoader.Column(nameof(QAData.Question), DataKind.String, 1),
                new TextLoader.Column(nameof(QAData.Answer), DataKind.String, 2)
            }
        });

        IDataView data = textLoader.Load(_dataPath);

        var trainTestData = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
        var trainingData = trainTestData.TrainSet;
        var testData = trainTestData.TestSet;

        var pipeline = mlContext.Transforms.Text.FeaturizeText("QuestionFeatures", nameof(QAData.Question))
            .Append(mlContext.Transforms.Text.FeaturizeText("ContextFeatures", nameof(QAData.Context)))
            .Append(mlContext.Transforms.Concatenate("Features", "QuestionFeatures", "ContextFeatures"))
            .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(QAData.Answer)))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        var model = pipeline.Fit(trainingData);

        var predictions = model.Transform(testData);
        var metrics = mlContext.MulticlassClassification.Evaluate(predictions);

        Console.WriteLine($"MicroAccuracy: {metrics.MicroAccuracy}");
        Console.WriteLine($"MacroAccuracy: {metrics.MacroAccuracy}");

        mlContext.Model.Save(model, trainingData.Schema, _qaPath);
    }

    public void ContestTrain()
    {
        MLContext mlContext = new MLContext();
        var textLoader = mlContext.Data.CreateTextLoader(new TextLoader.Options
        {
            Separators = new[] { ',' },
            HasHeader = true,
            Columns = new[]
            {
                new TextLoader.Column(nameof(QAData.Context), DataKind.String, 0),
                new TextLoader.Column(nameof(QAData.Question), DataKind.String, 1),
                new TextLoader.Column(nameof(QAData.Answer), DataKind.String, 2)
            }
        });

        IDataView data = textLoader.Load(_dataPath);

        var trainTestData = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
        var trainingData = trainTestData.TrainSet;
        var testData = trainTestData.TestSet;

        var pipeline = mlContext.Transforms.Text.FeaturizeText("QuestionFeatures", nameof(QAData.Question))
            .Append(mlContext.Transforms.Concatenate("Features", "QuestionFeatures"))
            .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(QAData.Context)))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        var model = pipeline.Fit(trainingData);

        var predictions = model.Transform(testData);
        var metrics = mlContext.MulticlassClassification.Evaluate(predictions);

        Console.WriteLine($"MicroAccuracy: {metrics.MicroAccuracy}");
        Console.WriteLine($"MacroAccuracy: {metrics.MacroAccuracy}");

        mlContext.Model.Save(model, trainingData.Schema, _contextPath);
    }
}