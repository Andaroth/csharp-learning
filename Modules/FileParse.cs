namespace Modules {
    class FileParse {
        private static void run(string fileName) {
            string projectName = "ACME";
            string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";

            string[][] messages = {
                new string[]{"View English output", "en"},
                new string[]{russianMessage, "ru"}
            };

            foreach (string[] item in messages) Console.WriteLine(
                $"{item[0]}:\n\t" +
                @$"c:\Exercise\{projectName}" +
                item[1] switch {
                    "ru" => @"\ru-RU\",
                    _ => @"\"
                } + 
                fileName
            );
        }

        public static void runFileParse() {
            run("data.txt");
        }
    }
}