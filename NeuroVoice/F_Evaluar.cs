using System;
using System.Collections;
using System.Windows.Forms;

namespace NeuroVoice
{
    public partial class F_Evaluar : Form
    {
        Neurona[] hidden,output;
        String archivo = String.Empty;
        ArrayList al;

        public F_Evaluar()
        {
            InitializeComponent();
        }

        public F_Evaluar(Neurona[] hidd, Neurona[] outp)
        {
            InitializeComponent();

            this.hidden = new Neurona[hidd.Length];
            hidden = hidd;
            for (int i = 0; i < hidden.Length; i++)
            {
                hidden[i].salida = 0.0;
                hidden[i].net = 0.0;
            }
            this.output = new Neurona[outp.Length];
            output = outp;
            for (int j = 0; j < output.Length; j++)
            {
                output[j].salida = 0.0;
                output[j].net = 0.0;
            }
        }

        private void F_Evaluar_Load(object sender, EventArgs e)
        {
            al = (ArrayList)Properties.Settings.Default.Neuro;
        }

        private void B_Examinar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Archivos WAV (*.wav)|*.wav";
            fd.Multiselect=false;
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                archivo = fd.FileName;
                L_Archivo.Text = System.IO.Path.GetFileName(fd.FileName);
                L_Archivo.Visible = true;
                B_Reconocer.Visible = true;
                WMP_Reproductor.Visible = true;
                WMP_Reproductor.URL = fd.FileName;
            }
            else 
            {
                MessageBox.Show("No selecciono ningun archivo");
            }
        }

        private void B_Reconocer_Click(object sender, EventArgs e)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();
            double[,] aux;
            matlab.Visible = 0;
            matlab.Execute(@"cd " + Application.StartupPath);

            object valores = null;
            matlab.Feval("fftaudio", 1, out valores, archivo);
            object[] val = valores as object[];
            aux = (double[,])val[0];
            double[] input = new double[aux.GetLength(1)];
            for (int i = 0; i < 16; i++)
                {
                    input[i] = aux[0, i];
                }
            matlab.Quit();

            for (int i = 0; i < hidden.GetLength(0); i++)
            {
                hidden[i].CalcularNet(input);
            }

            for (int j = 0; j < output.GetLength(0); j++)
            {
                output[j].CalcularNet(hidden);
            }

            if (output[0].salida < 0.5 && output[1].salida < 0.5 && output[2].salida < 0.5)
            {
                label2.Text = "A";
            }
            if (output[0].salida < 0.5 && output[1].salida < 0.5 && output[2].salida > 0.5)
            {
                label2.Text = "E";
            }
            if (output[0].salida < 0.5 && output[1].salida > 0.5 && output[2].salida < 0.5)
            {
                label2.Text = "I";
            }
            if (output[0].salida < 0.5 && output[1].salida > 0.5 && output[2].salida > 0.5)
            {
                label2.Text = "O";
            }
            if (output[0].salida > 0.5 && output[1].salida < 0.5 && output[2].salida < 0.5)
            {
                label2.Text = "U";
            }
        }
    }
}
