using SAD_Préstamos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_Préstamos.Views.Consultations
{
    public partial class cSolicitudPrestamos : Form
    {
        private Panel fatherPanel;
        public Prestamo PrestamoSeleccionado { get; set; }

        public cSolicitudPrestamos()
        {
            InitializeComponent();
        }

        public cSolicitudPrestamos(Panel fatherPanel, Prestamo PrestamoSeleccionado)
        {
            this.fatherPanel = fatherPanel;
            this.PrestamoSeleccionado = PrestamoSeleccionado;
            InitializeComponent();
            setFields();
        }

        private void setFields()
        {
            //string nombre = prestamos.Select(persona => persona.IdPersona == 1)
            lblNombre.Text = PrestamoSeleccionado.Nombre;
            lblCorreo.Text = PrestamoSeleccionado.Correo;
            lblDireccion.Text = PrestamoSeleccionado.Direccion;
            lblDNI.Text = PrestamoSeleccionado.DNI;
            lblTelefono.Text = PrestamoSeleccionado.Telefono;

            if (PrestamoSeleccionado.Sexo == "M")
                lblSexo.Text = "Masculino";
            else
                lblSexo.Text = "Femenino";

            lblMontoSolicitado.Text = PrestamoSeleccionado.MontoSolicitado.ToString();
            lblPlazo.Text = PrestamoSeleccionado.Plazo;
            lblCuotas.Text = (PrestamoSeleccionado.getPlazoEnAños(PrestamoSeleccionado.Plazo) *12).ToString();

            if (PrestamoSeleccionado.PuntajeCrediticio < 500)
            {
                lblPuntaje.ForeColor = Color.Red;
                lblPuntaje.Text = PrestamoSeleccionado.PuntajeCrediticio.ToString();
            }
            else
            {
                lblPuntaje.ForeColor = Color.LimeGreen;
                lblPuntaje.Text = PrestamoSeleccionado.PuntajeCrediticio.ToString();
            }

            lblIngresosMensuales.Text = PrestamoSeleccionado.IngresosMensuales.ToString();
            lblGastosMensuales.Text = PrestamoSeleccionado.GastosMensuales.ToString();

            if(PrestamoSeleccionado.getMontoNetoMensual() > 0)
            {
                lblMontoNetoMensual.ForeColor = Color.LimeGreen;
                lblMontoNetoMensual.Text = (PrestamoSeleccionado.getMontoNetoMensual()).ToString();
            }
            else
            {
                lblMontoNetoMensual.ForeColor = Color.Red;
                lblMontoNetoMensual.Text = (PrestamoSeleccionado.getMontoNetoMensual()).ToString();
            }

            

            if (PrestamoSeleccionado.MontoPropiedades > 0)
            {
                lblNombrePropiedades.Visible = true;
                lblPropiedades.Visible = true;
                lblPropiedades.Text = PrestamoSeleccionado.MontoPropiedades.ToString();
            }

            if (PrestamoSeleccionado.MontoTerrenos > 0)
            {
                lblNombreTerrenos.Visible = true;
                lblTerrenos.Visible = true;
                lblTerrenos.Text = PrestamoSeleccionado.MontoTerrenos.ToString();
            }

            if (PrestamoSeleccionado.MontoVehiculos > 0)
            {
                lblNombreVehiculos.Visible = true;
                lblVehiculos.Visible = true;
                lblVehiculos.Text = PrestamoSeleccionado.MontoVehiculos.ToString();
            }

            if(PrestamoSeleccionado.getSumaTotalGarantias() > 0)
            {
                gbTotalGarantias.Visible = true;
                lblTotalGarantias.Visible = true;
                lblTotalGarantias.Text = PrestamoSeleccionado.getSumaTotalGarantias().ToString();
            }

            if (PrestamoSeleccionado.CalcularRiesgo() > 50)
            {
                lblRiesgo.ForeColor = Color.Red;
                lblRiesgo.Text = PrestamoSeleccionado.CalcularRiesgo().ToString();
            }
            else
            {
                lblRiesgo.ForeColor = Color.LimeGreen;
                lblRiesgo.Text = PrestamoSeleccionado.CalcularRiesgo().ToString();
            }

            if (PrestamoSeleccionado.EsAptoParaPrestamo() != String.Empty)
            {
                lblAptoPrestamo.ForeColor = Color.LimeGreen;
                lblAptoPrestamo.Text = "SI";
            }
            else
            {
                lblAptoPrestamo.ForeColor = Color.Red;
                lblAptoPrestamo.Text = "NO";
            }

            string Recomendacion;
            if (PrestamoSeleccionado.CalcularRiesgo() > 50)
            {
                Recomendacion = PrestamoSeleccionado.Nombre + " " +
                lblAptoPrestamo.Text.ToLower() +
                " es apto para el préstamo que está solicitando. Tenga en cuenta que el porcentaje de riesgo "+ "("+PrestamoSeleccionado.CalcularRiesgo()+")" + " es muy elevado.\n" +
                "En caso de que quiera aprobar la solicitud de todas formas, se recomienda: \n\tUna cuota mensual de: " +
                Math.Round(PrestamoSeleccionado.CalcularCuotaMensualRecomendada(), 2).ToString() +
                " y una tasa de: " + (PrestamoSeleccionado.CalcularTasaDeInteres() * 100).ToString() + "%.";
                txtRecomendacion.ForeColor = Color.Red;
                txtRecomendacion.Text = Recomendacion;
            }
            else if(PrestamoSeleccionado.EsAptoParaPrestamo() == String.Empty)
            {
                Recomendacion = PrestamoSeleccionado.Nombre + " " +
                lblAptoPrestamo.Text.ToLower() +
                " es apto para el préstamo que está solicitando. Tenga en cuenta que no cumple con ningunos de los requisitos de la empresa.\n" +
                "En caso de que quiera aprobar la solicitud de todas formas, se recomienda: \n\tUna cuota mensual de: " +
                Math.Round(PrestamoSeleccionado.CalcularCuotaMensualRecomendada(), 2).ToString() +
                " y una tasa de: " + (PrestamoSeleccionado.CalcularTasaDeInteres() * 100).ToString() + "%.";
                txtRecomendacion.ForeColor = Color.Red;
                txtRecomendacion.Text = Recomendacion;
            }
            else
            {
                Recomendacion = PrestamoSeleccionado.Nombre + " " +
                lblAptoPrestamo.Text.ToLower() +
                " es apto para el préstamo que está solicitando. Tenga en cuenta que "+PrestamoSeleccionado.EsAptoParaPrestamo() +
                "se recomienda: \n\tUna cuota mensual de: " + Math.Round(PrestamoSeleccionado.CalcularCuotaMensualRecomendada(), 2).ToString() +
                " y una tasa de: " + (PrestamoSeleccionado.CalcularTasaDeInteres()*100).ToString() + "%.";
                txtRecomendacion.ForeColor = Color.LimeGreen;
                txtRecomendacion.Text = Recomendacion;
            }
        }

        private void cSolicitudPrestamos_Load(object sender, EventArgs e)
        {
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pnlBtn.Visible = false;

            Bitmap bm = new Bitmap(this.pnlInfo.Width, this.pnlInfo.Height);
            this.pnlInfo.DrawToBitmap(bm, new Rectangle(0, 0, this.pnlInfo.Width, this.pnlInfo.Height));
            e.Graphics.DrawImage(bm, 6, 0);

            pnlBtn.Visible = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
    }
}
