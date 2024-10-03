
namespace ExpressionParser
{
    public class BooleanExpressionParser
    {
        public static bool Evaluate(string expression)
        {
            expression = expression.Replace(" ", "");

            var stack = new Stack<bool>();
            var operatorStack = new Stack<char>();

            foreach (char c in expression)
            {
                switch (c)
                {
                    case TokenType.True:
                        stack.Push(true);
                        break;
                    case TokenType.False:
                        stack.Push(false);
                        break;
                    case TokenType.And:
                    case TokenType.Or:
                        while (operatorStack.Count > 0 && operatorStack.Peek() != TokenType.LeftParen)
                            ApplyOperator(stack, operatorStack);
                        operatorStack.Push(c);
                        break;
                    case TokenType.LeftParen:
                        operatorStack.Push(c);
                        break;
                    case TokenType.RightParen:
                        while (operatorStack.Peek() != TokenType.LeftParen)
                            ApplyOperator(stack, operatorStack);
                        operatorStack.Pop(); // Remove left parenthesis
                        break;
                }
            }

            while (operatorStack.Count > 0)
                ApplyOperator(stack, operatorStack);

            return stack.Pop();
        }
        
        private static void ApplyOperator(Stack<bool> stack, Stack<char> operatorStack)
        {
            char op = operatorStack.Pop();
            bool right = stack.Pop();
            bool left = stack.Pop();

            switch (op)
            {
                case TokenType.And:
                    stack.Push(left && right);
                    break;
                case TokenType.Or:
                    stack.Push(left || right);
                    break;
            }
        }
    }
}
