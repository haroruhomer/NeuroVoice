using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;


namespace NeuroVoice
{
    public partial class F_Entrenar : Form
    {
        Neurona[] hidden, output;

        public F_Entrenar()
        {
            InitializeComponent();
        }

        private void B_Examinar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Application.StartupPath;
            fbd.ShowNewFolderButton = false;


            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("archivo");
                dt.Columns.Add("salida");
                DataRow row = dt.NewRow();
                TB_Carpeta.Text = fbd.SelectedPath;
                string[] archivos = System.IO.Directory.GetFiles(fbd.SelectedPath, "*.wav");
                foreach (String archivo in archivos)
                {
                    row[0] = System.IO.Path.GetFileName(archivo);
                    row[1] = "";
                    GV_Archivos.Rows.Add(row[0], row[1]);
                }

                //                    Console.WriteLine(ruta);
            }
            else
            {

            }
            B_Entrenar.Visible = true;
            fbd.Dispose();
        }

        private void B_Entrenar_Click(object sender, EventArgs e)
        {
            double errora = 0;
            MLApp.MLApp matlab = new MLApp.MLApp();
            matlab.Visible = 0;
            matlab.Execute(@"cd " + Application.StartupPath);
            short[,] salida = new short[GV_Archivos.Rows.Count, 3];
            Double[,] input = new Double[GV_Archivos.Rows.Count, 16];
            Double[,] aux;
            int index = 0;
            Random rndm = new Random();
            double alfa = 0.2,beta=0.8;
            

            foreach (DataGridViewRow fila in GV_Archivos.Rows)
            {
                String archivo = fila.Cells["archivo"].Value.ToString();

                object valores = null;
                matlab.Feval("fftaudio", 1, out valores, archivo);
                object[] val = valores as object[];
                aux = (double[,])val[0];
                for (int i = 0; i < 16; i++)
                {
                    input[index, i] = aux[0, i];
                }

                char letra = char.Parse(fila.Cells["salida"].Value.ToString());

                switch (letra)
                {
                    case 'A':
                        salida[index, 0] = 0;
                        salida[index, 1] = 0;
                        salida[index, 2] = 0;
                        break;
                    case 'E':
                        salida[index, 0] = 0;
                        salida[index, 1] = 0;
                        salida[index, 2] = 1;
                        break;
                    case 'I':
                        salida[index, 0] = 0;
                        salida[index, 1] = 1;
                        salida[index, 2] = 0;
                        break;
                    case 'O':
                        salida[index, 0] = 0;
                        salida[index, 1] = 1;
                        salida[index, 2] = 1;
                        break;
                    case 'U':
                        salida[index, 0] = 1;
                        salida[index, 1] = 0;
                        salida[index, 2] = 0;
                        break;
                }

                index++;

            }
            matlab.Visible = 1;
            matlab.Quit();

            int[] sred = new int[3];//Estructura de red
            sred[0] = 16;//Capa entrada
            sred[1] = int.Parse(TB_Ocultas.Text);// Capa Oculta
            sred[2] = 3;//Capa Salida

            Neurona[] hidden = new Neurona[sred[1]];
            Neurona[] output = new Neurona[sred[2]];

            for (int j = 0; j < sred[1]; j++)
            {
                hidden[j] = new Neurona(sred[0]);
                hidden[j].InicializarPesos(rndm);
            }

            for (int k = 0; k < sred[2]; k++)
            {
                output[k] = new Neurona(sred[1]);
                output[k].InicializarPesos(rndm);
            }

            int MaxIte = 2000;
            int ite = 0;
            int numPatron = 0;

            while (numPatron < input.GetLength(0) && ite<MaxIte)
            {
                for (int i = 0; i < hidden.GetLength(0); i++)
                {
                    hidden[i].CalcularNet(ref input, numPatron);
                }
                //
                for (int j = 0; j < output.GetLength(0); j++)
                {
                    output[j].CalcularNet(hidden);
                }

                for (int k = 0; k< output.GetLength(0); k++)
                {
                    output[k].CalcularError(salida[numPatron, k]);           
                    output[k].ActualizaPesos(alfa, beta,ref hidden);
                }
                for (int l=0;l<hidden.GetLength(0) ;l++ )
                {
                    hidden[l].CalcularError(ref output,l);
                    hidden[l].ActualizaPesos(alfa, beta, ref input, numPatron);
                }
                double errorG=0.0;
                    for(int eg=0;eg<output.GetLength(0);eg++)
                    {
                        errorG+=Math.Pow(output[eg].error,2);
                    }
                    errorG *= 0.5;
                  
                    if (errorG == errora)
                        
                    {
                        TB_Info.AppendText("\nPatron-" + numPatron + "-iteracion-" + ite + "\n");
                        TB_Info.AppendText("\tSalida1-" + output[0].salida + "\r\n" + "\t-Salida2-" + output[1].salida + "\r\n" + "\t-Salida3-" + output[2].salida + "\n" + "\n");
                        numPatron++;
                    }
                    //Console.Out.WriteLine("\nPatron-" + numPatron + "-iteracion-" + ite + "\n");
                    //Console.Out.WriteLine("\tSalida1-" + output[0].salida + "\r\n" + "\t-Salida2-" + output[1].salida + "\r\n" + "\t-Salida3-" + output[2].salida + "\n" + "\n");
                    //numPatron++;
                    //if (numPatron >= input.GetLength(0))
                    //    numPatron = 0;

                    
                    errora = errorG;
                    ite++;                
            }
            this.hidden = hidden;
            this.output = output;
            ArrayList al=new ArrayList();
            al.Add((object)hidden);
            al.Add((object)output);
            Properties.Settings.Default.Neuro = al;
            Properties.Settings.Default.Neuronas = 0.4;
            Properties.Settings.Default.Save();
             Console.Out.WriteLine("Fin");
        }

        private void TB_Ocultas_MouseHover(object sender, EventArgs e)
        {
            L_RecoOcultas.Visible = true;
        }

        private void TB_Ocultas_MouseLeave(object sender, EventArgs e)
        {
            L_RecoOcultas.Visible = false;
        }

        private void B_Evaluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_Evaluar fEvaluar = new F_Evaluar(hidden, output);
            fEvaluar.Show(this);
            this.Show();
        }
    }
}