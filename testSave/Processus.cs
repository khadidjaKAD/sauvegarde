using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSave
{
    [Serializable]  // pour dire qu'elle peut etre sauvegarder
    public class Processus
    {
        public String nom { get; set; }
        public int taille { get; set; }
        public Boolean etat { get; set; }
        public int adresse { get; set; }

        public Processus (String nom, int t, Boolean etat, int adr)
        {
            this.nom = nom;
            taille = t;
            this.etat = etat;
            adresse = adr;
        }
    }
}
