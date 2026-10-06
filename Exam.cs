using System.Diagnostics;

namespace Exam02
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }   // in minutes
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }

        protected Exam(int time, int numberOfQuestions, Subject subject)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Questions = new Question[numberOfQuestions];
        }

        public abstract void CreateQuestions();

        // different for every exam type
        public abstract void ShowExam();

        public double TotalMarks
        {
            get
            {
                double total = 0;
                foreach (Question q in Questions) total += q.Mark;
                return total;
            }
        }

        public double Grade
        {
            get
            {
                double grade = 0;
                foreach (Question q in Questions)
                    if (q.IsCorrect) grade += q.Mark;
                return grade;
            }
        }

        // shared part: show questions one by one and take the user answers
        protected void TakeExam()
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1} of {Questions.Length}");
                Console.WriteLine(Questions[i]);
                Console.WriteLine("----------------------------------------");

                int id = Helper.ReadInt("Your answer: ", 1, Questions[i].AnswerList.Length);
                Questions[i].UserAnswer = Questions[i].AnswerList[id - 1];
                Console.Clear();

                if (sw.Elapsed.TotalMinutes > Time)
                {
                    Console.WriteLine("Time is over!");
                    break;
                }
            }

            sw.Stop();
            Console.WriteLine($"Time taken: {sw.Elapsed:hh\\:mm\\:ss}\n");
        }

        public object Clone()
        {
            Exam copy = (Exam)MemberwiseClone();
            copy.Questions = new Question[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
                copy.Questions[i] = (Question)Questions[i].Clone();
            return copy;
        }

        // compare exams by time
        public int CompareTo(Exam? other)
        {
            if (other is null) return 1;
            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return $"{GetType().Name} | Subject: {Subject.SubjectName} | Time: {Time} min | Questions: {NumberOfQuestions}";
        }
    }
}
