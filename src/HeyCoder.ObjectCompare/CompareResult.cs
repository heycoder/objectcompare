using System;
using System.Collections.Generic;

namespace HeyCoder.ObjectCompare
{
    public class CompareResult
    {
        public bool IsEqual { get; set; }

        public List<PropertyResult> DifferentPropertyList { get; set; }

        public List<PropertyResult> SamePropertyList { get; set; }

        public Exception Exception { get; set; }

        public CompareResult()
        {
            DifferentPropertyList = new List<PropertyResult>();
            SamePropertyList = new List<PropertyResult>();
        }
    }
}
