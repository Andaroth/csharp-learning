namespace Utils {
    class Numbers {
        public static bool isNaN<T>(T input) {
            string parse = string.Join("",input);
            return !Decimal.TryParse(parse, out _);
        }
    }
}