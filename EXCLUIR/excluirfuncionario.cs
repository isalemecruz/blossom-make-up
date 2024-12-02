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
    public partial class excluirfuncionario : Form
    {
        public excluirfuncionario()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

                // Conectando no Banco de Dados

                MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
                conexao.Open();

                // Comando para Consultar

                MySqlCommand consulta = new MySqlCommand();
                consulta.Connection = conexao;
                consulta.CommandText = "SELECT * FROM funcionario WHERE funcionario.id = " + textBox1.Text;

                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        textBox2.Text = resultado["nome"].ToString();
                        textBox3.Text = resultado["cpf"].ToString();
                        textBox4.Text = resultado["salario"].ToString();
                        textBox5.Text = resultado["email"].ToString();
                        textBox6.Text = resultado["cep"].ToString();
                        textBox7.Text = resultado["numeroCasa"].ToString();
                    }

                }

                else
                {

                    MessageBox.Show("ID Incorreto");

                }

                conexao.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {

                string id = textBox1.Text;

                // Conectando no Banco de Dados

                MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
                conexao.Open();

                MySqlCommand excluir = new MySqlCommand();

                excluir.Connection = conexao;

                excluir.CommandText = "START TRANSACTION; " +
                    "\r\nDELETE FROM vendaProduto WHERE FK_venda_id IN(SELECT id FROM venda WHERE FK_funcionario_id = " + id + ");" +
                    "\r\nDELETE FROM venda WHERE FK_funcionario_id = " + id + ";" +
                    "\r\nDELETE FROM cliente WHERE FK_funcionario_id = " + id + ";" +
                    "\r\nDELETE FROM produto WHERE FK_funcionario_id = " + id + ";" +
                    "\r\nDELETE FROM funcionario WHERE id = " + id + ";" +
                    "\r\nCOMMIT;";

                excluir.ExecuteNonQuery();
         
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";


                exfunc excfunc = new exfunc();
                excfunc.Show();
                this.Close();

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void excluirfuncionario_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
