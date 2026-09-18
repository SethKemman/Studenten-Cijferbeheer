namespace Studenten_Cijferbeheer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Student> Studenten = new List<Student>();
            string[] Namen = { "Max", "Frans", "Jan" };
            foreach (string n in Namen)
            {
                Student student = new Student(n);
                Studenten.Add(student);
                for (int i = 0; i < student.Cijfers.Length; i++)
                {
                    double min = 1, max = 10;
                    double randomDouble = rnd.NextDouble() * (max - min) + min; //https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
                    student.VoegCijferToe(Math.Round(randomDouble, 2));
                }
            }
            foreach (Student student in Studenten)
            {
                student.ToonGegevens();
            }

        }
    }
}