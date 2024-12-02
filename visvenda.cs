using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
namespace Visualizar
{
    public partial class visvenda : Form
    {
        public visvenda()
        {
            InitializeComponent();
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=blossommakeup; UID=root; PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "DESCRIBE venda";

            MySqlDataReader resultado = consulta.ExecuteReader();

            while (resultado.Read())
            {

                dataGridView1.ColumnCount += 1;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name = resultado["Field"].ToString();

            }


            resultado.Close();

            dataGridView1.Rows.Clear();


            consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT * FROM venda";
            resultado = consulta.ExecuteReader();
            while (resultado.Read())
            {
                dataGridView1.Rows.Add(
                         resultado["id"].ToString(),
                         resultado["valor"].ToString(),
                         resultado["FK_funcionario_id"].ToString(),
                         resultado["FK_cliente_id"].ToString());
            }


            conectar.Close();
        }

        Microsoft.Office.Interop.Excel.Application XcellApp = new Microsoft.Office.Interop.Excel.Application();

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                XcellApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcellApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcellApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                XcellApp.Columns.AutoFit();
                XcellApp.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomecampo = Convert.ToString(textBox1.Text);


            MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=blossommakeup; UID=root; PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT * FROM venda WHERE id like '%" + nomecampo + "%'";

            dataGridView1.Rows.Clear();
            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    dataGridView1.Rows.Add(
                       resultado["id"].ToString(),
                         resultado["valor"].ToString(),
                         resultado["FK_funcionario_id"].ToString(),
                         resultado["FK_cliente_id"].ToString());
                }
            }

            else
            {
                MessageBox.Show("nenhum registro foi encontrado");
            }
            conectar.Close();
        }

        private void visvenda_Load(object sender, EventArgs e)
        {

        }
    }
}

