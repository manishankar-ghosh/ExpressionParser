namespace ExpressionParser
{
    public class MatchCriteria
    {
        private static List<OperatorDef> operatorDefs;
        static MatchCriteria()
        {
            operatorDefs =
            [
                new OperatorDef(Operator: ">=", Operator1: 1, Operator2: 0),
                new OperatorDef(Operator: "<=", Operator1: -1, Operator2: 0),
                new OperatorDef(Operator: "=", Operator1: 0, Operator2: 0),
                new OperatorDef(Operator: ">", Operator1: 1, Operator2: 1),
                new OperatorDef(Operator: "<", Operator1: -1, Operator2: -1)
            ];
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
            foreach(var item  in individualConditionsWithDataType)
            {
                string result = Utils.IsTrue(item.LeftOperand!, item.RightOperand!, item.Operator1, item.Operator2, item.DataType) ? "t" : "f";
                criteria = criteria.Replace(item.Token!, result);
            }

            criteria = criteria.Replace("-a", "a").Replace("-o", "o");
            return criteria;
        }
        private static List<TokenWithOperator> GetIndividualConditionsWithDataType(List<string> individualConditions, List<TokenValueWithDataType> dataOrderedByPropertyNameLength)
        {
            var result = individualConditions.Select(token =>
            {
                var condition = dataOrderedByPropertyNameLength.First(x => token.Contains(x.Token!));
                var op = operatorDefs.First(o => token.Contains(o.Operator));

                string value = token.Replace(condition.Token!, condition.Value);
                var oprands = value.Split(op.Operator);

                var tokenValueWithDataType = new TokenWithOperator
                {
                    Token = token,
                    Value = value,
                    DataType = condition.DataType,
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
