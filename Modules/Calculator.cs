using Utils;
using static Utils.Numbers;

namespace Modules {
    class Calculator {
        private static char[] ALLOWED_OPERATIONS = {'+','-','*','/','%','^','e','v'};
        private static string displayCommands = string.Join(",", ALLOWED_OPERATIONS);

        private static dynamic autocastMath<T>(T a, T b, char operation) {
            decimal decimalA = Convert.ToDecimal(a);
            decimal decimalB = Convert.ToDecimal(b);
            double doubleA = Convert.ToDouble(a);
            double doubleB = Convert.ToDouble(b);
            return operation switch {
            '+' => decimalA + decimalB,
            '-' => decimalA - decimalB,
            '*' => decimalA * decimalB,
            '/' => decimalB != 0.0m ? decimalA / decimalB : doubleA / doubleB,
            '%' => decimalA % decimalB,
            '^' => Math.Pow(doubleA, doubleB),
            'e' => doubleA * Math.Pow(10, doubleB),
            'v' => Math.Pow(doubleB, 1.0f / doubleA),
            _ => (byte)0
            };
        }

        private static bool isPromptValidNumber(string? prompt) {
            bool isNull = prompt == null;
            bool hasGoodLength = prompt != null && prompt.Length > 0;
            bool canParse = prompt != null && !isNaN(prompt);
            bool isValid = !isNull && hasGoodLength && canParse;
            if (isNull || !hasGoodLength) Console.Write($"\n/!\\ Your prompt cannot be empty\n");
            else if (!isValid) Console.Write($"\n/!\\ \"{prompt}\" is not a valid number\n");
            return isValid;
        }

        private static bool isPromptValidOperation(string? prompt) {
            bool isNull = prompt == null;
            bool hasGoodLength = prompt != null && prompt.Length == 1;
            bool canParse = Char.TryParse(prompt, out char parsedPromptAsChar);
            bool isExpressionValid = ALLOWED_OPERATIONS.Contains(parsedPromptAsChar);
            bool isValid = !isNull && hasGoodLength && canParse && isExpressionValid;
            if (isNull) Console.Write($"\n/!\\ Your prompt cannot be empty\n");
            else if (!hasGoodLength || !isExpressionValid) Console.Write($"\n/!\\ Select a valid operation ({displayCommands})\n");
            else if (!isValid) Console.Write($"\n/!\\ \"{prompt}\" is not a valid operation\n");
            return isValid;
        }

        private static decimal requestUserPrompt(char target) {
            Console.Write($"\nEnter number {target} : ");
            string? userPrompt = Console.ReadLine();
            if (!isPromptValidNumber(userPrompt)) return requestUserPrompt(target);
            else return Convert.ToDecimal(userPrompt);
        }

        private static char requestUserOperation() {
            Console.Write($"\nChose a mathematic operation [{displayCommands}] : ");
            string? promptOperation = Console.ReadLine();
            if (!isPromptValidOperation(promptOperation)) return requestUserOperation();
            if (Char.TryParse(promptOperation, out char casting)) return casting;
            return '\0';
        }

        private static void restartPrompt() {
            Console.Write("\nStart over? [Y,n]:");
            ConsoleKey restart;
            do { restart = Console.ReadKey(false).Key; }
            while (restart != ConsoleKey.N && restart != ConsoleKey.Y && restart != ConsoleKey.Enter && restart != ConsoleKey.Escape);
            Console.Write('\n');
            if (restart != ConsoleKey.N && restart != ConsoleKey.Escape) run();
        }

        private static void run() {
            decimal a = requestUserPrompt('A');
            char op = requestUserOperation();
            decimal b = requestUserPrompt('B');
            string res = $"{autocastMath(a,b,op)}";
            Console.Write($"\nResult: {a} {op} {b} = {res}\n");
            restartPrompt();
        }

        public static void runCalculator() {
            run();
        }
    }
}