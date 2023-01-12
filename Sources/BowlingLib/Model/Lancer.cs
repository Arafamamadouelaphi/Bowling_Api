using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Lancer
    {
        private int quillesTombees;

        public  int QuillesTombees
        {
            get { return quillesTombees; }
           private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Le nombre de quilles tombees doit etre compris entre 0 et 10");
                }
                quillesTombees = value;
            }
        }

        public Lancer(int quillesTombees)
        {
            this.quillesTombees = quillesTombees;
        }



    }
}
