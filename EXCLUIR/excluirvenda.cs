using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atualizar
{
    public partial class excluirvenda : Form
    {
        public excluirvenda()
        {
            InitializeComponent();
        }

        private void excluirvenda_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            string id = textBox1.Text;

            using (MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD=;"))
            {
                try
                {
                    conexao.Open();
                    string query = @"
                        SELECT v.valor, f.nome AS funcionario, c.nome AS cliente 
                        FROM venda v
                        INNER JOIN funcionario f ON v.FK_funcionario_id = f.id
                        INNER JOIN cliente c ON v.FK_cliente_id = c.id
                        WHERE v.id = @id";

                    using (MySqlCommand consulta = new MySqlCommand(query, conexao))
                    {
                        consulta.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader resultado = consulta.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                while (resultado.Read())
                                {
                                    textBox2.Text = resultado["valor"].ToString();       // Valor da venda
                                    textBox3.Text = resultado["funcionario"].ToString(); // Nome do funcionário
                                    textBox4.Text = resultado["cliente"].ToString();     // Nome do cliente
                                }
                            }
                            else
                            {
                                MessageBox.Show("ID da Venda não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar esta venda?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string id = textBox1.Text;

                using (MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=blossommakeup;UID=root;PASSWORD=;"))
                {
                    try
                    {
                        conexao.Open();
                        using (MySqlCommand excluir = new MySqlCommand())
                        {
                            excluir.Connection = conexao;
                            excluir.CommandText = @"
                                START TRANSACTION;
                                DELETE FROM vendaProduto WHERE FK_venda_id = @id;
                                DELETE FROM venda WHERE id = @id;
                                COMMIT;";

                            excluir.Parameters.AddWithValue("@id", id);
                            excluir.ExecuteNonQuery();
                        }

                        exvenda exxxv = new exvenda();
                        exxxv.Show();
                        this.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

