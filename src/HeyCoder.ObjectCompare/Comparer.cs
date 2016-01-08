using System;
using System.Xml;

namespace HeyCoder.ObjectCompare
{
    public class Comparer
    {
        /// <summary>
        /// Compare object with parameters
        /// </summary>
        /// <param name="objectA"></param>
        /// <param name="objectB"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static CompareResult Compare(object objectA, object objectB, params CompareParameter[] parameters)
        {
            var result = new CompareResult();
            if (objectA == null || objectB == null)
            {
                result.IsEqual = objectA == objectB;
                return result;
            }
            if (parameters == null)
            {
                return new CompareResult { IsEqual = objectA.Equals(objectB) };
            }
            var typeA = objectA.GetType();
            var typeB = objectB.GetType();
            foreach (var parameter in parameters)
            {
                try
                {
                    parameter.ObjectBPropertyName = parameter.ObjectBPropertyName ?? parameter.ObjectAPropertyName;
                    var propertyA = typeA.GetProperty(parameter.ObjectAPropertyName);
                    var propertyB = typeB.GetProperty(parameter.ObjectBPropertyName);
                    if (propertyA == null || propertyB == null)
                    {
                        return new CompareResult { Exception = new Exception("propertyA or propertyB is null") };
                    }
                    var valueA = propertyA.GetValue(objectA, null);
                    var valueB = propertyB.GetValue(objectB, null);
                    bool isEqual;
                    if (valueA == null || valueB == null)
                    {
                        isEqual = valueA == valueB;
                    }
                    else
                    {
                        if (parameter.CompareType != TypeCode.Empty)
                        {
                            valueA = Convert.ChangeType(valueA, parameter.CompareType);
                            valueB = Convert.ChangeType(valueB, parameter.CompareType);
                        }
                        isEqual = parameter.EqualComparer == null
                            ? valueA.Equals(valueB)
                            : parameter.EqualComparer.Equals(valueA, valueB);
                    }
                    if (isEqual)
                    {
                        result.SamePropertyList.Add(new PropertyResult
                        {
                            ObjectAPropertyName = parameter.ObjectAPropertyName,
                            ObjectBPropertyName = parameter.ObjectBPropertyName,
                            ObjectAValue = valueA,
                            ObjectBValue = valueB
                        });
                    }
                    else
                    {
                        result.DifferentPropertyList.Add(new PropertyResult
                        {
                            ObjectAPropertyName = parameter.ObjectAPropertyName,
                            ObjectBPropertyName = parameter.ObjectBPropertyName,
                            ObjectAValue = valueA,
                            ObjectBValue = valueB
                        });
                    }
                }
                catch (Exception ex)
                {
                    return new CompareResult { Exception = ex };
                }

            }
            result.IsEqual = result.DifferentPropertyList.Count == 0;
            return result;
        }
    }
}
