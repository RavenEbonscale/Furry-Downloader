using Microsoft.ML.Transforms.Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurryClassifier
{
    internal class ModelInput
    {
        [ImageType(128, 128)]
        public Bitmap Image { get; set; }
    }
}
