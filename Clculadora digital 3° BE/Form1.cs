using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Clculadora_digital_3__BE
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta= 2,
        Division= 3,
        Multiplicacion = 4,
        Modulo = 5,
    }
    public partial class frmCalculadora : MaterialSkin.Controls.MaterialForm
    {
        double Valor;
        double Valor2;
        Operacion operador = Operacion.NoDefinida;

        //También crear variable para saber que cálculo se hace.

        public frmCalculadora()
        {
            InitializeComponent();
        }
        private double EjecutarOperacion()
        {
            double resultado = 0;
            switch (operador)
            {
                case Operacion.NoDefinida:
                    break;
                case Operacion.Suma:
                    resultado = Valor + Valor2;
                    break;
                case Operacion.Resta:
                    resultado = Valor - Valor2;
                    break;
                case Operacion.Division:
                   
                    if (Valor == 0)
                    {
                        MessageBox.Show("No se puede dividir entre 0");
                        resultado = 0;
                    }
                    else
                    {

                        resultado = Valor / Valor2;
                    }
                    break;
                case Operacion.Multiplicacion:
                    resultado = Valor * Valor2;
                    break;
                case Operacion.Modulo:
                    resultado = Valor % Valor2;
                    break;
            }
            return resultado;
        }
        private void LeerNumero(string numero)
        {
            if  (txbPantalla.Text == "0" && txbPantalla.Text != null)
                {
                    txbPantalla.Text = numero;
                }
                else
                {
                    txbPantalla.Text += numero;
                }
        }
        private void btnUno_Click(object sender, EventArgs e)
        {

            LeerNumero("1");
        
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            LeerNumero("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }

        
        private void btnSeis_Click(object sender, EventArgs e)
        {
            LeerNumero("6");

        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            if (txbPantalla.Text == "0") {
                return;
            }
            else
            {
                txbPantalla.Text += "0";
            }

        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            LeerNumero("5");

        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            LeerNumero("4");

        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            LeerNumero("7");

        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            LeerNumero("8");

        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            LeerNumero("9");

        }
        private void btnLimpiarEntrada_Click(object sender, EventArgs e)
        {
            txbPantalla.Text = "0";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbPantalla.Text = "0";
            SubTxbPantalla.Clear();
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            if (txbPantalla.Text.Length > 1)
            {
                string txtResultado = txbPantalla.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);
                if (txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    txbPantalla.Text = "0";
                }
                else
                {
                    txbPantalla.Text = txtResultado;
                }
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (Valor2 == 0)
            {
                Valor2 = Convert.ToDouble(txbPantalla.Text);
                SubTxbPantalla.Text += Valor2 + "=";
                double resultado = EjecutarOperacion();
                Valor = 0;
                Valor2 = 0;
                txbPantalla.Text = Convert.ToString(resultado);
            }
        }

        private void btnComa_Click(object sender, EventArgs e)
        {
            if (txbPantalla.Text.Contains(","))
            {
                return;
            }
            txbPantalla.Text += ",";
        }



     
        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;

        }

        private void txbPantalla_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCambiarSigno_Click(object sender, EventArgs e)
        {

        }

      

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubTxbPantalla_TextChanged(object sender, EventArgs e)
        {

        }
        private void ObtenerValor(string operador)
        {
            Valor = Convert.ToDouble (txbPantalla.Text);
            SubTxbPantalla.Text = txbPantalla.Text + operador;
            txbPantalla.Text = "0";
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            ObtenerValor("+");
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {

            operador = Operacion.Resta;
            ObtenerValor("-");
        }
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {

            operador = Operacion.Multiplicacion;
            ObtenerValor("*");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {

            operador = Operacion.Division;
            ObtenerValor("/");

        }

        private void btnPorcentaje_Click(object sender, EventArgs e)

        {
            operador = Operacion.Modulo;
            ObtenerValor("%");
        }
    }
}
