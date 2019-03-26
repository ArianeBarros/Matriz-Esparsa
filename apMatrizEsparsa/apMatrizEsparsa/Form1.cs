using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace apMatrizEsparsa
{
    public partial class frmMatriz : Form
    {
        ListaCruzada matrizA;
        ListaCruzada matrizB;
        public frmMatriz()
        {
            InitializeComponent();
        }

        private void frmMatriz_Load(object sender, EventArgs e)
        {
            // matrizEsparsa = new ListaCruzada();
        }

        private void btnLerMatrizA_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizA, dgvA);
        }


        public void LerMatriz(ref ListaCruzada lista, DataGridView dgv)
        {
            if(dlgAbrir.ShowDialog() == DialogResult.OK)
            {                
                var arquivo = new StreamReader(dlgAbrir.FileName);
                lista = new ListaCruzada();  

                while (!arquivo.EndOfStream)
                {
                    Celula lida = Celula.LerRegistro(arquivo);
                    
                }
                arquivo.Close();
                lista.Listar(dgv);
            }
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizB, dgvB);
        }
    }
}
