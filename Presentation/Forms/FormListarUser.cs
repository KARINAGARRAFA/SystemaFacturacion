﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business;
using Business.Business.User;
using Business.Entity;
using Presentation.Forms;

namespace Presentation.Forms
{
    public partial class FormListarUser : Form
    {
        int listado = 0;

        BusinessUser USER = new BusinessUser();
        public FormListarUser()
        {
            InitializeComponent();
        }

        private void FormListarUser_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;

            CargarListado();
            dataGridView1.ClearSelection();
        }
        private void CargarListado()
        {

            DataTable dt = new DataTable();
            dt = USER.ListarUsuario();
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (listado)
            {
                case 0: CargarListado(); break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistroUsuario Us = new FormRegistroUsuario();
            if (dataGridView1.SelectedRows.Count > 0)
                Program.Evento = 1;
            else
                Program.Evento = 0;
            dataGridView1.ClearSelection();
            Us.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormRegistroUsuario Us = new FormRegistroUsuario();
                Us.txtRuc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Us.txtNombreEmpresa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Us.txtBrand.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Us.txtCodSector.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Us.txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Us.txtEmail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Us.txtTelefono.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                Us.txtStatus.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                Us.txtCondicion.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                Us.Show();

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //  DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var Us = new User();
            String msj = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {

                //FrmRegistroProductos P = new FrmRegistroProductos();
                Us.Code_ruc = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está Seguro que Desea Eliminar.?", "Sistema de Facturacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    msj = USER.DeleteUsuario(Us);
                    MessageBox.Show(msj, "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Facturacion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
