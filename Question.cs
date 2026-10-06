namespace Exam02
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer? UserAnswer { get; set; }

        protected Question(string header, string body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[0];
            RightAnswer = new Answer(0, "");
        }

        // constructor chaining
        protected Question(string header, string body, double mark, Answer[] answerList, Answer rightAnswer)
            : this(header, body, mark)
        {
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        public bool IsCorrect
        {
            get { return UserAnswer != null && UserAnswer.AnswerId == RightAnswer.AnswerId; }
        }

        // every question type reads its data in a different way
        public abstract void CreateQuestion();

        public abstract object Clone();

        // compare questions by mark
        public int CompareTo(Question? other)
        {
            if (other is null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            string result = $"{Header}\t\tMark: {Mark}\n{Body}\n";
            foreach (Answer answer in AnswerList)
                result += answer + "    ";
            return result;
        }
    }
}
