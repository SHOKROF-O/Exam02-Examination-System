namespace Exam02
{
    public class MCQQuestion : Question
    {
        public MCQQuestion() : base("Choose One Answer Question", "", 0)
        {
            AnswerList = new Answer[3];
        }

        public MCQQuestion(string body, double mark, Answer[] answerList, Answer rightAnswer)
            : base("Choose One Answer Question", body, mark, answerList, rightAnswer) { }

        public override void CreateQuestion()
        {
            Console.WriteLine(Header);
            Body = Helper.ReadString("Please enter the body of the question: ");
            Mark = Helper.ReadDouble("Please enter the mark of the question: ", 1, 100);

            Console.WriteLine("The choices of the question:");
            for (int i = 0; i < AnswerList.Length; i++)
            {
                string text = Helper.ReadString($"Please enter choice number {i + 1}: ");
                AnswerList[i] = new Answer(i + 1, text);
            }

            int rightId = Helper.ReadInt($"Please enter the right answer id (1 - {AnswerList.Length}): ", 1, AnswerList.Length);
            RightAnswer = AnswerList[rightId - 1];
        }

        public override object Clone()
        {
            // deep copy for the answers
            Answer[] copy = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
                copy[i] = (Answer)AnswerList[i].Clone();

            return new MCQQuestion(Body, Mark, copy, copy[RightAnswer.AnswerId - 1]);
        }
    }
}
