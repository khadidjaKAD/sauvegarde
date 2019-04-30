using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSave
{
    [Serializable]
    public class File
    {
        public String nom { get; set; }

        public File(String nom)
        {
            this.nom = nom;
        }

    }
}
