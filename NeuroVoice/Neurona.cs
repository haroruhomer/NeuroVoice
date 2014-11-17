using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NeuroVoice
{
    class Neurona
    {
        public double net { get; set; }
        public TipoNeurona tipo { get; set; }
        public double salida { get; set; }
        public double[] pesos { get; set; }
        public double error { get; set; }

        public Neurona(int entradas)
        {
            pesos = new double[entradas];
        }

        public void InicializarPesos(Random rndm)
        {
            for (int i = 0; i < pesos.Length; i++)
            {
                pesos[i] = rndm.NextDouble();
                rndm.NextDouble();
                rndm.NextDouble();
            }
        }

        public void CalcularNet(ref double[,] input, int i)
        {
            for (int j = 0; j < input.GetLength(1); j++)
            {
                this.net += input[i, j] * pesos[j];
            }
            CalcularSalida();
        }
        public void CalcularNet(ref Neurona[] hidden)
        {
            for (int j = 0; j < hidden.GetLength(0); j++)
            {
                this.net += hidden[j].salida * pesos[j];
            }
            CalcularSalida();
        }

        private void CalcularSalida()
        {
            salida = (1 / (1 + Math.Pow(Math.E, -net)));
        }

        public void CalcularError(short deseado)
        {
            this.error=(deseado-salida)*(salida*(1-salida));
        }

        public void CalcularError(ref Neurona[] output, int peso)
        {
            double sum = 0;
            for (int i=0;i<output.GetLength(0) ;i++ )
            {
                sum+=output[i].error*output[i].pesos[peso];
            }
            error = salida * (1 - salida) * sum;
        }

        public void ActualizaPesos(double alfa, double beta,ref double[,] entrada, int neurona)
        {
            for (int l = 0; l < entrada.GetLength(1); l++)
            {
                pesos[l] = beta * ((pesos[l] + (alfa * error * entrada[neurona,l])) - pesos[l]);
            }
        }

        public void ActualizaPesos(double alfa, double beta, ref Neurona[] entrada)
        {
            for (int l = 0; l < entrada.GetLength(0); l++)
            {
                pesos[l] = beta * ((pesos[l] + (alfa * error * entrada[l].salida)) - pesos[l]);
            }
        }
    }
}