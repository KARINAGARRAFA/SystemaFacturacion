using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business;
using Business.Business.Categoria;
using Business.Entity;

namespace Presentation.Forms
{
    public partial class FormRegistroCategoria : Form
    {
        BusinessCategoria CT = new BusinessCategoria();
        public FormRegistroCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var c = new Categoria();
            String msj = "";

            if (txtNombreCategoria.Text.Trim() != "")
            {
                if (txtDescriptionCategoria.Text.Trim() != "")
                {
                    if (Program.Evento == 0)
                    {
                        c.Code_category = txtCodigoCategoria.Text;
                        c.Category_name = txtNombreCategoria.Text;
                        c.Description = txtDescriptionCategoria.Text;
                        c.created_at = DateTime.Today;
                        c.updated_at = DateTime.Today;

                        msj = CT.RegistrarCategoria(c); 
                        if (msj == "Esta Categoria ya ha sido Registrado.")
                        {
                            MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                    }
                    else
                    {
                        c.Code_category = txtCodigoCategoria.Text;
                        c.Category_name = txtNombreCategoria.Text;
                        c.Description = txtDescriptionCategoria.Text;
                        c.updated_at = DateTime.Today;
                        MessageBox.Show( CT.ActualizarCategoria(c), "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese decripcion de la Categoria.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescriptionCategoria.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre de la categoria.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreCategoria.Focus();
            }
            FormListarCategoria categoria = new FormListarCategoria();
            categoria.timer1.Start();
        }
        private void Limpiar()
        {
            txtCodigoCategoria.Text = "";
            txtNombreCategoria.Text = "";
            txtDescriptionCategoria.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
