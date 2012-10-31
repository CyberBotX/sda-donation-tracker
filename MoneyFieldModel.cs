using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    public class MoneyFieldModel : FieldModel
    {
        public Type FieldType { get { return typeof(decimal); } }
    }
}
