namespace Exam02
{
    // helper methods to read input safely from the user
    public static class Helper
    {
        public static int ReadInt(string message, int min, int max)
        {
            int value;
            bool ok;
            do
            {
                Console.Write(message);
                ok = int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max;
                if (!ok) Console.WriteLine($"Please enter a number between {min} and {max}");
            } while (!ok);
            return value;
        }

        public static double ReadDouble(string message, double min, double max)
        {
            double value;
            bool ok;
            do
            {
                Console.Write(message);
                ok = double.TryParse(Console.ReadLine(), out value) && value >= min && value <= max;
                if (!ok) Console.WriteLine($"Please enter a number between {min} and {max}");
            } while (!ok);
            return value;
        }

        public static string ReadString(string message)
        {
            string? value;
            do
            {
                Console.Write(message);
                value = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(value));
            return value.Trim();
        }
    }
}
