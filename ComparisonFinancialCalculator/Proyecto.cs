using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComparisonFinancialCalculator
{
    class Proyecto
    {
        public int nper; //Number of periods
        public double trema; //MARR (Minimum acceptable rate of return)
        public double[] flow; //The net flow in every period.
        public double inicial; //Initial investment
        public double vna;
        public double vae;
        
        public Proyecto(int nper,double trema, double[] flow, double inicial)
        {
            this.nper = nper;
            this.trema = trema;
            this.flow = flow;
            this.inicial = inicial;
        }
        public double calcularVNA() //Calculate the NPV (Net present value)
        {
            double vna = 0;
            vna = Financial.NPV(trema, ref flow);
            //for(int i = 0; i < nper; i++)
            //{
            //    vna += ((flow[i]) / Math.Pow(1 + trema, i));
            //}
            vna += inicial;
            //vna = Math.Round(vna, 0);
            this.vna = vna;
            return vna;
        }
        public double calcularVAE() //Calculate the EAA (Equivalent annual annuity)
        {
            double vae = 0;
            vae = (trema * vna) / (1 - Math.Pow(1 + trema, -nper));
            this.vae = vae;
            return vae;
        } 
    }
}
