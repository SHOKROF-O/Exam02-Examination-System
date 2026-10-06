namespace Exam02
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            int type = Helper.ReadInt("Please enter the type of exam (1 for Practical | 2 for Final): ", 1, 2);
            int time = Helper.ReadInt("Please enter the time of exam in minutes (30 - 180): ", 30, 180);
            int count = Helper.ReadInt("Please enter the number of questions: ", 1, 100);

            if (type == 1)
                Exam = new PracticalExam(time, count, this);
            else
                Exam = new FinalExam(time, count, this);

            Console.Clear();
            Exam.CreateQuestions();
        }

        public override string ToString()
        {
            return $"Subject Id: {SubjectId} | Name: {SubjectName}";
        }
    }
}
