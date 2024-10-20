using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    public class Consumption: TrainingModels
    {
        public string TestSingleQuestion(string userQuestion, string context)
        {
            MLContext mlContext = new MLContext();
            ITransformer trainedModel = mlContext.Model.Load(_qaPath, out DataViewSchema inputSchema);

            var qaData = new List<QAData>
            {
                new QAData
                {
                    Question = userQuestion ,
                    Context=context
                }
            };

            IDataView inputData = mlContext.Data.LoadFromEnumerable(qaData);
            IDataView predictions = trainedModel.Transform(inputData);
            var predictionResult = mlContext.Data.CreateEnumerable<PredictionResult>(predictions, reuseRowObject: false).FirstOrDefault();

            if (predictionResult != null)
            {
                return predictionResult.PredictedLabel;
            }
            else
            {
                return "No prediction could be made.";
            }
            return "";
        }

        public string TestSingleContext(string userQuestion)
        {
            MLContext mlContext = new MLContext();
            ITransformer trainedModel = mlContext.Model.Load(_contextPath, out DataViewSchema inputSchema);

            var qaData = new List<QAData>
            {
                new QAData
                {
                    Question = userQuestion
                }
            };

            IDataView inputData = mlContext.Data.LoadFromEnumerable(qaData);
            IDataView predictions = trainedModel.Transform(inputData);
            var predictionResult = mlContext.Data.CreateEnumerable<PredictionResult>(predictions, reuseRowObject: false).FirstOrDefault();

            if (predictionResult != null)
            {
                return predictionResult.PredictedLabel;
            }
            else
            {
                return "No prediction could be made.";
            }
            return "";
        }

        public class QAData
        {
            public string Question { get; set; }
            public string Answer { get; set; }
            public string Context { get; set; }
        }

        public class QAData1
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }

        public class PredictionResult
        {
            public string PredictedLabel { get; set; }
        }
    }
}
