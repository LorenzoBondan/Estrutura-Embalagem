﻿namespace Fantasma.Componentes.Plasticos
{
    partial class frmBancoPlasticos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBancoPlasticos));
            this.datagridBancoPlasticos = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gramatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnImportarCSVCantoneiras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridBancoPlasticos)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridBancoPlasticos
            // 
            this.datagridBancoPlasticos.AllowUserToAddRows = false;
            this.datagridBancoPlasticos.AllowUserToDeleteRows = false;
            this.datagridBancoPlasticos.AllowUserToResizeRows = false;
            this.datagridBancoPlasticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridBancoPlasticos.BackgroundColor = System.Drawing.Color.White;
            this.datagridBancoPlasticos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridBancoPlasticos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagridBancoPlasticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridBancoPlasticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao,
            this.gramatura});
            this.datagridBancoPlasticos.Location = new System.Drawing.Point(13, 111);
            this.datagridBancoPlasticos.Name = "datagridBancoPlasticos";
            this.datagridBancoPlasticos.ReadOnly = true;
            this.datagridBancoPlasticos.RowHeadersVisible = false;
            this.datagridBancoPlasticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridBancoPlasticos.Size = new System.Drawing.Size(775, 316);
            this.datagridBancoPlasticos.TabIndex = 10;
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
            // gramatura
            // 
            this.gramatura.HeaderText = "Gramatura";
            this.gramatura.Name = "gramatura";
            this.gramatura.ReadOnly = true;
            this.gramatura.Width = 81;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(765, 43);
            this.label10.TabIndex = 12;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(623, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 54);
            this.label1.TabIndex = 14;
            this.label1.Text = "A importação de CSV deve conter cabeçalho e o formato de:\r\ncodigo | descricao | g" +
    "ramatura";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(626, 23);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(162, 23);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir Código";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnImportarCSVCantoneiras
            // 
            this.btnImportarCSVCantoneiras.Location = new System.Drawing.Point(626, 52);
            this.btnImportarCSVCantoneiras.Name = "btnImportarCSVCantoneiras";
            this.btnImportarCSVCantoneiras.Size = new System.Drawing.Size(162, 23);
            this.btnImportarCSVCantoneiras.TabIndex = 11;
            this.btnImportarCSVCantoneiras.Text = "Importar CSV";
            this.btnImportarCSVCantoneiras.UseVisualStyleBackColor = true;
            this.btnImportarCSVCantoneiras.Click += new System.EventHandler(this.btnImportarCSVCantoneiras_Click);
            // 
            // frmBancoPlasticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridBancoPlasticos);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnImportarCSVCantoneiras);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBancoPlasticos";
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "Banco Plásticos";
            this.Load += new System.EventHandler(this.frmBancoPlasticos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridBancoPlasticos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridBancoPlasticos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnImportarCSVCantoneiras;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn gramatura;
    }
}