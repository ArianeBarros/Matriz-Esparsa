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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvB = new System.Windows.Forms.DataGridView();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.valorUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSomarColuna = new System.Windows.Forms.Button();
            this.cbxColuna = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSomarMatrizes = new System.Windows.Forms.Button();
            this.btnLerMatrizA = new System.Windows.Forms.Button();
            this.btnLerMatrizB = new System.Windows.Forms.Button();
            this.rgbMB = new System.Windows.Forms.RadioButton();
            this.rgbMA = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.colunaUpDown = new System.Windows.Forms.NumericUpDown();
            this.linhaUpDown = new System.Windows.Forms.NumericUpDown();
            this.numeroUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.txtErro = new System.Windows.Forms.ToolStrip();
            this.lblErro = new System.Windows.Forms.ToolStripLabel();
            this.btnExcluirMatriz = new System.Windows.Forms.Button();
            this.btnMultiplicarMatrizes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valorUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colunaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linhaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroUpDown)).BeginInit();
            this.txtErro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvB
            // 
            this.dgvB.AllowUserToAddRows = false;
            this.dgvB.AllowUserToDeleteRows = false;
            this.dgvB.AllowUserToResizeColumns = false;
            this.dgvB.AllowUserToResizeRows = false;
            this.dgvB.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvB.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvB.Location = new System.Drawing.Point(367, 100);
            this.dgvB.MultiSelect = false;
            this.dgvB.Name = "dgvB";
            this.dgvB.RowHeadersVisible = false;
            this.dgvB.Size = new System.Drawing.Size(332, 193);
            this.dgvB.TabIndex = 0;
            this.dgvB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvB_CellClick);
            this.dgvB.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvA_CellEndEdit_1);
            this.dgvB.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvB_CellEnter);
            this.dgvB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvB_KeyDown);
            // 
            // dgvA
            // 
            this.dgvA.AllowUserToAddRows = false;
            this.dgvA.AllowUserToDeleteRows = false;
            this.dgvA.AllowUserToResizeColumns = false;
            this.dgvA.AllowUserToResizeRows = false;
            this.dgvA.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvA.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvA.Location = new System.Drawing.Point(12, 100);
            this.dgvA.MultiSelect = false;
            this.dgvA.Name = "dgvA";
            this.dgvA.RowHeadersVisible = false;
            this.dgvA.Size = new System.Drawing.Size(332, 193);
            this.dgvA.TabIndex = 1;
            this.dgvA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvA_CellClick);
            this.dgvA.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvA_CellEndEdit_1);
            this.dgvA.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvA_CellEnter);
            this.dgvA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvB_KeyDown);
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToResizeColumns = false;
            this.dgvResultado.AllowUserToResizeRows = false;
            this.dgvResultado.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResultado.Location = new System.Drawing.Point(12, 327);
            this.dgvResultado.MultiSelect = false;
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.RowHeadersVisible = false;
            this.dgvResultado.Size = new System.Drawing.Size(687, 265);
            this.dgvResultado.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.valorUpDown);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnSomarColuna);
            this.groupBox1.Controls.Add(this.cbxColuna);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(719, 402);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 190);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Somar K à coluna";
            // 
            // valorUpDown
            // 
            this.valorUpDown.DecimalPlaces = 2;
            this.valorUpDown.Enabled = false;
            this.valorUpDown.Location = new System.Drawing.Point(129, 86);
            this.valorUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.valorUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.valorUpDown.Name = "valorUpDown";
            this.valorUpDown.Size = new System.Drawing.Size(183, 20);
            this.valorUpDown.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Coluna: ";
            // 
            // btnSomarColuna
            // 
            this.btnSomarColuna.Enabled = false;
            this.btnSomarColuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSomarColuna.Location = new System.Drawing.Point(32, 120);
            this.btnSomarColuna.Name = "btnSomarColuna";
            this.btnSomarColuna.Size = new System.Drawing.Size(280, 53);
            this.btnSomarColuna.TabIndex = 5;
            this.btnSomarColuna.Text = "Somar Coluna";
            this.btnSomarColuna.UseVisualStyleBackColor = true;
            this.btnSomarColuna.Click += new System.EventHandler(this.btnSomarColuna_Click);
            // 
            // cbxColuna
            // 
            this.cbxColuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxColuna.Enabled = false;
            this.cbxColuna.FormattingEnabled = true;
            this.cbxColuna.Location = new System.Drawing.Point(129, 45);
            this.cbxColuna.Name = "cbxColuna";
            this.cbxColuna.Size = new System.Drawing.Size(183, 21);
            this.cbxColuna.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Valor: ";
            // 
            // btnSomarMatrizes
            // 
            this.btnSomarMatrizes.Enabled = false;
            this.btnSomarMatrizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSomarMatrizes.Location = new System.Drawing.Point(12, 610);
            this.btnSomarMatrizes.Name = "btnSomarMatrizes";
            this.btnSomarMatrizes.Size = new System.Drawing.Size(332, 52);
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
            // rgbMB
            // 
            this.rgbMB.AutoSize = true;
            this.rgbMB.Enabled = false;
            this.rgbMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbMB.Location = new System.Drawing.Point(938, 58);
            this.rgbMB.Name = "rgbMB";
            this.rgbMB.Size = new System.Drawing.Size(85, 24);
            this.rgbMB.TabIndex = 10;
            this.rgbMB.TabStop = true;
            this.rgbMB.Text = "Matriz B";
            this.rgbMB.UseVisualStyleBackColor = true;
            this.rgbMB.CheckedChanged += new System.EventHandler(this.rgbMB_CheckedChanged);
            // 
            // rgbMA
            // 
            this.rgbMA.AutoSize = true;
            this.rgbMA.Enabled = false;
            this.rgbMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbMA.Location = new System.Drawing.Point(719, 58);
            this.rgbMA.Name = "rgbMA";
            this.rgbMA.Size = new System.Drawing.Size(85, 24);
            this.rgbMA.TabIndex = 9;
            this.rgbMA.TabStop = true;
            this.rgbMA.Text = "Matriz A";
            this.rgbMA.UseVisualStyleBackColor = true;
            this.rgbMA.CheckedChanged += new System.EventHandler(this.rgbMA_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.colunaUpDown);
            this.groupBox3.Controls.Add(this.linhaUpDown);
            this.groupBox3.Controls.Add(this.numeroUpDown);
            this.groupBox3.Controls.Add(this.btnDeletar);
            this.groupBox3.Controls.Add(this.btnIncluir);
            this.groupBox3.Controls.Add(this.btnAlterar);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(719, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 286);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operações";
            // 
            // colunaUpDown
            // 
            this.colunaUpDown.Enabled = false;
            this.colunaUpDown.Location = new System.Drawing.Point(122, 145);
            this.colunaUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.colunaUpDown.Name = "colunaUpDown";
            this.colunaUpDown.Size = new System.Drawing.Size(190, 20);
            this.colunaUpDown.TabIndex = 11;
            // 
            // linhaUpDown
            // 
            this.linhaUpDown.Enabled = false;
            this.linhaUpDown.Location = new System.Drawing.Point(122, 94);
            this.linhaUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.linhaUpDown.Name = "linhaUpDown";
            this.linhaUpDown.Size = new System.Drawing.Size(190, 20);
            this.linhaUpDown.TabIndex = 10;
            // 
            // numeroUpDown
            // 
            this.numeroUpDown.DecimalPlaces = 2;
            this.numeroUpDown.Enabled = false;
            this.numeroUpDown.Location = new System.Drawing.Point(122, 47);
            this.numeroUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numeroUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numeroUpDown.Name = "numeroUpDown";
            this.numeroUpDown.Size = new System.Drawing.Size(190, 20);
            this.numeroUpDown.TabIndex = 9;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Enabled = false;
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.Location = new System.Drawing.Point(129, 192);
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
            this.btnIncluir.Location = new System.Drawing.Point(25, 192);
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
            this.btnAlterar.Location = new System.Drawing.Point(230, 192);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(82, 43);
            this.btnAlterar.TabIndex = 6;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
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
            // txtErro
            // 
            this.txtErro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtErro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblErro});
            this.txtErro.Location = new System.Drawing.Point(0, 673);
            this.txtErro.Name = "txtErro";
            this.txtErro.Size = new System.Drawing.Size(1067, 25);
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
            this.btnExcluirMatriz.Location = new System.Drawing.Point(719, 610);
            this.btnExcluirMatriz.Name = "btnExcluirMatriz";
            this.btnExcluirMatriz.Size = new System.Drawing.Size(329, 52);
            this.btnExcluirMatriz.TabIndex = 15;
            this.btnExcluirMatriz.Text = "Excluir Matriz";
            this.btnExcluirMatriz.UseVisualStyleBackColor = true;
            this.btnExcluirMatriz.Click += new System.EventHandler(this.btnLiberarMatriz_Click);
            // 
            // btnMultiplicarMatrizes
            // 
            this.btnMultiplicarMatrizes.Enabled = false;
            this.btnMultiplicarMatrizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplicarMatrizes.Location = new System.Drawing.Point(367, 610);
            this.btnMultiplicarMatrizes.Name = "btnMultiplicarMatrizes";
            this.btnMultiplicarMatrizes.Size = new System.Drawing.Size(332, 52);
            this.btnMultiplicarMatrizes.TabIndex = 6;
            this.btnMultiplicarMatrizes.Text = "Multiplicar Matrizes";
            this.btnMultiplicarMatrizes.UseVisualStyleBackColor = true;
            this.btnMultiplicarMatrizes.Click += new System.EventHandler(this.btnMultiplicarMatrizes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Miriam CLM", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(714, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Escolha uma matriz:";
            // 
            // frmMatriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 698);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSomarMatrizes);
            this.Controls.Add(this.btnMultiplicarMatrizes);
            this.Controls.Add(this.btnExcluirMatriz);
            this.Controls.Add(this.txtErro);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnLerMatrizB);
            this.Controls.Add(this.rgbMB);
            this.Controls.Add(this.btnLerMatrizA);
            this.Controls.Add(this.rgbMA);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.dgvB);
            this.Name = "frmMatriz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matriz Esparsa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valorUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colunaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linhaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroUpDown)).EndInit();
            this.txtErro.ResumeLayout(false);
            this.txtErro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvB;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLerMatrizA;
        private System.Windows.Forms.Button btnLerMatrizB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSomarMatrizes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnAlterar;
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
        private System.Windows.Forms.NumericUpDown valorUpDown;
        private System.Windows.Forms.NumericUpDown numeroUpDown;
        private System.Windows.Forms.Button btnMultiplicarMatrizes;
        private System.Windows.Forms.NumericUpDown colunaUpDown;
        private System.Windows.Forms.NumericUpDown linhaUpDown;
        private System.Windows.Forms.Label label4;
    }
}

