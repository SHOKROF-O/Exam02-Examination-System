namespace Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "C#");
            subject.CreateExam();
            Console.Clear();

            string choice;
            do
            {
                choice = Helper.ReadString("Do you want to start the exam (Y | N): ").ToUpper();
            } while (choice != "Y" && choice != "N");

            if (choice == "Y" && subject.Exam != null)
            {
                Console.Clear();
                Console.WriteLine(subject.Exam);
                Console.WriteLine();
                subject.Exam.ShowExam();
            }

            Console.WriteLine("\nThank you");
        }
    }
}
