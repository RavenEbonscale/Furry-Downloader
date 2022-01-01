using ArryStuff;
using FurryClassifier;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Onnx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageClassification
{
    public class ImageClassification : IImage_Classification

    {
        public string Prediction(byte[] Image)
        {
            #region Loading The Onnx Model
            var mlcontext = new MLContext();
            EstimatorChain<OnnxTransformer> pipeline = mlcontext.Transforms.ResizeImages("image", 128, 128, nameof(ModelInput.Image))
             .Append(mlcontext.Transforms.ExtractPixels("Images", "image"))
            .Append(mlcontext.Transforms.ApplyOnnxModel("dense_1", "Images", "gender.onnx"));

            IDataView data = mlcontext.Data.LoadFromEnumerable(new List<ModelInput>());
            OnnxOptions onnxOptions = new OnnxOptions();

            TransformerChain<OnnxTransformer> model = pipeline.Fit(data);


            PredictionEngine<ModelInput, ModelOutput> predictionEngine = mlcontext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
            #endregion

            #region Predction
            MemoryStream ms = new MemoryStream(Image);
            Bitmap bitmap = new Bitmap(ms);
            ms.Dispose();
            ModelInput input = new ModelInput { Image = bitmap };
            ModelOutput prediction = predictionEngine.Predict(input);
            int classification = prediction.Prediction.ArgsMax();
            #endregion
           
            return Classification.SexualityClassification[classification];

        } 
    }
}
