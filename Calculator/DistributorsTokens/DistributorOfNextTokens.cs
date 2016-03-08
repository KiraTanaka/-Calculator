using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculator.DistributorsTokens
{
    public class DistributorOfNextTokens
    {
        private static Dictionary<string, Token> Tokens = new Dictionary<string, Token>(){  {"*", new TokenOperations()},
                                                                                            {"/", new TokenOperations()}, 
                                                                                            {"+", new TokenOperations()}, 
                                                                                            {"-", new TokenOperations()},
                                                                                            {"(", new TokenLeftBracket()}, 
                                                                                            {")", new TokenRightBracket()}};
                                                     
        public static Token GetToken(string symbol)
        {
            KeyValuePair<string, Token> token = Tokens.FirstOrDefault(x => x.Key == symbol);
            if (!token.Equals(null))
            {
                token.Value.Value = symbol;
                return token.Value;
            }
            return null;
        }
        public static List<Type> GetNextTokenTypes(Token token)
        {
            List<Type> nextTokens = new List<Type>();
            if (typeof(TokenNumber).Equals(token.GetType()))
                NextTokenTypesAfterNumber(ref nextTokens);
            else if (typeof(TokenOperations).Equals(token.GetType()))
                NextTokenTypesAfterOperation(ref nextTokens);
            else if (typeof(TokenLeftBracket).Equals(token.GetType()))
                NextTokenTypesAfterLeftBrackets(ref nextTokens);
            else if (typeof(TokenRightBracket).Equals(token.GetType()))
                NextTokenTypesAfterRightBrackets(ref nextTokens);
            else if (typeof(TokenBeginningOfLine).Equals(token.GetType()))
                NextTokenTypesAfterBeginningOfLine(ref nextTokens);
            return nextTokens;
        }

        private static void NextTokenTypesAfterNumber(ref List<Type> nextTokenTypes)
        {
            nextTokenTypes.Add(typeof( TokenOperations));
            nextTokenTypes.Add(typeof( TokenRightBracket));
            nextTokenTypes.Add(typeof( TokenOfEndOfLine));
        }

        private static void NextTokenTypesAfterOperation(ref  List<Type> nextTokenTypes)
        {
            nextTokenTypes.Add(typeof( TokenLeftBracket));
            nextTokenTypes.Add(typeof( TokenNumber));
        }

        private static void NextTokenTypesAfterLeftBrackets(ref  List<Type> nextTokenTypes)
        {
            nextTokenTypes.Add(typeof( TokenLeftBracket));
            nextTokenTypes.Add(typeof( TokenNumber));
        }

        private static void NextTokenTypesAfterRightBrackets(ref  List<Type> nextTokenTypes)
        {
            nextTokenTypes.Add(typeof( TokenOperations));
            nextTokenTypes.Add(typeof( TokenRightBracket));
            nextTokenTypes.Add(typeof( TokenOfEndOfLine));
        }
        private static void NextTokenTypesAfterBeginningOfLine(ref  List<Type> nextTokenTypes)
        {
            nextTokenTypes.Add(typeof( TokenNumber));
            nextTokenTypes.Add(typeof( TokenLeftBracket));           
        }
    }
}
