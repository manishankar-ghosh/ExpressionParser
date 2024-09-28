using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    internal class TokenWithOperator : TokenValueWithDataType
    {
        public string? LeftOperand { get; set; }
        public string? RightOperand { get; set; }
        public int Operator1 { get; set; } // -1 - Less than, 0 - Equal to, 1 - Greater than
        public int Operator2 { get; set; } // -1 - Less than, 0 - Equal to, 1 - Greater than
    }
}
