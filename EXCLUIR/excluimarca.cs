using System;
using System.Windows.Forms;
using MySqlConnector;

namespace atualizar
{
    public partial class excluimarca : Form
    {


        public excluimarca()
        {
            InitializeComponent();

        }

    
        // Método para excluir a marca
        private void button1_Click(object sender, EventArgs e)
        {  string id= textBox1.Text;
            string connString = "SERVER=localhost; DATABASE=blossommakeup; UID=root; PASSWORD=";
            using (MySqlConnection conectar = new MySqlConnection(connString))
            {
                try
                {
                    conectar.Open();
                    string query = "DELETE FROM marca WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            exmarca excm = new exmarca();
                            excm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao excluir marca. Nenhum registro foi afetado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
                    string query = "SELECT * FROM marca WHERE id = @id";
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
                                MessageBox.Show("ID da Marca não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } } } }
