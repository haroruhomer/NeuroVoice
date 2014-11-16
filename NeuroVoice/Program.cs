using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroVoice
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            F_Inicio inicio = new F_Inicio();
            inicio.ShowDialog();
            if (inicio.DialogResult == DialogResult.OK)
                Application.Run(new F_Evaluar());
            else
                Application.Run(new F_Entrenar());
        }
    }
}
