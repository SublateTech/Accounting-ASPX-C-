using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using System.Configuration;
using AD;
namespace Contabilidad
{

    public partial class frmLoginNew : Form
    {
        public static string cadena = "";
        private BLcontrolPeriodo objcontrolPeriodo;
        private BLUser objBLUser;
        public int hotelID = 0;
        public static DataView dv_usuario;
        public frmLoginNew()
        {
            InitializeComponent();
            objcontrolPeriodo = new BLcontrolPeriodo();
            objBLUser = new BLUser();
        }

        private void frmLoginNew_Load(object sender, EventArgs e)
        {
            // 
            string value;
            DataTable dt = new DataTable();
            dt.Columns.Add("key"); dt.Columns.Add("value");
            dt.Rows.Add("--1", "Seleccione...");
            for (int key = 1; key < 11; key++)
            {
                try
                {
                    value = ConfigurationManager.AppSettings["NombreHotel" + key].ToString();
                }
                catch (Exception ex)
                {
                    value = "";
                }
                if (value != "")
                {
                    dt.Rows.Add(key, value);
                }
            }
            comboBD.DataSource = dt;
            comboBD.DisplayMember = "value";
            comboBD.ValueMember = "key";

        }

        private void cargarUsuarios()
        {
            cboUsuarios.DataSource = null;
            BLUser usuarios = new BLUser();
            DataTable datos = usuarios.fnUsuariosAll();
            DataView vista = datos.AsDataView();
            vista.RowFilter = "Estado=0";
            vista.Sort = "NombreUsuario";
            cboUsuarios.DataSource = vista;
            cboUsuarios.DisplayMember = "NombreUsuario";
            cboUsuarios.ValueMember = "HotelID";
            dv_usuario = vista;

            // string f = dv_usuario[4][77].ToString();
        }

        private int BuscarUsuario(int usuid)
        {
            int hote = 0;

            dv_usuario.RowFilter = "UsuarioID=" + usuid;
            for (int x = 0; x < dv_usuario.Count; x++)
            {
                hote = Convert.ToInt32(dv_usuario[x][77].ToString());
            }

            return hote;
        }


        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.Login();
        }

        private void Login()
        {
            try
            {
                string user = cboUsuarios.Text.Trim();
                string password = this.txtContrasena.Text.Trim();

                if (user == "" || password == "")
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Debe ingresar todos los datos", "Información");
                    //RadMessageBox.Show("Debe ingresar todos los datos", "Información:", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtContrasena.Text = "";
                    // this.cboUsuarios.Focus();
                    // this.cboUsuarios.SelectAll();
                    // return;
                }
                else
                {
                    if (objBLUser.login(user, password))
                    {
                        cDatos.UsuarioID = objBLUser.usuarioId(user);
                        Configuration objConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        objConfig.AppSettings.Settings["last_user"].Value = cboUsuarios.Text;
                        objConfig.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                        //verificar si se habilita totalmente el módulo;
                        BL.BLHotel moduloContabilidad = new BL.BLHotel();
                        DataGridViewSelectedRowCollection row = DGVcontrolPeriodo.SelectedRows;
                        cDatos.EstablecimientoID = Convert.ToInt32(row[0].Cells["EstablecimientoId"].Value.ToString());
                        cDatos.Establecimiento = Convert.ToString(row[0].Cells["nombreEstablecimiento"].Value.ToString());
                        //cDatos.HotelID = Convert.ToInt32(row[0].Cells["sucursal"].Value.ToString());
                        cDatos.HotelID = BuscarUsuario(cDatos.UsuarioID);

                        cDatos.Periodo = Convert.ToInt32(row[0].Cells["NombrePeriodo"].Value.ToString());
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Los datos ingresados son incorrectos", "Error", MessageBoxButtons.OK);
                        this.txtContrasena.Text = "";
                        this.cboUsuarios.Focus();
                        this.cboUsuarios.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Login();
        }
        public void select()
        {
            this.cargarUsuarios();
            //String last_user = ConfigurationManager.AppSettings["last_user"];
            //cboUsuarios.Text = last_user;
            //llenado de grilla
            DGVcontrolPeriodo.DataSource = objcontrolPeriodo.UCO_selectControlPeriodo(0);
            DGVcontrolPeriodo.Columns["PeriodoID"].Visible = false;//
            DGVcontrolPeriodo.Columns["EstablecimientoId"].Visible = false;//
            DGVcontrolPeriodo.Columns["NombrePeriodo"].Visible = true;
            DGVcontrolPeriodo.Columns["nombreEstablecimiento"].Visible = true;
            DGVcontrolPeriodo.Columns["sucursal"].Visible = false;//
            DGVcontrolPeriodo.RowHeadersWidth = 10;
            try
            {
                DGVcontrolPeriodo.Columns["NombrePeriodo"].Width = 100;
                DGVcontrolPeriodo.Columns["NombrePeriodo"].HeaderText = "Periodo";
                DGVcontrolPeriodo.Columns["nombreEstablecimiento"].HeaderText = "Establecimiento";
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            DGVcontrolPeriodo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVcontrolPeriodo.ReadOnly = true;
            DataGridViewSelectedRowCollection row = DGVcontrolPeriodo.SelectedRows;
            try
            {
                cDatos.HotelID = Convert.ToInt32(row[0].Cells["sucursal"].Value.ToString());
                if (cDatos.HotelID > 0)
                {
                    lblHotelNombre.Text = "";
                }
                else
                {
                    lblHotelNombre.Text = "HOTEL NO CONFIGURADO";
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void comboBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cadena = comboBD.SelectedValue.ToString();

                if (cadena.Length == 1 || cadena.Length == 2)
                {
                    if (ConfigurationManager.ConnectionStrings["Coneccion" + cadena].ConnectionString != "")
                    {
                        Connection.cadenaconec = cadena;
                        select();
                    }
                    else
                    {
                        DGVcontrolPeriodo.DataSource = null;
                        cboUsuarios.DataSource = null;


                        MessageBox.Show("Sin Cadena de Coneccion!!");
                    }

                }
                else if (cadena == "--1")
                {
                    DGVcontrolPeriodo.DataSource = null;
                    cboUsuarios.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
