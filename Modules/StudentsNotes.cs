namespace Modules {
    class StudentsNotes {
        private static Dictionary<string, int[]> database = new Dictionary<string, int[]>();

        private static int[] sophia = {93,87,98,95,100};
        private static int[] nicolas = {80,83,82,88,85};
        private static int[] zahirah = {84,6,73,5,79};
        private static int[] jeong = {90,92,98,100,97};

        private static void fetchDb() {
            database = new Dictionary<string, int[]>();
            database.Add("sophia", sophia);
            database.Add("nicolas", nicolas);
            database.Add("zahirah", zahirah);
            database.Add("jeong", jeong);
        }

        private static int[] getDb(string name) {
            if (database.ContainsKey(name)) return database[name];
            else return new int[0];
        }

        private static string getScoreNote(int score) => score switch {
            >= 100 => "S++",
            >= 99  => "S+",
            >= 98  => "S",
            >= 95  => "A+",
            >= 90  => "A",
            >= 80  => "B+",
            >= 70  => "B",
            >= 60  => "C+",
            >= 50  => "C",
            >= 40  => "D",
            >= 10  => "E",
            _      => "F"
        };

        private static int getSum(int[] dataset) {
            int sum = 0;
            foreach (int score in dataset) sum += score;
            return sum;
        }

        private static float getScoreByName(string name) {
            int[] dataset = getDb(name);
            int sum = getSum(dataset);
            int itemsCount = dataset.Count();
            return sum / itemsCount;
        }

        private static int getSumByName(string name) {
            int[] dataset = getDb(name);
            return getSum(dataset);
        }

        private static string getTeacherNoteByName(string name) {
            int[] dataset = getDb(name);
            int score = (int)getScoreByName(name);
            return getScoreNote(score);
        }

        public static void runStudentsNote() {
            fetchDb();
            string[] studentsScores = {"sophia","nicolas","zahirah","jeong"};
            foreach (string studentName in studentsScores) {
                Console.WriteLine($"\n== {studentName} ==");
                Console.WriteLine($"> Total = {getSumByName(studentName)}");
                Console.WriteLine($"> Moyenne = {getScoreByName(studentName)}");
                Console.WriteLine($"> Note = {getTeacherNoteByName(studentName)}");
            }
        }
    }
}