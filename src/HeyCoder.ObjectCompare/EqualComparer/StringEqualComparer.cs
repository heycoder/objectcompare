namespace HeyCoder.ObjectCompare.EqualComparer
{
    public class StringEqualComparer : IEqualComparer
    {
        private int StartIndex { get; set; }

        private int Length { get; set; }

        private bool IgnoreCase { get; set; }

        public new bool Equals(object valueA, object valueB)
        {
            var strA = (valueA ?? string.Empty).ToString();
            var strB = (valueB ?? string.Empty).ToString();
            var maxLength = this.StartIndex + this.Length;
            var subLengthA = strA.Length < maxLength ? strA.Length - this.StartIndex : this.Length;
            var subLengthB = strB.Length < maxLength ? strB.Length - this.StartIndex : this.Length;
            if (this.IgnoreCase)
            {
                strA = strA.ToLower();
                strB = strB.ToLower();
            }
            var compareStrA = strA.Substring(this.StartIndex, subLengthA);
            var compareStrB = strB.Substring(this.StartIndex, subLengthB);
            return compareStrA == compareStrB;
        }

        public StringEqualComparer(int length, int startIndex = 0, bool ignoreCase = false)
        {
            this.Length = length;
            this.StartIndex = startIndex;
            this.IgnoreCase = ignoreCase;
        }
    }
}
