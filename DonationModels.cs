using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    // TODO: 
    // - finish adding the other models, and linking them up appropriately
    // - actually make use of this...
    public static class DonationModels
    {
        public static readonly EntityModel DonorModel
            = new EntityModel("donor",
                new Dictionary<string, FieldModel>()
                {
                    { "firstName", new StringFieldModel() },
                    { "lastName", new StringFieldModel() },
                    { "alias", new StringFieldModel() },
                    { "email", new StringFieldModel() },
                    { "donations", new EntitySetModel("donation") },
                });

        public static readonly EntityModel DonationModel
            = new EntityModel("donation",
                new Dictionary<string, FieldModel>()
                {
                    { "timeReceived", new DateTimeFieldModel() },
                    { "domain", new EnumFieldModel(typeof(DonationDomain)) },
                    { "domainId", new StringFieldModel() },
                    { "amount", new MoneyFieldModel() },
                    { "comment", new StringFieldModel() },
                });

        private static Dictionary<string, EntityModel> ModelMap = new Dictionary<string, EntityModel>(StringComparer.OrdinalIgnoreCase)
        {
            { "donor", DonorModel },
            { "donation", DonationModel },
        };

        public static EntityModel GetModel(string name)
        {
            EntityModel result;
            if (ModelMap.TryGetValue(name, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
