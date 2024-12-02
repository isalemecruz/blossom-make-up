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
    public partial class visvendaproduto : Form
    {
        public visvendaproduto()
        {
       

            InitializeComponent();
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=blossommakeup; UID=root; PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "DESCRIBE vendaproduto";

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
            consulta.CommandText = "SELECT * FROM vendaproduto";
            resultado = consulta.ExecuteReader();
            while (resultado.Read())
            {
                dataGridView1.Rows.Add(
                         resultado["FK_venda_id"].ToString(),
                         resultado["FK_produto_id"].ToString());
            }


            conectar.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            string id = Convert.ToString(textBox1.Text);


            MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=blossommakeup; UID=root; PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT * FROM vendaproduto WHERE FK_produto_id ="+id; 

            dataGridView1.Rows.Clear();
            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    dataGridView1.Rows.Add(
                        resultado["FK_venda_id"].ToString(),
                         resultado["FK_produto_id"].ToString());

                }
            }

            else
            {
                MessageBox.Show("nenhum registro foi encontrado");
            }
            conectar.Close();
        }
      //  Microsoft.Office.Interop.Excel.Application XcellApp = new Microsoft.Office.Interop.Excel.Application();
        private void button2_Click(object sender, EventArgs e)
        {
            /*if (dataGridView1.Rows.Count > 0)
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
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }


