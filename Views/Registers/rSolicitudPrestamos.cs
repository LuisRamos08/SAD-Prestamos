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

namespace SAD_Préstamos
{
    public partial class rSolicitudDePrestamos : Form
    {
        Panel fatherPanel = new Panel();
        List<Prestamo> prestamos = new List<Prestamo>();
        public Prestamo PersonaSeleccionada { get; set; }

        public rSolicitudDePrestamos(Panel fatherPanel)
        {
            InitializeComponent();
            this.fatherPanel = fatherPanel;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void propiedadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (propiedadCheckBox.Checked) txtPropiedades.Visible = true;
            else txtPropiedades.Visible = false;
        }

        private void vehiculoCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (vehiculoCheckBox.Checked) txtVehiculos.Visible = true;
            else txtVehiculos.Visible = false;
        }

        private void terrenoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (terrenoCheckBox.Checked) txtTerrenos.Visible = true;
            else txtTerrenos.Visible = false;
        }

        private void rSolicitudPrestamos_Load(object sender, EventArgs e)
        {

            setPrestamosList(prestamos);

            txtDni.Focus();
        }

        private void setPrestamosList(List<Prestamo> prestamos)
        {
            // Préstamo 1
            Prestamo prestamo1 = new Prestamo();
            prestamo1.IdPersona = 1;
            prestamo1.DNI = "101";
            prestamo1.Nombre = "John Doe";
            prestamo1.Direccion = "123 Main St";
            prestamo1.Telefono = "555-1234";
            prestamo1.Correo = "johndoe@example.com";
            prestamo1.Sexo = "M";
            prestamo1.MontoSolicitado = 1000.0;
            prestamo1.Plazo = "12 meses";
            prestamo1.PuntajeCrediticio = 800;
            prestamo1.IngresosMensuales = 3000.0;
            prestamo1.GastosMensuales = 2000.0;
            prestamos.Add(prestamo1);

            // Préstamo 2
            Prestamo prestamo2 = new Prestamo();
            prestamo2.IdPersona = 2;
            prestamo2.DNI = "102";
            prestamo2.Nombre = "Jane Smith";
            prestamo2.Direccion = "456 Elm St";
            prestamo2.Telefono = "555-5678";
            prestamo2.Correo = "janesmith@example.com";
            prestamo2.Sexo = "F";
            prestamo2.MontoSolicitado = 5000.0;
            prestamo2.Plazo = "24 meses";
            prestamo2.PuntajeCrediticio = 400;
            prestamo2.IngresosMensuales = 4000.0;
            prestamo2.GastosMensuales = 2500.0;
            prestamos.Add(prestamo2);

            // Préstamo 3
            Prestamo prestamo3 = new Prestamo();
            prestamo3.IdPersona = 3;
            prestamo3.DNI = "103";
            prestamo3.Nombre = "Alice Johnson";
            prestamo3.Direccion = "789 Oak St";
            prestamo3.Telefono = "555-9012";
            prestamo3.Correo = "alicejohnson@example.com";
            prestamo3.Sexo = "F";
            prestamo3.MontoSolicitado = 2000.0;
            prestamo3.Plazo = "18 meses";
            prestamo3.PuntajeCrediticio = 800;
            prestamo3.IngresosMensuales = 5000.0;
            prestamo3.GastosMensuales = 3000.0;
            prestamos.Add(prestamo3);

            // Préstamo 4
            Prestamo prestamo4 = new Prestamo();
            prestamo4.IdPersona = 4;
            prestamo4.DNI = "87654321";
            prestamo4.Nombre = "Michael Johnson";
            prestamo4.Direccion = "987 Pine St";
            prestamo4.Telefono = "555-3456";
            prestamo4.Correo = "michaeljohnson@example.com";
            prestamo4.Sexo = "M";
            prestamo4.MontoSolicitado = 3000.0;
            prestamo4.Plazo = "12 meses";
            prestamo4.PuntajeCrediticio = 600;
            prestamo4.IngresosMensuales = 2500.0;
            prestamo4.GastosMensuales = 2000.0;
            prestamos.Add(prestamo4);

            // Préstamo 5
            Prestamo prestamo5 = new Prestamo();
            prestamo5.IdPersona = 5;
            prestamo5.DNI = "65432187";
            prestamo5.Nombre = "Emily Davis";
            prestamo5.Direccion = "654 Maple St";
            prestamo5.Telefono = "555-7890";
            prestamo5.Correo = "emilydavis@example.com";
            prestamo5.Sexo = "F";
            prestamo5.MontoSolicitado = 1500.0;
            prestamo5.Plazo = "6 meses";
            prestamo5.PuntajeCrediticio = 400;
            prestamo5.IngresosMensuales = 3500.0;
            prestamo5.GastosMensuales = 1800.0;
            prestamos.Add(prestamo5);

            // Préstamo 6
            Prestamo prestamo6 = new Prestamo();
            prestamo6.IdPersona = 6;
            prestamo6.DNI = "43218765";
            prestamo6.Nombre = "Robert Williams";
            prestamo6.Direccion = "321 Cedar St";
            prestamo6.Telefono = "555-2345";
            prestamo6.Correo = "robertwilliams@example.com";
            prestamo6.Sexo = "M";
            prestamo6.MontoSolicitado = 5000.0;
            prestamo6.Plazo = "24 meses";
            prestamo6.PuntajeCrediticio = 200;
            prestamo6.IngresosMensuales = 4000.0;
            prestamo6.GastosMensuales = 3000.0;
            prestamos.Add(prestamo6);

            // Préstamo 7
            Prestamo prestamo7 = new Prestamo();
            prestamo7.IdPersona = 7;
            prestamo7.DNI = "32187654";
            prestamo7.Nombre = "Sophia Anderson";
            prestamo7.Direccion = "789 Walnut St";
            prestamo7.Telefono = "555-4567";
            prestamo7.Correo = "sophiaanderson@example.com";
            prestamo7.Sexo = "F";
            prestamo7.MontoSolicitado = 2000.0;
            prestamo7.Plazo = "12 meses";
            prestamo7.PuntajeCrediticio = 500;
            prestamo7.IngresosMensuales = 5000.0;
            prestamo7.GastosMensuales = 2500.0;
            prestamos.Add(prestamo7);

            // Préstamo 8
            Prestamo prestamo8 = new Prestamo();
            prestamo8.IdPersona = 8;
            prestamo8.DNI = "21876543";
            prestamo8.Nombre = "Olivia Thompson";
            prestamo8.Direccion = "654 Oak St";
            prestamo8.Telefono = "555-5678";
            prestamo8.Correo = "oliviathompson@example.com";
            prestamo8.Sexo = "F";
            prestamo8.MontoSolicitado = 4000.0;
            prestamo8.Plazo = "18 meses";
            prestamo8.PuntajeCrediticio = 700;
            prestamo8.IngresosMensuales = 4500.0;
            prestamo8.GastosMensuales = 3000.0;
            prestamos.Add(prestamo8);

            // Préstamo 9
            Prestamo prestamo9 = new Prestamo();
            prestamo9.IdPersona = 9;
            prestamo9.DNI = "18765432";
            prestamo9.Nombre = "Ethan Wilson";
            prestamo9.Direccion = "987 Elm St";
            prestamo9.Telefono = "555-6789";
            prestamo9.Correo = "ethanwilson@example.com";
            prestamo9.Sexo = "M";
            prestamo9.MontoSolicitado = 2500.0;
            prestamo9.Plazo = "12 meses";
            prestamo9.PuntajeCrediticio = 500;
            prestamo9.IngresosMensuales = 3500.0;
            prestamo9.GastosMensuales = 2000.0;
            prestamos.Add(prestamo9);

            // Préstamo 10
            Prestamo prestamo10 = new Prestamo();
            prestamo10.IdPersona = 10;
            prestamo10.DNI = "76543218";
            prestamo10.Nombre = "Mia Martin";
            prestamo10.Direccion = "321 Pine St";
            prestamo10.Telefono = "555-7890";
            prestamo10.Correo = "miamartin@example.com";
            prestamo10.Sexo = "F";
            prestamo10.MontoSolicitado = 3500.0;
            prestamo10.Plazo = "24 meses";
            prestamo10.PuntajeCrediticio = 700;
            prestamo10.IngresosMensuales = 4000.0;
            prestamo10.GastosMensuales = 2800.0;
            prestamos.Add(prestamo10);
        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (prestamos.Exists(p => p.DNI == txtDni.Text))
                setPersonaInformation(prestamos.Find(p => p.DNI == txtDni.Text));
                  
        }

        private void setPersonaInformation(Prestamo prestamo)
        {
            txtNombre.Text = prestamo.Nombre;
            txtDireccion.Text = prestamo.Direccion;
            txtTelefono.Text = prestamo.Telefono;
            txtCorreo.Text = prestamo.Correo;
            if (prestamo.Sexo == "M")
                masculinoRadioButton.Checked = true;
            else
                femeninoRadioButton.Checked = true;
            
            if(prestamo.PuntajeCrediticio < 500)
            {
                txtPuntajeCrediticio.ForeColor = Color.Red;
                txtPuntajeCrediticio.Text = prestamo.PuntajeCrediticio.ToString();
            }
            else
            {
                txtPuntajeCrediticio.ForeColor = Color.Green;
                txtPuntajeCrediticio.Text = prestamo.PuntajeCrediticio.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cleanForm();
            txtDni.Focus();
        }

        private void cleanForm()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            masculinoRadioButton.Checked = false;
            femeninoRadioButton.Checked = false;

            txtMontoSolicitado.Value = 0;
            cbPlazo.SelectedIndex = -1;
            
            txtIngresos.Value = 0;
            txtGastos.Value = 0;
            txtPuntajeCrediticio.Text = String.Empty;
            propiedadCheckBox.Checked = false;
            vehiculoCheckBox.Checked = false;
            terrenoCheckBox.Checked = false;
            txtPropiedades.Value = 0;
            txtVehiculos.Value = 0;
            txtTerrenos.Value = 0;
        }

        private void btnProcesarSolicitud_Click(object sender, EventArgs e)
        {
            LoadingForm loadingForm = new LoadingForm(fatherPanel);
            Prestamo prestamo = prestamos.Find(p => p.DNI == txtDni.Text);
            if (prestamo != null)
            {
                prestamo.MontoSolicitado = (double)txtMontoSolicitado.Value;
                prestamo.Plazo = cbPlazo.Text;

                prestamo.IngresosMensuales = (double)txtIngresos.Value;
                prestamo.GastosMensuales = (double)txtGastos.Value;

                prestamo.MontoPropiedades = (double)txtPropiedades.Value;
                prestamo.MontoVehiculos = (double)txtVehiculos.Value;
                prestamo.MontoTerrenos = (double)txtTerrenos.Value;

                loadingForm.PrestamoSeleccionado = prestamo;
            }
            else
            {
                prestamo.Nombre = txtNombre.Text;
                prestamo.DNI = txtDni.Text;
                prestamo.Direccion = txtDireccion.Text;
                prestamo.Telefono = txtTelefono.Text;
                prestamo.Correo = txtCorreo.Text;

                if (masculinoRadioButton.Checked == true)
                    prestamo.Sexo = "M";
                else
                    prestamo.Sexo = "F";

                prestamo.MontoSolicitado = (double)txtMontoSolicitado.Value;
                prestamo.Plazo = cbPlazo.Text;

                prestamo.IngresosMensuales = (double)txtIngresos.Value;
                prestamo.GastosMensuales = (double)txtGastos.Value;

                prestamo.MontoPropiedades = (double)txtPropiedades.Value;
                prestamo.MontoVehiculos = (double)txtVehiculos.Value;
                prestamo.MontoTerrenos = (double)txtTerrenos.Value;
                loadingForm.PrestamoSeleccionado = prestamo;
            }
            AbrirFormEnPanel(loadingForm);
        }

        public void AbrirFormEnPanel(object Formhijo)
        {
            if (this.fatherPanel.Controls.Count > 0)
                this.fatherPanel.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.fatherPanel.Controls.Add(fh);
            this.fatherPanel.Tag = fh;
            fh.Show();
        }
    }
}
