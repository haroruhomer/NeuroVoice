using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MLApp;

namespace NeuroVoice
{
    public partial class F_Entrenar : Form
    {
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
                DataTable dt=new DataTable();
                dt.Columns.Add("archivo");
                dt.Columns.Add("salida");
                DataRow row=dt.NewRow();
                TB_Carpeta.Text = fbd.SelectedPath;
                string[] archivos = System.IO.Directory.GetFiles(fbd.SelectedPath,"*.wav");
                foreach (String archivo in archivos)
                {
                    row[0] =System.IO.Path.GetFileName( archivo);
                    row[1] = "";
                    GV_Archivos.Rows.Add(row[0],row[1]);
                }
                    
//                    Console.WriteLine(ruta);
            }
            else
            {

            }
            fbd.Dispose();
        }

        private void B_Entrenar_Click(object sender, EventArgs e)
        {



            MLApp.MLApp matlab = new MLApp.MLApp();
            matlab.Visible = 0;
            Console.Out.WriteLine(@"cd " + Application.StartupPath);
            matlab.Execute(@"cd "+Application.StartupPath);
            short[,] salida=new short[GV_Archivos.Rows.Count,3];
            Double[,] patrones = new Double[GV_Archivos.Rows.Count,62];
            Double[,] aux;
            int index = 0;



            foreach (DataGridViewRow fila in GV_Archivos.Rows)
            {
                String archivo = fila.Cells["archivo"].Value.ToString();
                
                object valores=null;
                matlab.Feval("fftaudio",1,out valores, archivo);
                object[] val = valores as object[];
                Console.Out.WriteLine(val[0]);
                aux = (double[,])val[0];
                for (int i = 0; i <= 61; i++)
                {
                    patrones[index, i] = aux[0, i];
                }

                char letra = char.Parse(fila.Cells["salida"].Value.ToString()) ;

                switch(letra)
                {
                    case 'A':
                        salida[index, 0]=0;
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
            matlab.Quit();
            int[] sred=new int[3];//Estructura de red
            sred[0] = 62;//Capa entrada
            sred[1] = int.Parse(TB_Ocultas.Text);// Capa Oculta
            sred[2] = 3;//Capa Salida

        }
    }
}
