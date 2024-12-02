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

namespace Visualizar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          viscliente viscli = new viscliente();
          viscli.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            visfuncionario visfun = new visfuncionario();
            visfun.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vismarca visma = new vismarca();
            visma.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            visproduto vispro = new visproduto();
            vispro.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vistipo visti = new vistipo();
            visti.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            visvenda visve = new visvenda();
            visve.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            visvendaproduto visven = new visvendaproduto();
            visven.Show();
        }
    }
}
