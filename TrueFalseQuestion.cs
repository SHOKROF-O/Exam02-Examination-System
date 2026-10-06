namespace Exam02
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() : this("", 0, 1) { }

        public TrueFalseQuestion(string body, double mark, int rightAnswerId)
            : base("True | False Question", body, mark)
        {
            AnswerList = new Answer[] { new Answer(1, "True"), new Answer(2, "False") };
            RightAnswer = AnswerList[rightAnswerId - 1];
        }

        public override void CreateQuestion()
        {
            Console.WriteLine(Header);
            Body = Helper.ReadString("Please enter the body of the question: ");
            Mark = Helper.ReadDouble("Please enter the mark of the question: ", 1, 100);
            int rightId = Helper.ReadInt("Please enter the right answer (1 for True | 2 for False): ", 1, 2);
            RightAnswer = AnswerList[rightId - 1];
        }

        public override object Clone()
        {
            return new TrueFalseQuestion(Body, Mark, RightAnswer.AnswerId);
        }
    }
}
