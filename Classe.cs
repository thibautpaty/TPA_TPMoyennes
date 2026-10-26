using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public string NomClasse { get; private set; }
        public List<Eleve> Eleves { get; private set; }
        public List<string> Matieres { get; private set; }


        public Classe(string nomClasse)
        {
            this.NomClasse = nomClasse;
            Eleves = new List<Eleve>();
            Matieres = new List<string>();
        }

        public void ajouterEleve(string prenomEleve, string nomEleve) {
            if (Eleves.Count < 30)
            {

                Eleve nouvelEleve = new Eleve(prenomEleve, nomEleve);
                Eleves.Add(nouvelEleve);
            }

        }

        public void ajouterMatiere(string nomMatiere)
        {
            if (Matieres.Count < 10)
            {
                Matieres.Add(nomMatiere);
            }
            
        }

        public double? moyenneMatiere(int numeroMatiere)
        {
            double sommeMoyennes = 0;
            int nombreEleves = 0;

            foreach (Eleve eleveActuel in Eleves)
            {
                double? moyenne = eleveActuel.moyenneMatiere(numeroMatiere);

                if (moyenne != null)
                {
                    sommeMoyennes += moyenne.Value;
                    nombreEleves++;
                }
            }

            if (nombreEleves == 0)
            {
                return null;
            }

            return Math.Truncate((sommeMoyennes / nombreEleves) * 100) / 100;
        }


        public double? moyenneGeneral()
        {
            double sommeMoyennes = 0;
            int nombreMatieres = 0;

            for (int numeroMatiere = 0; numeroMatiere < Matieres.Count; numeroMatiere++)
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
