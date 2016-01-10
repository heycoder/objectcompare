## Description
c#.net objectcompare

## Install
1. Install-Package HeyCoder.ObjectCompare
2. http://www.nuget.org/packages/HeyCoder.ObjectCompare

## Example

(1) simple compare
```c#
var obja1 = new { name = "heycoder" };
var objb1 = new { name = "heycoder.objectcompare" };
var compareResult = Comparer.Compare(obja1, objb1, new CompareParameter { ObjectAPropertyName = "name" });
```

(2) different name compare
```c#
var obja2 = new { name = "heycoder" };
var objb2 = new { fullname = "heycoder.objectcompare" };
```

(3) str compare
```c#
var obja3 = new { name = "heycoder" };
var objb3 = new { name = "heycoder.objectcompare" };
var compareResult = Comparer.Compare(obja3, objb3, new CompareParameter { ObjectAPropertyName = "name", EqualComparer = new StringEqualComparer(8) });
```

(4) time compare
```c#
var obja4 = new { time = DateTime.Parse("2016-01-01 01:00:00") };
var objb4 = new { time = DateTime.Parse("2016-01-01 23:00:00") };
var compareResult = Comparer.Compare(obja4, objb4, new CompareParameter { ObjectAPropertyName = "time", EqualComparer = new TimeEqualComparer("yyyyMMdd") });
```

(5) typeformat compare
```c#
var obja5 = new { amount = 100m };
var objb5 = new { amount = 100 };
var compareResult = Comparer.Compare(obja5, objb5, new CompareParameter { ObjectAPropertyName = "amount", CompareType = TypeCode.Decimal });
```