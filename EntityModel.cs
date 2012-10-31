using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    public class EntityModel
    {
        public string ModelName { get; private set; }

        private Dictionary<string, FieldModel> TypeMapping;

        public EntityModel(string modelName, Dictionary<string, FieldModel> typeMapping)
        {
            ModelName = modelName;
            TypeMapping = new Dictionary<string, FieldModel>();

            foreach (var x in typeMapping)
            {
                typeMapping[x.Key] = x.Value;
            }
        }

        public FieldModel GetField(string name)
        {
            return TypeMapping[name];
        }

        public IEnumerable<FieldModel> GetFields()
        {
            return TypeMapping.Values;
        }
    }
}
