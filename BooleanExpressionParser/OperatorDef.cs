using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    internal class OperatorDef(string Operator, int Operator1, int Operator2)
    {
        public string Operator { get; set; } = Operator; // >=, <=, =, >, <

        /// <summary>
        /// Combination of Operator1 and Operator2 is used to represent combined boolean operators like >=
        /// >= will be reppresented as Operator1 1 and Operator2 0
        /// <= will be reppresented as Operator2 -1 and Operator2 0
        /// > will be reppresented as Operator1 1 and Operator2 1
        /// </summary>
        public int Operator1 { get; set; } = Operator1; // -1 - Less than, 0 - Equal to, 1 - Greater than
        public int Operator2 { get; set; } = Operator2; // -1 - Less than, 0 - Equal to, 1 - Greater than
    }
}
