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
    public partial class CompararProductosForm : Form
    {
        public CompararProductosForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide(); 
        }

        private void comparar_button_Click(object sender, EventArgs e)
        {
            //First project
            double trema = Convert.ToDouble(trema1.Text);
            int nper = Convert.ToInt16(nper1.Text);
            double[] flow1 = new double[nper];
            double mantenimiento = Convert.ToDouble(mantenimiento1.Text);
            for(int i = 0; i < nper; i++)
            {
                flow1[i] = -mantenimiento;
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
            mantenimiento = Convert.ToDouble(mantenimiento2.Text);
            for(int i = 0; i < nper; i++)
            {
                flow2[i] = -mantenimiento;
            }
            flow2[nper - 1] += Convert.ToDouble(recuperacion2.Text);
            inicial = Convert.ToDouble(inicial2.Text);
            Proyecto producto2 = new Proyecto(nper, trema, flow2, inicial);
            producto2.calcularVNA();
            producto2.calcularVAE();
            vna2.Text = Convert.ToString(producto2.vna);
            vae2.Text = Convert.ToString(producto2.vae);
        }
    }
}

