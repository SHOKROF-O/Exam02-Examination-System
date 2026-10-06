namespace Exam02
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject) { }

        // practical exam has MCQ questions only
        public override void CreateQuestions()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}");
                Questions[i] = new MCQQuestion();
                Questions[i].CreateQuestion();
                Console.Clear();
            }
        }

        // Practical exam shows the right answers after finishing
        public override void ShowExam()
        {
            TakeExam();

            Console.WriteLine("Right Answers:");
            for (int i = 0; i < Questions.Length; i++)
                Console.WriteLine($"Q{i + 1}) {Questions[i].Body} : {Questions[i].RightAnswer.AnswerText}");
        }
    }
}
