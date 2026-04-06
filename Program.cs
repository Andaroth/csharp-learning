using Modules;
using static Modules.HelloWorld;
using static Modules.Fahreneit;
using static Modules.FileParse;
using static Modules.Calculator;
using static Modules.StudentsNotes;

class Program {
    private static string[] exercises = {"[H] Helloworld","[F] Fahreneit","[P] Fileparse","[C] calculator","[S] students"};
    private static string displayExercises = string.Join('\n', exercises);

    private static void Main() {
        Console.Clear();
        Console.Write($"\n== SELECT EXERCISE ==\n{displayExercises}\nPress shortcut : ");
        ConsoleKey selection = Console.ReadKey(false).Key; 
        Action runExercise = selection switch {
            ConsoleKey.H => () => runHelloWorld(),
            ConsoleKey.F => () => runFahreneit(),
            ConsoleKey.P => () => runFileParse(),
            ConsoleKey.C => () => runCalculator(),
            ConsoleKey.S => () => runStudentsNote(),
            _ => () => {}
        };
        Console.Clear();
        runExercise();
        if (selection != ConsoleKey.Escape) Main();
    }
}