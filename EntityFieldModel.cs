using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    public class EntityFieldModel : FieldModel
    {
        public Type FieldType { get { return typeof(EntityModel); } }
        public string ModelName { get; private set; }
        public EntityModel GetModel { get { return DonationModels.GetModel(ModelName); } }

        public EntityFieldModel(string modelName)
        {
            ModelName = modelName;
        }
    }
}
