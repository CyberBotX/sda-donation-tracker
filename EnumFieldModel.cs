using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    public class EnumFieldModel : FieldModel
    {
        public Type FieldType { get; private set; }

        public EnumFieldModel(Type enumType)
        {
            FieldType = enumType;
        }
    }
}
