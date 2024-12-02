using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace atualizar
{
    public partial class excluircliente : Form
    {
        public excluircliente()
        {
            InitializeComponent();
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar as informações do cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                string id = textBox1.Text; // Supondo que o ID do cliente esteja no textBoxClienteId.

                try
                {
                    // Conectando no Banco de Dados
                    using (MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;"))
                    {
                        conexao.Open();

                        MySqlCommand excluirCliente = new MySqlCommand(
                            "START TRANSACTION; " +
                            "DELETE FROM vendaProduto WHERE FK_venda_id IN (SELECT id FROM venda WHERE FK_cliente_id = @id); " +
                            "DELETE FROM venda WHERE FK_cliente_id = @id; " +
                            "DELETE FROM cliente WHERE id = @id; " +
                            "COMMIT;", conexao);

                        // Parametrizando o ID do cliente para evitar SQL Injection
                        excluirCliente.Parameters.AddWithValue("@id", id);

                        // Executa o comando para exclusão
                        excluirCliente.ExecuteNonQuery();

                        // Limpar os campos de texto após a exclusão
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";


                        excliente ecliente = new excliente();
                        ecliente.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir cliente: " + ex.Message);

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
            conexao.Open();

            // Comando para Consultar

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT * FROM cliente WHERE cliente.id = " + textBox1.Text;

            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    textBox2.Text = resultado["nome"].ToString();
                    textBox3.Text = resultado["cpf"].ToString();
                    textBox4.Text = resultado["telefone"].ToString();
                    textBox5.Text = resultado["email"].ToString();

                }

            }

            else
            {

                MessageBox.Show("ID Incorreto");

            }

            conexao.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    }

