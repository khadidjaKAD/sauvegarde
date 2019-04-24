using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSave
{
    [Serializable] // pour dire qu'elle peut etre sauvegarder
    public class Memoire
    {
        public List<Processus> mem { get; set; }
        public int taille { get; set; }

        public Memoire(int taille)
        {
            this.taille = taille;
            mem = new List<Processus>();
        }
            
    }
}
