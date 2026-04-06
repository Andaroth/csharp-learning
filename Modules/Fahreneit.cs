using Utils;
using static Utils.Numbers;

namespace Modules {
    class Fahreneit {
        private static decimal convert(decimal F) {
            return (F - 32m) * 5m / 9m;
        }

        private static decimal requestUserPrompt() {
            Console.Write($"\nEnter temp in Fahreneit : ");
            string? userPrompt = Console.ReadLine();
            if (userPrompt == null || isNaN(userPrompt)) return requestUserPrompt();
            else if (Decimal.TryParse(userPrompt, out decimal response)) return response;
            return (decimal)0;
        }

        private static void run() {
            decimal F = requestUserPrompt();
            Console.Write($"\nResult: {convert(F)}\n");
        }

        public static void runFahreneit() {
            run();
        }
    }
}