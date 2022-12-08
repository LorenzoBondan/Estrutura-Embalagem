namespace Fantasma.Componentes.Polietileno
{
    partial class frmBancoPolietileno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBancoPolietileno));
            this.datagridBancoPolietileno = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnImportarCSVCantoneiras = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridBancoPolietileno)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridBancoPolietileno
            // 
            this.datagridBancoPolietileno.AllowUserToAddRows = false;
            this.datagridBancoPolietileno.AllowUserToDeleteRows = false;
            this.datagridBancoPolietileno.AllowUserToResizeRows = false;
            this.datagridBancoPolietileno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridBancoPolietileno.BackgroundColor = System.Drawing.Color.White;
            this.datagridBancoPolietileno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridBancoPolietileno.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagridBancoPolietileno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridBancoPolietileno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao});
            this.datagridBancoPolietileno.Location = new System.Drawing.Point(13, 111);
            this.datagridBancoPolietileno.Name = "datagridBancoPolietileno";
            this.datagridBancoPolietileno.ReadOnly = true;
            this.datagridBancoPolietileno.RowHeadersVisible = false;
            this.datagridBancoPolietileno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridBancoPolietileno.Size = new System.Drawing.Size(775, 316);
            this.datagridBancoPolietileno.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(623, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 54);
            this.label1.TabIndex = 19;
            this.label1.Text = "A importação de CSV deve conter cabeçalho e o formato de:\r\ncodigo | descricao";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(626, 23);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(162, 23);
            this.btnExcluir.TabIndex = 18;
            this.btnExcluir.Text = "Excluir Código";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnImportarCSVCantoneiras
            // 
            this.btnImportarCSVCantoneiras.Location = new System.Drawing.Point(626, 52);
            this.btnImportarCSVCantoneiras.Name = "btnImportarCSVCantoneiras";
            this.btnImportarCSVCantoneiras.Size = new System.Drawing.Size(162, 23);
            this.btnImportarCSVCantoneiras.TabIndex = 16;
            this.btnImportarCSVCantoneiras.Text = "Importar CSV";
            this.btnImportarCSVCantoneiras.UseVisualStyleBackColor = true;
            this.btnImportarCSVCantoneiras.Click += new System.EventHandler(this.btnImportarCSVCantoneiras_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(765, 43);
            this.label10.TabIndex = 17;
            this.label10.Text = "label10";
            this.label10.Visible = false;
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
            // frmBancoPolietileno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridBancoPolietileno);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnImportarCSVCantoneiras);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBancoPolietileno";
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "Banco Polietileno";
            this.Load += new System.EventHandler(this.frmBancoPolietileno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridBancoPolietileno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridBancoPolietileno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnImportarCSVCantoneiras;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}