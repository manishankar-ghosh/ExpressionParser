using System.Data;
using System.Text.RegularExpressions;

namespace ExpressionParser
{
    public class MatchCriteria
    {
        private static List<OperatorDef> operatorDefs;
        private static Dictionary<char, Type> dotNetDataTypes;
        static MatchCriteria()
        {
            operatorDefs =
            [
                new OperatorDef(Operator: ">=", Operator1: 1, Operator2: 0),
                new OperatorDef(Operator: "<=", Operator1: -1, Operator2: 0),
                new OperatorDef(Operator: "<>", Operator1: -1, Operator2: 1),
                new OperatorDef(Operator: "!=", Operator1: -1, Operator2: 1),
                new OperatorDef(Operator: "=", Operator1: 0, Operator2: 0),
                new OperatorDef(Operator: ">", Operator1: 1, Operator2: 1),
                new OperatorDef(Operator: "<", Operator1: -1, Operator2: -1)
            ];

            dotNetDataTypes = new Dictionary<char, Type>
            {
                {'c', System.Type.GetType("System.Char")! },
                {'i', System.Type.GetType("System.Int32")! },
                {'l', System.Type.GetType("System.Int64")! },
                {'f', System.Type.GetType("System.Single")! },
                {'d', System.Type.GetType("System.Double")! },
                {'m', System.Type.GetType("System.Decimal")! },
                {'t', System.Type.GetType("System.DateTime")! },
                {'s', System.Type.GetType("System.String")! }
            };
        }

        public static bool IsMatching2(List<TokenValueWithDataType> data, string criteria)
        {
            bool isMatching = false;

            DataTable table = new DataTable();
            DataColumn column;
            foreach (TokenValueWithDataType item in data)
            {
                column = new DataColumn
                {
                    DataType = dotNetDataTypes[item.DataType],
                    ColumnName = item.Token,
                    DefaultValue = item.Value
                };
                
                table.Columns.Add(column);
            }

            column = new DataColumn
            {
                DataType = typeof(bool),
                ColumnName = "IsTrue",
                Expression = criteria
            };

            table.Columns.Add(column);

            DataRow row = table.NewRow();
            table.Rows.Add(row);
            isMatching = Convert.ToBoolean( table.Rows[0]["IsTrue"]);
            return isMatching;
        }


        public static bool IsMatching(List<TokenValueWithDataType> data, string criteria)
        {
            bool isMatching = false;

            var individualConditions = GetIndividualConditions(criteria);
            List<TokenValueWithDataType> dataOrderedByPropertyNameLength = data.OrderByDescending(p => p.Token!.Length).ToList();
            List<TokenWithOperator> individualConditionsWithDataType = GetIndividualConditionsWithDataType(individualConditions, dataOrderedByPropertyNameLength);

            string booleanCriteriaExpression = GetBooleanCriteriaExpression(criteria, individualConditionsWithDataType);

            isMatching = ExpressionParser.BooleanExpressionParser.Evaluate(booleanCriteriaExpression);
            return isMatching;
        }

        private static string GetBooleanCriteriaExpression(string criteria, List<TokenWithOperator> individualConditionsWithDataType)
        {
            foreach (var item in individualConditionsWithDataType)
            {
                string result = Utils.IsTrue(item.LeftOperand!, item.RightOperand!, item.Operator1, item.Operator2, item.DataType) ? "t" : "f";

                Regex regex = new Regex(Regex.Escape(item.Token!));
                criteria = regex.Replace(criteria, result, 1);
            }

            criteria = criteria.Replace("-a", "a").Replace("-o", "o");
            return criteria;
        }
        private static List<TokenWithOperator> GetIndividualConditionsWithDataType(List<string> individualConditions, List<TokenValueWithDataType> dataOrderedByPropertyNameLength)
        {
            var result = individualConditions.Select(token =>
            {
                var op = operatorDefs.First(o => token.Contains(o.Operator));

                var condition = dataOrderedByPropertyNameLength.FirstOrDefault(x => token.Contains(x.Token!));

                string value = token;
                char dataType = 'u'; // Unknown
                if (condition is not null)
                {
                    value = value.Replace(condition.Token!, condition.Value);
                    dataType = condition.DataType;
                }


                var oprands = value.Split(op.Operator);

                if (dataType == 'u')
                {
                    dataType = Utils.GetDataType(oprands[0].Trim());
                }

                var tokenValueWithDataType = new TokenWithOperator
                {
                    Token = token,
                    Value = value,
                    DataType = dataType,
                    LeftOperand = oprands[0].Trim(),
                    RightOperand = oprands[1].Trim(),
                    Operator1 = op.Operator1,
                    Operator2 = op.Operator2
                };

                return tokenValueWithDataType;

            }).ToList();

            return result;
        }
        private static List<string> GetIndividualConditions(string criteria)
        {
            var conditions = criteria.Split(new string[] { " -a ", " -o " }, System.StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim().Replace("(", "").Replace(")", ""))
                .ToList();

            return conditions;
        }
    }
}
