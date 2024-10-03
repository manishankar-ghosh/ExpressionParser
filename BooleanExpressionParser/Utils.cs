using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    internal class Utils
    {
        public static int Compare(string value1, string value2, char dataType)
        {
            int result;
            if (dataType == 'i')
            {
                var typedValue1 = int.Parse(value1);
                var typedValue2 = int.Parse(value2);
                result = typedValue1.CompareTo(typedValue2);
            }
            else if (dataType == 'f')
            {
                var typedValue1 = float.Parse(value1);
                var typedValue2 = float.Parse(value2);
                result = typedValue1.CompareTo(typedValue2);
            }
            else if (dataType == 't')
            {
                var typedValue1 = DateTime.Parse(value1);
                var typedValue2 = DateTime.Parse(value2);
                result = typedValue1.CompareTo(typedValue2);
            } else
            {
                result = value1.CompareTo(value2);
            }

            return result;
        }

        public static bool IsTrue(string value1, string value2, int comparisionOperator1, int comparisionOperator2, char dataType)
        {
            int comapreResult = Compare(value1, value2, dataType);
            return comapreResult == comparisionOperator1 || comapreResult == comparisionOperator2;
        }

        public static char GetDataType(string value)
        {
            char result;
            if(int.TryParse(value, out var _))
            {
                result = DataType.Integer;
            }
            else if (long.TryParse(value, out var _))
            {
                result = DataType.Long;
            }
            else if (float.TryParse(value, out var _))
            {
                result = DataType.Float;
            }
            else if (double.TryParse(value, out var _))
            {
                result = DataType.Double;
            }
            else if (decimal.TryParse(value, out var _))
            {
                result = DataType.Decimal;
            }
            else if (DateTime.TryParse(value, out var _))
            {
                result = DataType.DateTime;
            }
            else
            {
                result = DataType.String;
            }

            return result;
        }

    }
}
