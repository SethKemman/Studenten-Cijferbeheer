using System;
using System.Collections.Generic;
using System.Text;

namespace Studenten_Cijferbeheer
{
    public class Student
    {
        public string Naam { get; private set; }
        private double[] _cijfers;
        public double[] Cijfers { get { return _cijfers; } set { _cijfers = value; } }
        private int aantalCijfers;

        public Student (string naam)
        {
            Naam = naam;
            _cijfers = new double[4];
        }

        ~Student()
        {
            Console.WriteLine($"Student {this.Naam} wordt opgeruimd");
        }

        public void VoegCijferToe(double cijfer)
        {
            bool succes = false;

            for (int i = 0; i < _cijfers.Length; i++) // loop door de variabelen heen
            {
                if (_cijfers[i] == 0)
                {
                    _cijfers[i] = cijfer;
                    succes = true;
                    aantalCijfers++;
                    break;
                }
            }
            if (succes != true) { Console.WriteLine($"Failed to add cijfer {cijfer}. No space left in array."); }
            
        }

        public double BerekenGemiddelde()
        {
            double total = 0;
            foreach (double cijfer in _cijfers)
            {
                total += cijfer;
            }
            double avg = (total /  aantalCijfers);

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

        public void ToonGegevens()
        {
            foreach (double cijfer in _cijfers)
            {
                Console.WriteLine($"{Naam}: {cijfer}");
            }
        }
    }
}
