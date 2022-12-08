namespace Fantasma.Componentes.Cantoneiras
{
    partial class frmBancoCantoneiras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBancoCantoneiras));
            this.datagridBancoCantoneiras = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnImportarCSVCantoneiras = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridBancoCantoneiras)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridBancoCantoneiras
            // 
            this.datagridBancoCantoneiras.AllowUserToAddRows = false;
            this.datagridBancoCantoneiras.AllowUserToDeleteRows = false;
            this.datagridBancoCantoneiras.AllowUserToResizeRows = false;
            this.datagridBancoCantoneiras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridBancoCantoneiras.BackgroundColor = System.Drawing.Color.White;
            this.datagridBancoCantoneiras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridBancoCantoneiras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagridBancoCantoneiras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridBancoCantoneiras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao});
            this.datagridBancoCantoneiras.Location = new System.Drawing.Point(13, 111);
            this.datagridBancoCantoneiras.Name = "datagridBancoCantoneiras";
            this.datagridBancoCantoneiras.ReadOnly = true;
            this.datagridBancoCantoneiras.RowHeadersVisible = false;
            this.datagridBancoCantoneiras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridBancoCantoneiras.Size = new System.Drawing.Size(775, 316);
            this.datagridBancoCantoneiras.TabIndex = 5;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 65;
            // 
            // descricao
            // 
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(623, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 54);
            this.label1.TabIndex = 9;
            this.label1.Text = "A importação de CSV deve conter cabeçalho e o formato de:\r\ncodigo | descricao";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(626, 23);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(162, 23);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir Código";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnImportarCSVCantoneiras
            // 
            this.btnImportarCSVCantoneiras.Location = new System.Drawing.Point(626, 52);
            this.btnImportarCSVCantoneiras.Name = "btnImportarCSVCantoneiras";
            this.btnImportarCSVCantoneiras.Size = new System.Drawing.Size(162, 23);
            this.btnImportarCSVCantoneiras.TabIndex = 6;
            this.btnImportarCSVCantoneiras.Text = "Importar CSV";
            this.btnImportarCSVCantoneiras.UseVisualStyleBackColor = true;
            this.btnImportarCSVCantoneiras.Click += new System.EventHandler(this.btnImportarCSVCantoneiras_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(765, 43);
            this.label10.TabIndex = 7;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // frmBancoCantoneiras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridBancoCantoneiras);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnImportarCSVCantoneiras);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBancoCantoneiras";
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "Banco Cantoneiras";
            ((System.ComponentModel.ISupportInitialize)(this.datagridBancoCantoneiras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridBancoCantoneiras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnImportarCSVCantoneiras;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}