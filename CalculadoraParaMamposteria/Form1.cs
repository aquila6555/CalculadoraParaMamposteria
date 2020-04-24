using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace CalculadoraParaMamposteria
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
           
                        
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //calculamos el area del muro
            double altoM, areaM, largoM;

            altoM = double.Parse(txtMuroAlto.Text);

            largoM = double.Parse(txtMurLargo.Text);

            areaM = altoM * largoM;

            //valores de la junta
            double junta;
            junta = 1.5;

            //calculamos el area del ladrillo + junta
            double altoL, largoL, anchoL, areaL, altoLJ, largoLJ;

            anchoL = double.Parse(txtLadrilloAncho.Text);
            anchoL = anchoL / 100;

            altoL = double.Parse(txtLadrilloAlto.Text);

            altoLJ = (altoL + junta) / 100;

            altoL = altoL / 100;




            largoL = double.Parse(txtLadrilloLargo.Text);
            largoLJ = (largoL + junta) / 100;

            largoL = largoL / 100;

            areaL = largoLJ * altoLJ;

            //cantidad de ladrillos
            double CantLadri;

            CantLadri = areaM / areaL;

            if (CantLadri < 0.5)
            {
                CantLadri = Math.Round(CantLadri);
                MessageBox.Show("la cantidad de ladrillos necesaria es: " + Math.Round(CantLadri).ToString());
            }
            else
            {
                CantLadri = Math.Ceiling(CantLadri);
                MessageBox.Show("la cantidad de ladrillos necesaria es: " + Math.Ceiling(CantLadri).ToString());
            }


            //calcular el volumen del mortero

            double vMortero;
            vMortero = (largoM * altoM * anchoL) - (CantLadri * largoL * altoL * anchoL);

           



            double arena = 0, cemento = 0, agua = 0;


            switch (cboTipoMortero.Text)
            {
                case "1:2": cemento = 610; arena = 0.97; agua = 250; break;
                case "1:3": cemento = 454; arena = 1.10; agua = 250; break;
                case "1:4": cemento = 364; arena = 1.16; agua = 240; break;
                case "1:5": cemento = 302; arena = 1.20; agua = 240; break;
                case "1:6": cemento = 261; arena = 1.20; agua = 235; break;
            }

            //calculamos la cantidad de cemento 

            cemento = (cemento * vMortero) * 1.05;

            //calculamos la cantidad de arena

            arena = (arena * vMortero);

            //calculamos la cantidad de agua

            agua = (agua * vMortero);

            cemento = Math.Ceiling(cemento);
            MessageBox.Show("la cantidad de cemento necesaria es: " + cemento.ToString());

            MessageBox.Show("la cantidad de arena necesaria es: " + arena.ToString());
            agua = Math.Ceiling(agua);
            MessageBox.Show("la cantidad de agua necesaria es: " + agua.ToString());


            txtLadrilloAlto.Clear();
            txtLadrilloAncho.Clear();
            txtLadrilloLargo.Clear();
            txtMurLargo.Clear();
            txtMuroAlto.Clear();

        }
    }
}
