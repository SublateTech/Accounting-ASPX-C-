using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Xml;
using System.Configuration;

namespace Contabilidad
{
    public partial class frmConfigurarConexion : Form
    {
        public frmConfigurarConexion()
        {
            InitializeComponent();
        }

        private void frmConfigurarConexion_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            try
            {
                //construyendo la cadena de conexión de acuerdo a los parametros
                //"user id=sa;password=LT2012socios;data source=LAWN\SERVER;initial catalog=shiol_datos"
                StringBuilder Con = new StringBuilder("");
                if (chkAutWindows.Checked == false)
                {
                    //cadena de conexion con autentificación sql server
                    Con.Append("user id=");
                    Con.Append(txtUsuario.Text.Trim());
                    Con.Append(";password=");
                    Con.Append(txtPassword.Text.Trim());
                    Con.Append(";data source=");
                    Con.Append(txtServidor.Text.Trim());
                    Con.Append(";initial catalog=");
                    Con.Append(txtBaseDatos.Text.Trim());
                }
                else
                {
                    //cadena de conexion con autentificación windows
                    Con.Append("data source=");
                    Con.Append(txtServidor.Text.Trim());
                    Con.Append(";initial catalog=");
                    Con.Append(txtBaseDatos.Text.Trim());
                    Con.Append(";Integrated Security=SSPI;");
                }

                string strCon = Con.ToString();
                updateConfigFile(strCon);
                //Create new sql connection
                SqlConnection Db = new SqlConnection();
                //to refresh connection string each time else it will use previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
                Db.ConnectionString = ConfigurationManager.ConnectionStrings["home"].ToString();
                //To check new connection string is working or not
                SqlDataAdapter da = new SqlDataAdapter("select count(*) from parametrosgenerales", Db);

                DataTable dt = new DataTable();

                da.Fill(dt);
            }

            catch (Exception E)
            {

                MessageBox.Show(ConfigurationManager.ConnectionStrings["home"].ToString() +
                    ".Conexión inválida", "Servidor o base de datos incorrectos. " + E.Message);

            }
        }

        public void updateConfigFile(string con)
        {
            //actualizar archivo de configuración
            XmlDocument XmlDoc = new XmlDocument();
            //cargar el archivo de configuracion
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //escribiendo la cadena de conexion
                    try
                    {
                        xElement.FirstChild.Attributes[1].Value = con;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);

                    }

                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
    }
}
