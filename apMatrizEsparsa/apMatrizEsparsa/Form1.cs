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
            
        }

        private void btnLerMatrizA_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizA, dgvA);
        }


        private void LerMatriz(ref ListaCruzada lista, DataGridView dgv)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);

                string numeroLinhaColuna = arquivo.ReadLine();

                lista = new ListaCruzada(int.Parse(numeroLinhaColuna.Substring(0, 5)), int.Parse(numeroLinhaColuna.Substring(5, 5)));

                dgv.ColumnCount = int.Parse(numeroLinhaColuna.Substring(0, 5));
                dgv.RowCount = int.Parse(numeroLinhaColuna.Substring(5, 5));

                while (!arquivo.EndOfStream)
                {
                    Celula lida = Celula.LerRegistro(arquivo);
                    //lista.InserirElemento(lida.Linha, lida.Coluna, lida.Valor);

                    dgv[lida.Coluna - 1, lida.Linha].Value = lida.Valor;
                }
                arquivo.Close();
               // lista.Listar(dgv);
            }

            //if(dlgAbrir.ShowDialog() == DialogResult.OK)
            //{                
            //    var arquivo = new StreamReader(dlgAbrir.FileName);

            //    string numeroLinhaColuna = arquivo.ReadLine();

            //    lista = new ListaCruzada(int.Parse(numeroLinhaColuna.Substring(0,5)), int.Parse(numeroLinhaColuna.Substring(5,5)));

            //    while (!arquivo.EndOfStream)
            //    {
            //        Celula lida = Celula.LerRegistro(arquivo);
            //        lista.InserirElemento(lida.Linha, lida.Coluna, lida.Valor);
            //    }
            //    arquivo.Close();
            //    lista.Listar(dgv);
            //}
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizB, dgvB);
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)
        {
            matrizA.SomarMatrizes(matrizB);
        }

        private void btnSomarColuna_Click(object sender, EventArgs e)
        {

        }
    }
}
