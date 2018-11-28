using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparisonFinancialCalculator
{
    public partial class CompararProyectosForm : Form
    {
        public CompararProyectosForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void cargar1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Ingresos");
            table.Columns.Add("Egresos");
            int nper = Convert.ToInt32(nper1.Text);
            for (int i = 0; i <nper-1; i++)
            {
                table.Rows.Add();

            }
            dataGridView1.DataSource = table;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void cargar2_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Ingresos");
            table.Columns.Add("Egresos");
            int nper = Convert.ToInt32(nper2.Text);
            for (int i = 0; i < nper - 1; i++)
            {
                table.Rows.Add();

            }
            dataGridView2.DataSource = table;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void comparar_button_Click(object sender, EventArgs e)
        {
            //First project
            double trema = Convert.ToDouble(trema1.Text);
            int nper = Convert.ToInt16(nper1.Text);
            double[] flow1 = new double[nper];
            int cont = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(cont < nper)
                {
                    flow1[cont] = Convert.ToDouble(row.Cells["Ingresos"].Value) - Convert.ToDouble(row.Cells["Egresos"].Value);
                    cont++;
                }
            }
            flow1[nper - 1] += Convert.ToDouble(recuperacion1.Text);
            double inicial = Convert.ToDouble(inicial1.Text);
            Proyecto producto1 = new Proyecto(nper, trema, flow1, inicial);
            producto1.calcularVNA();
            producto1.calcularVAE();
            vna1.Text = Convert.ToString(producto1.vna);
            vae1.Text = Convert.ToString(producto1.vae);

            //Second Project
            trema = Convert.ToDouble(trema2.Text);
            nper = Convert.ToInt16(nper2.Text);
            double[] flow2 = new double[nper];
            cont = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (cont < nper)
                {
                    flow2[cont] = Convert.ToDouble(row.Cells["Ingresos"].Value) - Convert.ToDouble(row.Cells["Egresos"].Value);
                    cont++;
                }
            }
            flow2[nper - 1] += Convert.ToDouble(recuperacion2.Text);
            inicial = Convert.ToDouble(inicial2.Text);
            Proyecto producto2 = new Proyecto(nper, trema, flow2, inicial);
            producto2.calcularVNA();
            producto2.calcularVAE();
            vna2.Text = Convert.ToString(producto2.vna);
            vae2.Text = Convert.ToString(producto2.vae);
            int uno, dos;
            uno = Convert.ToInt32(nper1.Text);
            dos = Convert.ToInt32(nper2.Text);
            if(uno == dos)
            {
                if (producto1.vna > producto2.vna)
                    resultado.Text = "Producto 1";
                else
                    resultado.Text = "Producto 2";
            }
            else
            {
                if (producto1.vae > producto2.vae)
                    resultado.Text = "Producto 1";
                else
                    resultado.Text = "Producto 2";
            }
        }
    }
}
