using HeyCoder.ObjectCompare.EqualComparer;
using System;

namespace HeyCoder.ObjectCompare
{
    public class CompareParameter
    {
        public string ObjectAPropertyName { get; set; }

        public string ObjectBPropertyName { get; set; }

        public TypeCode CompareType { get; set; }

        public IEqualComparer EqualComparer { get; set; }
    }
}
