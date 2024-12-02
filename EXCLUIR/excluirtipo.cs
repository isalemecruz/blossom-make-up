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
    public partial class excluirtipo : Form
    {
        public excluirtipo()
        {
            InitializeComponent();
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
                    string query = "SELECT * FROM tipo WHERE id = @id";
                    using (MySqlCommand consulta = new MySqlCommand(query, conexao))
                    {
                        consulta.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader resultado = consulta.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                while (resultado.Read())
                                {
                                    textBox2.Text = resultado["nome"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ID do Tipo não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar este tipo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                                DELETE FROM produto WHERE FK_tipo_id = @id;
                                DELETE FROM tipo WHERE id = @id;
                                COMMIT;";

                            excluir.Parameters.AddWithValue("@id", id);
                            excluir.ExecuteNonQuery();
                        }

                        extipo exxxt = new extipo();
                        exxxt.Show();
                        this.Close();

                        textBox2.Text = "";
                        textBox1.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir tipo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
