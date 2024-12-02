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
    public partial class excluirproduto : Form
    {
        public excluirproduto()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            excluimarca exxxx = new excluimarca();
            exxxx.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text; // ID do produto a ser excluído.

            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar as informações do produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    // Conectando no Banco de Dados
                    using (MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;"))
                    {
                        conexao.Open();

                        MySqlCommand excluirProduto = new MySqlCommand(
                            "START TRANSACTION; " +
                            "DELETE FROM vendaProduto WHERE FK_produto_id = @id; " +  // Remove as vendas associadas ao produto
                            "DELETE FROM produto WHERE id = @id; " +  // Exclui o produto
                            "COMMIT;", conexao);

                        // Parametrizando o ID do produto para evitar SQL Injection
                        excluirProduto.Parameters.AddWithValue("@id", id);

                        // Executa o comando para exclusão
                        excluirProduto.ExecuteNonQuery();

                        // Limpar os campos de texto após a exclusão
                        textBox2.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";

                        exproduto exxxp = new exproduto();
                        exxxp.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir produto: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string id = textBox1.Text; // Supondo que o ID do produto esteja no textBoxProdutoId.

            try
            {
                // Conectando no Banco de Dados
                using (MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;"))
                {
                    conexao.Open();

                    // Comando para consultar os dados do produto, tipo e marca
                    MySqlCommand consultaProduto = new MySqlCommand(
                "SELECT p.nome AS produto_nome, p.preco, p.quantidade, t.nome AS tipo_nome, m.nome AS marca_nome, f.nome AS funcionario_nome " +
                "FROM produto p " +
                "JOIN tipo t ON p.FK_tipo_id = t.id " +
                "JOIN marca m ON p.FK_marca_id = m.id " +
                "JOIN funcionario f ON p.FK_funcionario_id = f.id " +  // Incluindo a junção com a tabela funcionario
                "WHERE p.id = @id", conexao);


                    consultaProduto.Parameters.AddWithValue("@id", id);

                    MySqlDataReader resultado = consultaProduto.ExecuteReader();
                    if (resultado.HasRows)
                    {
                        while (resultado.Read())
                        {
                            // Preenchendo os campos de texto com os dados do produto, tipo e marca
                            textBox2.Text = resultado["nome"].ToString();
                            textBox5.Text = resultado["preco"].ToString();
                            textBox6.Text = resultado["quantidade"].ToString();
                            textBox3.Text = resultado["tipo_nome"].ToString(); // Preenchendo o tipo
                            textBox4.Text = resultado["marca_nome"].ToString(); // Preenchendo a marca
                            textBox7.Text = resultado["funcionario_nome"].ToString(); // Preenchendo a marca

                        }
                        exproduto excproduto = new exproduto();
                        excproduto.Show();
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar produto: " + ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
