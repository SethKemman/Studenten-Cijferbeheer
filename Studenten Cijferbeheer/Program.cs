namespace Studenten_Cijferbeheer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Student> Studenten = new List<Student>();
            Repository<Persoon> Personen = new Repository<Persoon>();
            string[] Namen = { "Max", "Frans", "Jan" };
            foreach (string n in Namen)
            {
                Student student = new Student(n, 20); //temporary set all ages to 20.
                Studenten.Add(student);
                    for (int i = 0; i < 5; i++)
                    {
                        double min = 1, max = 10;
                        double randomDouble = rnd.NextDouble() * (max - min) + min; //https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
                        student.VoegCijferToe(Math.Round(randomDouble, 2));
                    }
            };
            foreach (Student student in Studenten)
            {
                //student.ToonInfo();
                //Console.WriteLine($"Totaal {student.AantalCijfers}");
            }

            Docent docent1 = new Docent("Henk");

            //docent1.ToonInfo();

            MasterStudent master1 = new MasterStudent("Superjan", 24);

            Klas Nieuweklas = new Klas();

            foreach (Student student in Studenten)
            {
                Nieuweklas.Personen.Add(student);
                Personen.Add(student);
            }
            //Nieuweklas.ToonKlas();

            //Persoon p = new MasterStudent("Patrick", 26); // Ik snap echt geen reet van die overriding vs hiding maar volgensmij klopt er ook niks van de tutorial / opdracht die op canvas staat. Ik kijk wel YT hiervoor. Moet nu alleen nog deel 4.
            //p.ToonInfo();

            //Student s = new MasterStudent("Luigi", 24);
            //s.Groet();

            //foreach (Student student in Personen.GetAll())
            //{
            //    Console.WriteLine(student.Naam);
            //    student.Groet();
            //}

            Persoon aapje = new Student("Aapie", 12); //oh ik heb hier uitgevogeld wat override vs new doet. Bij override runned de functie die in Student zit. Want aapje is variable Persoon maar object Student. Bij new runned de functie die in Persoon zit. Volgensmij heeft dit te maken met dat virtual > new maar dat weet ik niet. Zo iets vaags las ik.
            aapje.Groet();

            Helper.PrintAlles(Nieuweklas.Personen);
            Helper.PrintAlles(Studenten);
            Helper.PrintAlleNamen(Studenten);
            
        }
    }
}