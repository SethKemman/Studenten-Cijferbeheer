using System;
using System.Collections.Generic;
using System.Text;

namespace Studenten_Cijferbeheer
{
    public abstract class Persoon
    {
        public string Naam { get; set; } // Het is handig als andere classes en code wel kunnen lezen wat de naam van de student is. Maar ze hoeven het niet aan te kunnen passen. Daarom een private set.
        public int Leeftijd { get; set; } 

        public virtual void ToonInfo()
        {
            Console.WriteLine("Toont info vanuit de masterstudent");
        }

        public virtual void Groet()
        {
            Console.WriteLine($"Hoi ik ben {Naam}");
        }
    }
    class Student : Persoon
    {

        protected double Gemiddelde  // Gemiddelde van de student hoeft niet voor iedereen zichtbaar te zijn. Zelfde als Cijfers.
        { 
            get
            {
                double avg = BerekenGemiddelde();
                return avg;
            } 
        }
        protected List<double> Cijfers = new List<double>(); // Zelfde als gemiddelde.
        public int AantalCijfers
        {
            get
            {
                return Cijfers.Count;
            }
        }

        public Student (string naam, int leeftijd) // Hier wordt geen base in de constructor gebruikt, omdat de abstract class persoon geen constructor heeft.
        {
            Naam = naam;
            Leeftijd = leeftijd;
        }

        ~Student()
        {
            Console.WriteLine($"Student {this.Naam} wordt opgeruimd");
        }

        public void VoegCijferToe(double cijfer)
        {
            Cijfers.Add(cijfer);
        }

        public double BerekenGemiddelde()
        {
            double total = 0;
            foreach (double cijfer in Cijfers)
            {
                total += cijfer;
            }
            double avg = (total /  AantalCijfers);

            return avg;
        }

        public string GeefResultaat()
        {
            double avg = BerekenGemiddelde();

            if (avg >= 5.5)
            {
                return "Geslaagd";
            }
            else
            {
                return "Gezakt";
            }
        }

        public override void ToonInfo()
        {
            foreach (double cijfer in Cijfers)
            {
                Console.WriteLine($"{Naam}, {Leeftijd}: {cijfer}");
                Console.WriteLine("Toont info vanuit de Student");
            }
        }

        public override void Groet()
        {
            Console.WriteLine($"Hoi ik ben student {Naam}");
        }
    }
    
    class Docent : Persoon
    {
        public string vak { get; private set; } // Het vak van de docent mag intern nog wel veranderd worden. Er is hier alleen nog geen functie voor. Maar vandaar private set en niet read only.
        public Docent(string naam)
        {
            this.Naam = naam;
            vak = "ICT";
        }

        public override void ToonInfo()
        {
            Console.WriteLine($"{this.Naam} geeft {this.vak}");
        }
    }

    class MasterStudent : Student // MasterStudent is een Student.
    {
        public string scriptietitel { get; } // Een MasterStudent heeft een scriptietitel. Hij is geen scriptietitel.

        public MasterStudent(string naam, int leeftijd) : base (naam, leeftijd) //Deze base functie wordt gebruikt om de constructor van student aan te roepen. De constructor van student vraagt namelijk om een naam en leeftijd. Gezien een masterstudent gebasseerd is op een student, is het logisch dat deze constructor eerst moet worden aangeroepen.
        {
            Naam = naam;
            Leeftijd = leeftijd;
            scriptietitel = "Mooie titel template";
        }

        public new void ToonInfo()
        {
            Console.WriteLine("Toont info vanuit de masterstudent");
        }
    }

    class Klas
    {
        public List<Persoon> Personen = new List<Persoon>();
        public Klas()
        {

        }

        public void ToonKlas()
        {
            foreach(Persoon o in Personen)
            {
                Console.WriteLine(o.Naam);
            }
        }
    }

    public class Repository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item) { items.Add(item); }
        public T GetAt(int index) { return items[index]; }
        public int Count => items.Count;
        public List<T> GetAll() { return items; }
    }

    public static class Helper
    {
        public static void PrintAlles<T>(List<T> lijst)
        {
            foreach (T item in lijst)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintAlleNamen<T>(List<T> lijst) where T : Persoon
        {
            foreach (T item in lijst)
            {
                Console.WriteLine(item.Naam);
            }
        }
        public static T GetGrootste<T>(List<T> lijst) where T : IComparable<T>
        {
            T grootste = lijst[0];
            foreach (T item in lijst)
            {
                if (item.CompareTo(grootste) > 0)
                    grootste = item;
            }
            return grootste;
        }
    }
}
