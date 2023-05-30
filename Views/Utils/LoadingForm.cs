using SAD_Préstamos.Entities;
using SAD_Préstamos.Views.Consultations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAD_Préstamos
{
    public partial class LoadingForm : Form
    {
        Panel fatherPanel;
        public Prestamo PrestamoSeleccionado { get; set; }

        public LoadingForm(Panel fatherPanel)
        {
            this.fatherPanel = fatherPanel;
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            processBar.Width += 3;

            if (processBar.Width >= 599)
            {
                process.Stop();

                cSolicitudPrestamos cSolicitudPrestamos = new cSolicitudPrestamos(fatherPanel, PrestamoSeleccionado);

                AbrirFormEnPanel(cSolicitudPrestamos);
            }
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

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text += " DE " + PrestamoSeleccionado.Nombre.ToUpper();
        }
    }
}
