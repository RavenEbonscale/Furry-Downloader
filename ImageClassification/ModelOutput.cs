using Microsoft.ML.Data;

namespace FurryClassifier
{
    internal class ModelOutput
    {

        [ColumnName("dense_1")]
        public float[] Prediction { get; set; }
    }
}
