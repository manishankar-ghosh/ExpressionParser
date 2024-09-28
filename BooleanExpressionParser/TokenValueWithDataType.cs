using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public class TokenValueWithDataType
    {
        public string? Token { get; set; }
        public string? Value { get; set; }
        public char DataType { get; set; }
    }
}
