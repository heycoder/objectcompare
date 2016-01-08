using System;

namespace HeyCoder.ObjectCompare.EqualComparer
{
    public class TimeEqualComparer : IEqualComparer
    {
        private string Format { get; set; }
        public new bool Equals(object valueA, object valueB)
        {
            var strA = valueA == null ? string.Empty : Convert.ToDateTime(valueA).ToString(Format);
            var strB = valueB == null ? string.Empty : Convert.ToDateTime(valueB).ToString(Format);
            return strA == strB;
        }

        public TimeEqualComparer(string format)
        {
            this.Format = format;
        }
    }
}
