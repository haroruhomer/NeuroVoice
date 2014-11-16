using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroImage
{
    class Neurona
    {
        public double net { get; set; }
        public TipoNeurona tipo { get; set; }
        public double salida { get; set; }
        public double[] wAct { get; set; }
        public double delta { get; set; }

        public Neurona()
        {  

        }

        public Neurona(double net)
        {

        }

        public void AñadirPeso() 
        {
            throw new NotImplementedException();
        }
    }
}
