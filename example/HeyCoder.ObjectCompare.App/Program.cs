using HeyCoder.ObjectCompare.EqualComparer;
using System;

namespace HeyCoder.ObjectCompare.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HeyCoder.ObjectCompare";

            //simple compare
            var obja1 = new { name = "heycoder" };
            var objb1 = new { name = "heycoder.objectcompare" };
            ShowCompareResult(Comparer.Compare(obja1, objb1, new CompareParameter { ObjectAPropertyName = "name" }));

            //different name compare
            var obja2 = new { name = "heycoder" };
            var objb2 = new { fullname = "heycoder.objectcompare" };
            ShowCompareResult(Comparer.Compare(obja2, objb2, new CompareParameter { ObjectAPropertyName = "name", ObjectBPropertyName = "fullname" }));

            //str compare
            var obja3 = new { name = "heycoder" };
            var objb3 = new { name = "heycoder.objectcompare" };
            ShowCompareResult(Comparer.Compare(obja3, objb3, new CompareParameter { ObjectAPropertyName = "name", EqualComparer = new StringEqualComparer(8) }));

            //time compare
            var obja4 = new { time = DateTime.Parse("2016-01-01 01:00:00") };
            var objb4 = new { time = DateTime.Parse("2016-01-01 23:00:00") };
            ShowCompareResult(Comparer.Compare(obja4, objb4, new CompareParameter { ObjectAPropertyName = "time", EqualComparer = new TimeEqualComparer("yyyyMMdd") }));

            //typeformat compare
            var obja5 = new { amount = 100m };
            var objb5 = new { amount = 100 };
            ShowCompareResult(Comparer.Compare(obja5, objb5, new CompareParameter { ObjectAPropertyName = "amount", CompareType = TypeCode.Decimal }));



            Console.ReadKey();
        }

        static void ShowCompareResult(CompareResult compareResult)
        {
            Console.WriteLine();
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
            Console.WriteLine("Exception:{0}", compareResult.Exception);
        }
    }
}
