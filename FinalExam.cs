namespace Exam02
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject) { }

        public override void CreateQuestions()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}");
                int type = Helper.ReadInt("Please enter the type of question (1 for True | False, 2 for MCQ): ", 1, 2);

                if (type == 1)
                    Questions[i] = new TrueFalseQuestion();
                else
                    Questions[i] = new MCQQuestion();

                Questions[i].CreateQuestion();
                Console.Clear();
            }
        }

        // Final exam shows the questions, the answers and the grade
        public override void ShowExam()
        {
            TakeExam();

            Console.WriteLine("Your Answers:");
            for (int i = 0; i < Questions.Length; i++)
            {
                string userAnswer = Questions[i].UserAnswer?.AnswerText ?? "Not answered";
                Console.WriteLine($"Q{i + 1}) {Questions[i].Body} : {userAnswer}");
            }

            Console.WriteLine($"\nYour Grade is {Grade} from {TotalMarks}");
        }
    }
}
