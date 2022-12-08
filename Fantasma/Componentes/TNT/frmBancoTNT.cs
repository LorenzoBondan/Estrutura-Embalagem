using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fantasma.Componentes.TNT
{
    public partial class frmBancoTNT : MetroFramework.Forms.MetroForm
    {
        public frmBancoTNT()
        {
            InitializeComponent();
        }

        private void frmBancoTNT_Load(object sender, EventArgs e)
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";
            SqlCeEngine db = new SqlCeEngine(strConnection);
            if (!File.Exists(baseDados))
            {
                db.CreateDatabase();
            }
            db.Dispose();
            SqlCeConnection conexao = new SqlCeConnection();
            conexao.ConnectionString = strConnection;
            try
            {
                conexao.Open();
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE tabelaTNT (codigo INT NOT NULL PRIMARY KEY, descricao NVARCHAR(60))";
                comando.ExecuteNonQuery();

                label1.Text = "Tabela criada.";
            }
            catch (Exception ex)
            {
                //label1.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
                AtualizarTabela();
            }
        }

        public void AtualizarTabela()
        {
            datagridBancoTNT.Rows.Clear();

            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);

            try
            {
                string query = "SELECT * FROM tabelaTNT";


                DataTable dados = new DataTable();

                SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, strConnection);

                conexao.Open();

                adaptador.Fill(dados);

                foreach (DataRow linha in dados.Rows)
                {
                    datagridBancoTNT.Rows.Add(linha.ItemArray);
                }
            }
            catch (Exception ex)
            {
                datagridBancoTNT.Rows.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnImportarCSVCantoneiras_Click(object sender, EventArgs e)
        {
            string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
            string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConnection);
            var linenumber = 0;

            try
            {
                conexao.Open();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;

                    using (StreamReader reader = new StreamReader(filename))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (linenumber != 0)
                            {
                                //int id = new Random((int)DateTime.Now.Ticks).Next(0,1000000) + 1;
                                var values = line.Split(';');
                                var sql = "INSERT INTO tabelaTNT VALUES (" + values[0].ToString().Trim() + " , '" + values[1].ToString().Trim() + "' )";
                                //var sql = "INSERT INTO tabelacadastroaluminios VALUES ('" + int.Parse(values[0].ToString()) + "' , '" + values[1].ToString().Trim() + "' , '" + values[2].ToString().Trim() + "' , '" + double.Parse(values[3],CultureInfo.InvariantCulture) + "' ,  '" + double.Parse(values[4],CultureInfo.InvariantCulture) + "'  )";

                                var cmd = new SqlCeCommand();
                                cmd.CommandText = sql;
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Connection = conexao;

                                cmd.ExecuteNonQuery();

                            }
                            linenumber++;
                        }
                    }
                    MessageBox.Show("Produtos importados com sucesso!");
                }

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                AtualizarTabela();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // PROPRIEDADES DO DATAGRID: FULLROWSELECT

            DialogResult dialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string baseDados = @"\\paris\eng\Usuarios\Lorenzo\BaseFantasmaSQLServer.sdf";
                string strConnection = @"DataSource = " + baseDados + ";Password = '1234'";

                SqlCeConnection conexao = new SqlCeConnection(strConnection);

                try
                {
                    conexao.Open();

                    SqlCeCommand comando = new SqlCeCommand();
                    comando.Connection = conexao;

                    int codigo = (int)datagridBancoTNT.SelectedRows[0].Cells[0].Value;

                    comando.CommandText = "DELETE FROM tabelaTNT WHERE codigo = '" + codigo + "'";
                    comando.ExecuteNonQuery();

                    comando.Dispose();

                    MessageBox.Show("Registro excluído do banco de dados!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                    AtualizarTabela();
                }
            }
        }
    }
}
