using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
aaaaaaaaaa
namespace HNI_TPmoyennes
{
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }


        public Eleve(string prenomEleve, string nomEleve)
        {
            this.prenom = prenomEleve;
            this.nom = nomEleve;

            notes = new List<Note>();
        }

        public void ajouterNote(Note nouvelleNote) 
        {
            if (notes.Count < 200)
            {
                notes.Add(nouvelleNote);
            }
        }

        public double? moyenneMatiere(int numeroMatiere)
        {
            double sommeNotes = 0;
            int nombreNotes = 0;

            foreach (Note noteActuelle in notes)
            {
                if (noteActuelle.matiere == numeroMatiere)
                {
                    sommeNotes += noteActuelle.note;
                    nombreNotes++;
                }
            }

            if (nombreNotes == 0)
            {
                return null;
            }

            return Math.Truncate((sommeNotes / nombreNotes) * 100) / 100;
        }

        public double? moyenneGeneral()
        {
            double sommeMoyennes = 0;
            int nombreMatieres = 0;

            for (int numeroMatiere = 0; numeroMatiere < 10; numeroMatiere++)
            {
                double? moyenne = moyenneMatiere(numeroMatiere);

                if (moyenne != null)
                {
                    sommeMoyennes += moyenne.Value;
                    nombreMatieres++;
                }
            }

            if (nombreMatieres == 0)
            {
                return null;
            }

            return Math.Truncate((sommeMoyennes / nombreMatieres) * 100) / 100;
        }
    }
}
