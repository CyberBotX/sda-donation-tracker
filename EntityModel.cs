using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    public enum DonationDomain
    {
        LOCAL,
        CHIPIN,
    }

    public static class DonationModels
    {
        public static readonly EntityModel DonorModel
            = new EntityModel("donor",
                new Dictionary<string, Type>()
                {
                    { "firstName", typeof(string) },
                    { "lastName", typeof(string) },
                    { "alias", typeof(string) },
                    { "email", typeof(string) },
                });

        public static readonly EntityModel DonationModel
            = new EntityModel("donation",
                new Dictionary<string, Type>()
                {
                    { "timeReceived", typeof(DateTime) },
                    { "domain", typeof(DonationDomain) },
                    { "domainId", typeof(string) },
                    { "amount", typeof(decimal) },
                    { "comment", typeof(string) },
                });
    }
    
    // TODO: extend the 'type' thing to actually use type info
    // I figure it should be the following types:
    // string (length, and such)
    // int
    // enum (just its class)
    // date (just its class)
    // money (not even its class)
    // entity (string of the referenced model)
    // entity-set (string of the referenced model)

    public class EntityModel
    {
        public string ModelName { get; private set; }

        private Dictionary<string, Type> TypeMapping;

        public EntityModel(string modelName, Dictionary<string, Type> typeMapping)
        {
            ModelName = modelName;
            TypeMapping = new Dictionary<string, Type>();

            foreach (var x in typeMapping)
            {
                typeMapping[x.Key] = x.Value;
            }
        }

        public Type GetFieldType(string name)
        {
            return TypeMapping[name];
        }
    }
}
