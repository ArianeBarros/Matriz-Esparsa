namespace apMatrizEsparsa
{
    partial class frmMatriz
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvB = new System.Windows.Forms.DataGridView();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.btnMultiplicarMatrizes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSomarMatrizes = new System.Windows.Forms.Button();
            this.btnLerMatrizA = new System.Windows.Forms.Button();
            this.btnLerMatrizB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxColuna = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSomarColuna = new System.Windows.Forms.Button();
            this.rgbMB = new System.Windows.Forms.RadioButton();
            this.txtSomar = new System.Windows.Forms.TextBox();
            this.rgbMA = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtColuna = new System.Windows.Forms.TextBox();
            this.txtLinha = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.txtErro = new System.Windows.Forms.ToolStrip();
            this.lblErro = new System.Windows.Forms.ToolStripLabel();
            this.btnExcluirMatriz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.txtErro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvB
            // 
            this.dgvB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvB.Location = new System.Drawing.Point(367, 100);
            this.dgvB.Name = "dgvB";
            this.dgvB.Size = new System.Drawing.Size(332, 193);
            this.dgvB.TabIndex = 0;
            this.dgvB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvB_CellContentClick);
            // 
            // dgvA
            // 
            this.dgvA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvA.Location = new System.Drawing.Point(12, 100);
            this.dgvA.Name = "dgvA";
            this.dgvA.Size = new System.Drawing.Size(332, 193);
            this.dgvA.TabIndex = 1;
            this.dgvA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvA_CellClick);
            this.dgvA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvA_CellContentClick);
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(741, 28);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.Size = new System.Drawing.Size(359, 265);
            this.dgvResultado.TabIndex = 2;
            // 
            // btnMultiplicarMatrizes
            // 
            this.btnMultiplicarMatrizes.Enabled = false;
            this.btnMultiplicarMatrizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplicarMatrizes.Location = new System.Drawing.Point(6, 172);
            this.btnMultiplicarMatrizes.Name = "btnMultiplicarMatrizes";
            this.btnMultiplicarMatrizes.Size = new System.Drawing.Size(233, 108);
            this.btnMultiplicarMatrizes.TabIndex = 6;
            this.btnMultiplicarMatrizes.Text = "Multiplicar Matrizes";
            this.btnMultiplicarMatrizes.UseVisualStyleBackColor = true;
            this.btnMultiplicarMatrizes.Click += new System.EventHandler(this.btnMultiplicarMatrizes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMultiplicarMatrizes);
            this.groupBox1.Controls.Add(this.btnSomarMatrizes);
            this.groupBox1.Location = new System.Drawing.Point(741, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 286);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multiplicar";
            // 
            // btnSomarMatrizes
            // 
            this.btnSomarMatrizes.Enabled = false;
            this.btnSomarMatrizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSomarMatrizes.Location = new System.Drawing.Point(6, 19);
            this.btnSomarMatrizes.Name = "btnSomarMatrizes";
            this.btnSomarMatrizes.Size = new System.Drawing.Size(233, 108);
            this.btnSomarMatrizes.TabIndex = 6;
            this.btnSomarMatrizes.Text = "Somar Matrizes";
            this.btnSomarMatrizes.UseVisualStyleBackColor = true;
            this.btnSomarMatrizes.Click += new System.EventHandler(this.btnSomarMatrizes_Click);
            // 
            // btnLerMatrizA
            // 
            this.btnLerMatrizA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLerMatrizA.Location = new System.Drawing.Point(12, 28);
            this.btnLerMatrizA.Name = "btnLerMatrizA";
            this.btnLerMatrizA.Size = new System.Drawing.Size(332, 40);
            this.btnLerMatrizA.TabIndex = 11;
            this.btnLerMatrizA.Text = "Ler Matriz A";
            this.btnLerMatrizA.UseVisualStyleBackColor = true;
            this.btnLerMatrizA.Click += new System.EventHandler(this.btnLerMatrizA_Click);
            // 
            // btnLerMatrizB
            // 
            this.btnLerMatrizB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLerMatrizB.Location = new System.Drawing.Point(367, 28);
            this.btnLerMatrizB.Name = "btnLerMatrizB";
            this.btnLerMatrizB.Size = new System.Drawing.Size(332, 40);
            this.btnLerMatrizB.TabIndex = 12;
            this.btnLerMatrizB.Text = "Ler Matriz B";
            this.btnLerMatrizB.UseVisualStyleBackColor = true;
            this.btnLerMatrizB.Click += new System.EventHandler(this.btnLerMatrizB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxColuna);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSomarColuna);
            this.groupBox2.Controls.Add(this.rgbMB);
            this.groupBox2.Controls.Add(this.txtSomar);
            this.groupBox2.Controls.Add(this.rgbMA);
            this.groupBox2.Location = new System.Drawing.Point(414, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 286);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Somar";
            // 
            // cbxColuna
            // 
            this.cbxColuna.FormattingEnabled = true;
            this.cbxColuna.Location = new System.Drawing.Point(99, 196);
            this.cbxColuna.Name = "cbxColuna";
            this.cbxColuna.Size = new System.Drawing.Size(77, 21);
            this.cbxColuna.TabIndex = 18;
            this.cbxColuna.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Valor: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Coluna: ";
            // 
            // btnSomarColuna
            // 
            this.btnSomarColuna.Enabled = false;
            this.btnSomarColuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSomarColuna.Location = new System.Drawing.Point(94, 41);
            this.btnSomarColuna.Name = "btnSomarColuna";
            this.btnSomarColuna.Size = new System.Drawing.Size(82, 53);
            this.btnSomarColuna.TabIndex = 5;
            this.btnSomarColuna.Text = "Somar Coluna";
            this.btnSomarColuna.UseVisualStyleBackColor = true;
            this.btnSomarColuna.Click += new System.EventHandler(this.btnSomarColuna_Click);
            // 
            // rgbMB
            // 
            this.rgbMB.AutoSize = true;
            this.rgbMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbMB.Location = new System.Drawing.Point(152, 113);
            this.rgbMB.Name = "rgbMB";
            this.rgbMB.Size = new System.Drawing.Size(85, 24);
            this.rgbMB.TabIndex = 10;
            this.rgbMB.TabStop = true;
            this.rgbMB.Text = "Matriz B";
            this.rgbMB.UseVisualStyleBackColor = true;
            this.rgbMB.Visible = false;
            this.rgbMB.CheckedChanged += new System.EventHandler(this.rgbMB_CheckedChanged);
            // 
            // txtSomar
            // 
            this.txtSomar.Location = new System.Drawing.Point(108, 237);
            this.txtSomar.Name = "txtSomar";
            this.txtSomar.Size = new System.Drawing.Size(149, 20);
            this.txtSomar.TabIndex = 9;
            // 
            // rgbMA
            // 
            this.rgbMA.AutoSize = true;
            this.rgbMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbMA.Location = new System.Drawing.Point(30, 113);
            this.rgbMA.Name = "rgbMA";
            this.rgbMA.Size = new System.Drawing.Size(85, 24);
            this.rgbMA.TabIndex = 9;
            this.rgbMA.TabStop = true;
            this.rgbMA.Text = "Matriz A";
            this.rgbMA.UseVisualStyleBackColor = true;
            this.rgbMA.Visible = false;
            this.rgbMA.CheckedChanged += new System.EventHandler(this.rgbMA_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeletar);
            this.groupBox3.Controls.Add(this.btnIncluir);
            this.groupBox3.Controls.Add(this.btnAlterar);
            this.groupBox3.Controls.Add(this.txtColuna);
            this.groupBox3.Controls.Add(this.txtLinha);
            this.groupBox3.Controls.Add(this.txtValor);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 286);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operações";
            // 
            // btnDeletar
            // 
            this.btnDeletar.Enabled = false;
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.Location = new System.Drawing.Point(132, 224);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 43);
            this.btnDeletar.TabIndex = 8;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.Location = new System.Drawing.Point(32, 224);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(78, 43);
            this.btnIncluir.TabIndex = 7;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(229, 222);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(82, 43);
            this.btnAlterar.TabIndex = 6;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtColuna
            // 
            this.txtColuna.Enabled = false;
            this.txtColuna.Location = new System.Drawing.Point(122, 144);
            this.txtColuna.Name = "txtColuna";
            this.txtColuna.Size = new System.Drawing.Size(190, 20);
            this.txtColuna.TabIndex = 5;
            // 
            // txtLinha
            // 
            this.txtLinha.Enabled = false;
            this.txtLinha.Location = new System.Drawing.Point(122, 93);
            this.txtLinha.Name = "txtLinha";
            this.txtLinha.Size = new System.Drawing.Size(190, 20);
            this.txtLinha.TabIndex = 4;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(122, 46);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(190, 20);
            this.txtValor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coluna: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Linha: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor: ";
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // txtErro
            // 
            this.txtErro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtErro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblErro});
            this.txtErro.Location = new System.Drawing.Point(0, 673);
            this.txtErro.Name = "txtErro";
            this.txtErro.Size = new System.Drawing.Size(1109, 25);
            this.txtErro.TabIndex = 14;
            // 
            // lblErro
            // 
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(31, 22);
            this.lblErro.Text = "Erro:";
            // 
            // btnExcluirMatriz
            // 
            this.btnExcluirMatriz.Enabled = false;
            this.btnExcluirMatriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirMatriz.Location = new System.Drawing.Point(1009, 372);
            this.btnExcluirMatriz.Name = "btnExcluirMatriz";
            this.btnExcluirMatriz.Size = new System.Drawing.Size(91, 286);
            this.btnExcluirMatriz.TabIndex = 15;
            this.btnExcluirMatriz.Text = "Excluir Matriz";
            this.btnExcluirMatriz.UseVisualStyleBackColor = true;
            this.btnExcluirMatriz.Click += new System.EventHandler(this.btnLiberarMatriz_Click);
            // 
            // frmMatriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 698);
            this.Controls.Add(this.btnExcluirMatriz);
            this.Controls.Add(this.txtErro);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLerMatrizB);
            this.Controls.Add(this.btnLerMatrizA);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.dgvB);
            this.Name = "frmMatriz";
            this.Text = "Matriz Esparsa";
            this.Load += new System.EventHandler(this.frmMatriz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.txtErro.ResumeLayout(false);
            this.txtErro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvB;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Button btnMultiplicarMatrizes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLerMatrizA;
        private System.Windows.Forms.Button btnLerMatrizB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSomar;
        private System.Windows.Forms.Button btnSomarMatrizes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtColuna;
        private System.Windows.Forms.TextBox txtLinha;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.ToolStrip txtErro;
        private System.Windows.Forms.ToolStripLabel lblErro;
        private System.Windows.Forms.RadioButton rgbMB;
        private System.Windows.Forms.RadioButton rgbMA;
        private System.Windows.Forms.Button btnExcluirMatriz;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxColuna;
        private System.Windows.Forms.Button btnSomarColuna;
    }
}

