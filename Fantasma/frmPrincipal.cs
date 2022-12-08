using Fantasma.Códigos_Concatenados;
using Fantasma.Componentes;
using Fantasma.Componentes.Cantoneiras;
using Fantasma.Componentes.Plasticos;
using Fantasma.Componentes.Polietileno;
using Fantasma.Componentes.TNT;
using Fantasma.Instruções;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fantasma
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()   
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            #region CUSTOMIZAÇÃO DO DATAGRIDVIEW

            // linhas alternadas
            dataCodigos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(234, 234, 234);
            dataExport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(234, 234, 234);

            // linha selecionada
            dataCodigos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 125, 33);
            dataExport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 125, 33);
            dataCodigos.DefaultCellStyle.SelectionForeColor = Color.White;
            dataExport.DefaultCellStyle.SelectionForeColor = Color.White;

            // fonte
            //dataGridView2.DefaultCellStyle.Font = new Font("Century Gothic",8);

            // bordas
            dataCodigos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataExport.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // cabeçalho
            dataCodigos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            dataExport.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 8, FontStyle.Bold);

            dataCodigos.EnableHeadersVisualStyles = false; // habilita a edição do cabeçalho
            dataExport.EnableHeadersVisualStyles = false; // habilita a edição do cabeçalho

            dataCodigos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 84, 21);
            dataExport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 84, 21);
            dataCodigos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataExport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            #endregion

            #region LARGURA DOS PLÁSTICOS

            int[] primeiracoluna = { 200, 250, 350, 450, 0, 550, 650, 700, 750, 800, 850, 950, 1000, 0, 1200, 1250, 0, 0 };
            int[] segundacoluna = { 200, 250, 350, 450, 500, 550, 650, 700, 750, 800, 850, 950, 1000, 1100, 1200, 1250, 1350, 1500 };
            int[] terceiracoluna = { 750, 850, 950, 1200, 1300, 1600, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < primeiracoluna.Length; i++)
            {
                dataLarguraPlasticos.Rows.Add(primeiracoluna[i], segundacoluna[i], terceiracoluna[i]);
            }

            #endregion

            #region CARREGANDO COMBOBOXES

            CarregarCodigosCantoneiras();
            CarregarCodigosPlasticos();
            CarregarCodigosTNT();
            CarregarCodigosPolietileno();

            #endregion
        }

        #region VARIÁVEIS PÚBLICAS

        List<CodigoConcatenado> list = new List<CodigoConcatenado>();
        List<Componente> Componentes = new List<Componente>();
        List<double> largurasSelecionadas = new List<double>();
        TreeNode mainNode = new TreeNode();
        int seq = 10;

        #endregion

        #region CANTONEIRAS

        public void CarregarCodigosCantoneiras()
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);

            try
            {
                conexao.Open();
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                // combobox
                cbCantoneiras.Items.Clear();
                comando.CommandText = "SELECT descricao FROM tabelaCantoneiras";
                comando.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlCeDataAdapter da = new SqlCeDataAdapter(comando);
                da.Fill(dt);

                foreach (DataRow linha in dt.Rows)
                {
                    cbCantoneiras.Items.Add(linha["descricao"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void cbCantoneiras_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrazerDescricaoCantoneiras();
        }

        public void TrazerDescricaoCantoneiras()
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);
            conexao.Open();

            try
            {
                string descricao = cbCantoneiras.SelectedItem.ToString();

                string query = "SELECT codigo FROM tabelaCantoneiras WHERE descricao = '" + descricao + "'  ";

                SqlCeCommand comando = new SqlCeCommand(query, conexao);

                string codigo = comando.ExecuteScalar().ToString();

                txtCodigoCantoneira.Text = codigo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnAdicionarCantoneira_Click(object sender, EventArgs e)
        {
            //mainNode.Nodes.Add("CANTONEIRA");
            //mainNode.Nodes.Add("PLÁSTICO");

            if (txtDataImplantacao.Text == "")
            {
                MessageBox.Show("Insira uma data de implantação.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (treeViewNovaEstrutura.Nodes.Count == 0) return;

            string codigoCantoneira = txtCodigoCantoneira.Text; if (codigoCantoneira == "") return;
            string descricaoCantoneira = cbCantoneiras.SelectedItem.ToString(); if (txtQuantidadeCantoneira.Text == "") return;
            double quantidadeCantoneira = double.Parse(txtQuantidadeCantoneira.Text);

            foreach (CodigoConcatenado codigoPai in list)
            {
                Cantoneira cant = new Cantoneira(codigoCantoneira, descricaoCantoneira, quantidadeCantoneira);
                Componentes.Add(cant);
                dataExport.Rows.Add(1, codigoPai.Codigo, seq, cant.Codigo, "", "n", 0, 100, "", "", cant.CalcularQuantidade(), "?", txtDataImplantacao.Text, "31/12/9999", "", 0, "", "", "", "", 4, 1, "N", 0);
            }

            //int quantidade =  c.CalcularQuantidade(); // a mesma nesse caso


            mainNode.Nodes.Add(seq + " - " + codigoCantoneira + " - " + descricaoCantoneira);
            seq += 10;

        }

        #endregion

        #region PLÁSTICOS

        public void CarregarCodigosPlasticos()
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);

            try
            {
                conexao.Open();
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                // combobox
                cbPlasticos.Items.Clear();
                comando.CommandText = "SELECT descricao FROM tabelaPlasticos";
                comando.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlCeDataAdapter da = new SqlCeDataAdapter(comando);
                da.Fill(dt);

                foreach (DataRow linha in dt.Rows)
                {
                    cbPlasticos.Items.Add(linha["descricao"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void cbPlasticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrazerDescricaoPlasticos();
        }

        public void TrazerDescricaoPlasticos()
        {
            // traz descricao e gramatura

            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);
            conexao.Open();

            try
            {
                string descricao = cbPlasticos.SelectedItem.ToString();

                string query = "SELECT codigo FROM tabelaPlasticos WHERE descricao = '" + descricao + "'  ";
                string query2 = "SELECT gramatura FROM tabelaPlasticos WHERE descricao = '" + descricao + "'  ";

                SqlCeCommand comando = new SqlCeCommand(query, conexao);
                string codigo = comando.ExecuteScalar().ToString();
                txtCodigoPlastico.Text = codigo;

                comando = new SqlCeCommand(query2, conexao);
                double gramatura = double.Parse(comando.ExecuteScalar().ToString());
                txtGramatura.Text = gramatura.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnAdicionarPlastico_Click(object sender, EventArgs e)
        {
            if (treeViewNovaEstrutura.Nodes.Count == 0) return;

            if (txtDataImplantacao.Text == "")
            {
                MessageBox.Show("Insira uma data de implantação.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string codigoPlastico = txtCodigoPlastico.Text; if (txtCodigoPlastico.Text == "") return;
            string descricaoPlastico = cbPlasticos.SelectedItem.ToString();
            double gramatura = double.Parse(txtGramatura.Text); // <<-- 0,065
            bool superior = true;
            int larguraplastico = 0;
            double plasticoamais = double.Parse(txtPlasticoAMais.Text); if (txtPerdaPlastico.Text == "") { MessageBox.Show("Insira uma perda."); return; }
            double perda = double.Parse(txtPerdaPlastico.Text);

            if (txtLarguraPlastico.Text != "")
            {
                larguraplastico = int.Parse(txtLarguraPlastico.Text);
            }

            if (rbPlasticoSuperior.Checked)
            {
                superior = true;
            }
            else if (rbPlasticoInferior.Checked)
            {
                superior = false;
            }

            mainNode.Nodes.Add(seq + " - " + codigoPlastico + " - " + descricaoPlastico);

            foreach (CodigoConcatenado codigoPai in list)
            {
                double maiorMedida = Math.Max(codigoPai.Medida1, codigoPai.Medida2);
                double menorMedida = Math.Min(codigoPai.Medida1, codigoPai.Medida2);

                if (cbInserirLarguraPlastico.Checked)
                {
                    Plastico plastico = new Plastico(codigoPlastico, descricaoPlastico, gramatura, superior, larguraplastico, plasticoamais, maiorMedida);
                    double quantidade = plastico.CalcularQuantidade();
                    double perdaSistema = quantidade / (quantidade / (quantidade) - perda / 100);

                    Componentes.Add(plastico);

                    dataExport.Rows.Add(1, codigoPai.Codigo, seq, plastico.Codigo, "", "n", perda, 100, "", "", perdaSistema.ToString("F10"), "?", txtDataImplantacao.Text, "31/12/9999", "", 0, "", "", "", "", 4, 1, "N", 0);
                }
                else
                {
                    // trazer a largura equivalente
                    double largura200 = menorMedida + 200;
                    int coluna = 0;
                    if (codigoPlastico == "1011581")
                    {
                        coluna = 0;
                    }
                    else if (codigoPlastico == "1019305")
                    {
                        coluna = 1;
                    }
                    else if (codigoPlastico == "1021236")
                    {
                        coluna = 2;
                    }

                    List<double> subtracoes = new List<double>();

                    foreach (DataGridViewRow linha in dataLarguraPlasticos.Rows)
                    {
                        double medida = double.Parse(linha.Cells[coluna].Value.ToString());
                        double diferenca = largura200 - medida;
                        subtracoes.Add(diferenca);
                    }

                    double maiorIndice = subtracoes.Where(x => x > 0).Min(); // menor índice positivo

                    double menorIndice = 0;
                    double resultado = 0;
                    try
                    {
                        menorIndice = subtracoes.Where(x => x <= 0).Max(); // menor indice negativo
                        resultado = Math.Min((menorIndice * (-1)), maiorIndice);
                    }
                    catch (Exception)
                    {
                        menorIndice = maiorIndice; // se não tiver nenhum índice negativo (medidas altas, 1100 - 1200
                        resultado = maiorIndice;
                    }



                    int larguraAMais = 0;
                    if (cbLarguraAMais.Checked)
                    {
                        larguraAMais = 1; // pegar uma largura acima
                    }
                    else
                    {
                        larguraAMais = 0; // pegar a largura apropriada
                    }

                    int indice = 0;
                    if (resultado + menorIndice == 0)
                    {
                        indice = subtracoes.IndexOf(menorIndice) + larguraAMais;
                    }
                    else
                    {
                        indice = subtracoes.IndexOf(maiorIndice) + larguraAMais;
                    }

                    larguraplastico = int.Parse(dataLarguraPlasticos.Rows[indice].Cells[coluna].Value.ToString());

                    while (larguraplastico == 0) // pra não pegar se for 0
                    {
                        indice++;
                        if (indice == dataLarguraPlasticos.Rows.Count) // se a medida for muito alta e passar dos limites do plastico, pegar a maior medida != 0
                        {
                            List<int> larguras = new List<int>();
                            foreach (DataGridViewRow linha in dataLarguraPlasticos.Rows)
                            {
                                int largura = int.Parse(dataLarguraPlasticos.Rows[linha.Index].Cells[coluna].Value.ToString());
                                larguras.Add(largura);
                            }
                            larguraplastico = larguras.Where(x => x > 0).Max();
                            break;
                        }
                        larguraplastico = int.Parse(dataLarguraPlasticos.Rows[indice].Cells[coluna].Value.ToString());

                    }

                    largurasSelecionadas.Add(larguraplastico);

                    Plastico plastico = new Plastico(codigoPlastico, descricaoPlastico, gramatura, superior, larguraplastico, plasticoamais, maiorMedida);
                    double quantidade = plastico.CalcularQuantidade(); // quantidade líquida

                    double perdaSistema = quantidade / (quantidade / (quantidade) - perda / 100);

                    Componentes.Add(plastico);

                    dataExport.Rows.Add(1, codigoPai.Codigo, seq, plastico.Codigo, "", "n", perda, 100, "", "", perdaSistema.ToString("F10"), "?", txtDataImplantacao.Text, "31/12/9999", "", 0, "", "", "", "", 4, 1, "N", 0);

                }

            }
            seq += 10;

            int i = 0;
            foreach (DataGridViewRow linha in dataCodigos.Rows)
            {
                linha.Cells[5].Value = largurasSelecionadas[i].ToString();
                i++;
            }
        }

        private void cbInserirLarguraPlastico_CheckedChanged(object sender, EventArgs e)
        {
            txtLarguraPlastico.Enabled = cbInserirLarguraPlastico.Checked;
        }

        #endregion

        #region TNT

        public void CarregarCodigosTNT()
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);

            try
            {
                conexao.Open();
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                // combobox
                cbTNT.Items.Clear();
                comando.CommandText = "SELECT descricao FROM tabelaTNT";
                comando.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlCeDataAdapter da = new SqlCeDataAdapter(comando);
                da.Fill(dt);

                foreach (DataRow linha in dt.Rows)
                {
                    cbTNT.Items.Add(linha["descricao"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void TrazerDescricaoTNT()
        {

            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);
            conexao.Open();

            try
            {
                string descricao = cbTNT.SelectedItem.ToString();

                string query = "SELECT codigo FROM tabelaTNT WHERE descricao = '" + descricao + "'  ";

                SqlCeCommand comando = new SqlCeCommand(query, conexao);
                string codigo = comando.ExecuteScalar().ToString();
                txtCodigoTNT.Text = codigo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void cbTNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrazerDescricaoTNT();
        }

        private void btnAdicionarTNT_Click(object sender, EventArgs e)
        {
            if (treeViewNovaEstrutura.Nodes.Count == 0) return;

            if (txtDataImplantacao.Text == "")
            {
                MessageBox.Show("Insira uma data de implantação.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string codigoTNT = txtCodigoTNT.Text; if (codigoTNT == "") return;
            string descricaoTNT = cbTNT.SelectedItem.ToString(); if (rbTNT1F.Checked == false && rbTNT2f.Checked == false) return;
            bool umaface = false;
            double perda = double.Parse(txtPerdaTNT.Text);
            if (rbTNT1F.Checked)
            {
                umaface = true;
            }
            else if (rbTNT2f.Checked)
            {
                umaface = false;
            }

            foreach (CodigoConcatenado codigoPai in list)
            {
                TNT tnt = new TNT(codigoTNT, descricaoTNT, umaface, codigoPai.Medida1, codigoPai.Medida2, codigoPai.Medida3);
                Componentes.Add(tnt);
                double quantidadeLiq = tnt.CalcularQuantidade();
                double quantidade = quantidadeLiq / (quantidadeLiq / (quantidadeLiq) - perda / 100);
                dataExport.Rows.Add(1, codigoPai.Codigo, seq, tnt.Codigo, "", "n", perda, 100, "", "", quantidade.ToString("F10"), "?", txtDataImplantacao.Text, "31/12/9999", "", 0, "", "", "", "", 4, 1, "N", 0);
            }

            mainNode.Nodes.Add(seq + " - " + codigoTNT + " - " + descricaoTNT);
            seq += 10;
        }

        #endregion

        #region POLIETILENO (INCOMPLETO)

        public void CarregarCodigosPolietileno()
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);

            try
            {
                conexao.Open();
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                // combobox
                cbPolietileno.Items.Clear();
                comando.CommandText = "SELECT codigo FROM tabelaPolietileno";
                comando.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlCeDataAdapter da = new SqlCeDataAdapter(comando);
                da.Fill(dt);

                foreach (DataRow linha in dt.Rows)
                {
                    cbPolietileno.Items.Add(linha["codigo"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void TrazerDescricaoPolietileno()
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);
            conexao.Open();

            try
            {
                string codigo = cbPolietileno.SelectedItem.ToString();

                string query = "SELECT descricao FROM tabelaPolietileno WHERE codigo = '" + codigo + "'  ";

                SqlCeCommand comando = new SqlCeCommand(query, conexao);
                string descricao = comando.ExecuteScalar().ToString();
                txtDescricaoPolietileno.Text = descricao;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void cbPolietileno_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrazerDescricaoPolietileno();
        }

        private void btnAdicionarPolietileno_Click(object sender, EventArgs e)
        {
            if (treeViewNovaEstrutura.Nodes.Count == 0) return;

            if (txtDataImplantacao.Text == "")
            {
                MessageBox.Show("Insira uma data de implantação.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string codigoPolietileno = cbPolietileno.SelectedItem.ToString(); ; if (codigoPolietileno == "") return;
            string descricaoPolietileno = txtDescricaoPolietileno.Text.ToString();
            double perda = double.Parse(txtPerdaPolietileno.Text);

            foreach (CodigoConcatenado codigoPai in list)
            {
                Polietileno polietileno = new Polietileno(codigoPolietileno, descricaoPolietileno, codigoPai.Medida1, codigoPai.Medida2);
                Componentes.Add(polietileno);
                double quantidadeLiq = polietileno.CalcularQuantidade();
                double quantidade = quantidadeLiq / (quantidadeLiq / (quantidadeLiq) - perda / 100);
                dataExport.Rows.Add(1, codigoPai.Codigo, seq, polietileno.Codigo, "", "n", perda, 100, "", "", quantidade.ToString("F10"), "?", txtDataImplantacao.Text, "31/12/9999", "", 0, "", "", "", "", 4, 1, "N", 0);
            }

            mainNode.Nodes.Add(seq + " - " + codigoPolietileno + " - " + descricaoPolietileno);
            seq += 10;

            MessageBox.Show("OBS: Para a quantidade de polietileno foi utilizada a fórmula:\n\n= Perímetro - 2% + perda sistema \n\nA quantidade pode ser alterada manualmente no arquivo, depois que este for exportado.", "Polietileno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region MENU DIREITA - BANCO DE DADOS

        private void btnBancoCantoneiras_Click(object sender, EventArgs e)
        {
            frmBancoCantoneiras f = new frmBancoCantoneiras();
            f.Show();
        }

        private void btnBancoPlasticos_Click(object sender, EventArgs e)
        {
            frmBancoPlasticos f = new frmBancoPlasticos();
            f.Show();
        }

        private void btnBancoTNT_Click(object sender, EventArgs e)
        {
            frmBancoTNT f = new frmBancoTNT();
            f.Show();
        }

        private void btnBancoPolietileno_Click(object sender, EventArgs e)
        {
            frmBancoPolietileno f = new frmBancoPolietileno();
            f.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region MENU ESQUERDA 

        private void btnCarregarCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Arquivo (*.CSV)|*.CSV";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                list.Clear();
                Componentes.Clear();
                dataCodigos.Rows.Clear();
                dataExport.Rows.Clear();
                treeViewNovaEstrutura.Nodes.Clear();
                largurasSelecionadas.Clear();

                seq = 10;

                try
                {
                    string filename = openFileDialog1.FileName;
                    Concatenar(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Concatenar(string filePath)
        {
            DataTable datatable = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);

            string primeiralinha = lines[0];
            string[] nomesCores = primeiralinha.Split(';');

            int colunas = nomesCores.Length;

            string segundalinha = lines[1];
            string[] codigosCores = segundalinha.Split(';');

            for (int i = 2; i < lines.Length; i++) // <<< ---- antes tinha colunas, o certo é linhas
            {
                try
                {
                    string[] dataWords = lines[i].Split(';');

                    // ADICIONANDO A REFERENCIA NA LISTA PARA JUNTÁ-LA COM A REFERENCIA DO FUNDO
                    long referencia = long.Parse(dataWords[0].ToString());
                    string descricao = dataWords[1].ToString();

                    for (int j = 2; j < codigosCores.Length; j++) // essas são as colunas
                    {
                        // codigo
                        string codigoCor = dataWords[0].ToString() + codigosCores[j].ToString();

                        // descricao
                        string descricaoCor = dataWords[1].ToString() + nomesCores[j].ToString().Trim();
                        string novadescricaoCor = descricaoCor.Replace("+ COR", "+COR").Trim(); // HÁ DUAS POSSIBILIDADES: "+COR" OU "+ COR"
                        novadescricaoCor = novadescricaoCor.Replace("+COR", " - ").Trim();

                        // cor
                        int posicaoTraco = novadescricaoCor.LastIndexOf("-");
                        string cor = novadescricaoCor.Substring(posicaoTraco + 1).Trim();

                        // medidas
                        int medida1 = 0;
                        int medida2 = 0;
                        int medida3 = 0;

                        for (int posicao = 0; posicao < novadescricaoCor.Length; posicao++)
                        {
                            string caracter = novadescricaoCor.Substring(posicao, 1);
                            if (caracter.All(char.IsDigit) && novadescricaoCor.Substring(posicao + 2, 1) == "X")
                            {
                                string EntradaMedidas = novadescricaoCor.Substring(posicao - 2).Trim();
                                int EspacoSaidaMedidas = EntradaMedidas.IndexOf(" ");
                                string Medidas = EntradaMedidas.Substring(0, EspacoSaidaMedidas).Trim();

                                // medida 1 
                                int primeiroX = Medidas.IndexOf("X");
                                medida1 = int.Parse(Medidas.Substring(0, primeiroX).Trim());

                                // medida 2 
                                int segundoX = Medidas.LastIndexOf("X");
                                medida2 = int.Parse(Medidas.Substring(primeiroX + 1, segundoX - primeiroX - 1).Trim());

                                // medida 3
                                medida3 = int.Parse(Medidas.Substring(segundoX + 1).Trim());

                                break;
                            }
                        }

                        list.Add(new CodigoConcatenado(codigoCor, novadescricaoCor, medida1, medida2, medida3));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Erro na linha {(i + 1)} do arquivo importado.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (CodigoConcatenado item in list)
            {
                dataCodigos.Rows.Add(item.Codigo, item.Descricao, item.Medida1, item.Medida2, item.Medida3);
            }

        }

        private void btnNovaEstrutura_Click(object sender, EventArgs e)
        {
            mainNode = new TreeNode();

            mainNode.Name = "noEstrutura" + (treeViewNovaEstrutura.Nodes.Count + 1).ToString();
            mainNode.Text = "Estrutura " + (treeViewNovaEstrutura.Nodes.Count + 1).ToString();
            treeViewNovaEstrutura.Nodes.Add(mainNode);

            Componentes.Clear(); // será?

            //foreach (TreeNode item in mainNode.Nodes)
            //{
            //    MessageBox.Show(item.Text);

            //    dataCodigos.Rows.Add(item.Text);
            //}

            //foreach (Componente item in Componentes)
            //{
            //    MessageBox.Show(item.Descricao.ToString());
            //}
        }

        private void btnLimparEstruturas_Click(object sender, EventArgs e)
        {
            treeViewNovaEstrutura.Nodes.Clear();
            dataExport.Rows.Clear();
            seq = 10;
        }

        private void btnExportarEstrutura_Click(object sender, EventArgs e)
        {
            new Exportador().ExportarCSV(dataExport);
            MessageBox.Show(@"Arquivo exportado para:" + "\n" + @"\\paris\eng\Engenharia de Produto\Codificação de Itens\ITENS NOVOS\ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        #endregion

        #region INSTRUÇÕES

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            frmExemploImportacao f = new frmExemploImportacao();
            f.Show();
        }

        private void btnInstrucoes_Click(object sender, EventArgs e)
        {
            frmInstrucoes f = new frmInstrucoes();
            f.Show();
        }

        #endregion

    }
}
