using HeyCoder.ObjectCompare.EqualComparer;
using System;

namespace HeyCoder.ObjectCompare.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HeyCoder.ObjectCompare";
            var objA = new { Name = "ken zheng", Age = 18, BorthTime = "2015-01-01 03:55:00" };
            var objB = new { RealName = "ken", Age = 18.1d, BorthTime = "2015-01-01 03:05:00" };
            Console.WriteLine(objA.GetType().GetProperty("xx") == null);
            var compareResult = Comparer.Compare(objA, objB,
                new[] { new CompareParameter { ObjectAPropertyName = "Name", ObjectBPropertyName = "RealName",EqualComparer=new StringEqualComparer(3)  },
                new CompareParameter { ObjectAPropertyName = "Age", CompareType =TypeCode.Int32 },
                new CompareParameter { ObjectAPropertyName = "BorthTime",EqualComparer=new TimeEqualComparer("yyyy-MM-dd")  }
                }
            );

            Console.WriteLine(compareResult.IsEqual);
            Console.WriteLine("=======================================================");
            Console.WriteLine("DifferentPropertyList：");
            compareResult.DifferentPropertyList.ForEach(p =>
            {
                Console.WriteLine("ObjectAPropertyName = {0}, ObjectBPropertyName = {1}, ValueA = {2}, ValueB = {3}", p.ObjectAPropertyName, p.ObjectBPropertyName, p.ObjectAValue, p.ObjectBValue);
            });
            Console.WriteLine("=======================================================");
            Console.WriteLine("SamePropertyList：");
            compareResult.SamePropertyList.ForEach(p =>
            {
                Console.WriteLine("ObjectAPropertyName = {0}, ObjectBPropertyName = {1}, ValueA = {2}, ValueB = {3}", p.ObjectAPropertyName, p.ObjectBPropertyName, p.ObjectAValue, p.ObjectBValue);
            });
            Console.ReadKey();
        }
    }
}
