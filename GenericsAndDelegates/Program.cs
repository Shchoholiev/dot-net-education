namespace GenericsAndDelegates
{
    public delegate void PrintData<T>(T argument);

    public delegate TOut ProcessData<T, TOut>(T argument1, TOut argument2);

    public class Program
    {
        public static void Main()
        {
            var printData = new PrintData<int>(PrintNumber);
            printData += PrintNumberInRed;
            printData += PrintNumberWithDecoration;

            printData.Invoke(5);
            Console.WriteLine();

            var processData = new ProcessData<int, string>(JoinIntAndString);
            processData += JoinIntAndStringWithDecoration;

            Console.WriteLine(processData.Invoke(54, "Lorem ipsum"));

            Console.WriteLine();
            Console.WriteLine("---------------- Numbers Storage ---------------");
            var numbers = new List<int> { 9, 54, 2, 0, 24 };

            var numbersStorage = new DataStorage<int>(printData, numbers);
            numbersStorage.Execute(21);
            var filteredNumbers = numbersStorage.GetFilteredData(n => n > 5, n => n);
            foreach (var n in filteredNumbers)
            {
                Console.Write($" {n} ");
            }

            Console.WriteLine("\n");

            Func<int, int, int> sum = (int a, int b) => (a + b) / ((a + b) / 2);
            Console.WriteLine(sum.Invoke(10, 10));
        }

        public static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }

        public static void PrintNumberInRed(int number)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(number);
            Console.ForegroundColor = color;
        }

        public static void PrintNumberWithDecoration(int number)
        {
            Console.WriteLine($"It's an integer number ---> {number} <----");
        }

        public static string JoinIntAndString(int number, string text)
        {
            return text + $" {number}";
        }

        public static string JoinIntAndStringWithDecoration(int number, string text)
        {
            return "Text with number: " + text + $" {number}";
        }
    }
}