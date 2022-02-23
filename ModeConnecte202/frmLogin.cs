using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ModeConnecte202
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ModeConnecte202.Properties.Settings.librairieConnectionString"].ConnectionString;


            SqlConnection cn = new SqlConnection( cryptage.DecryptSym(System.Convert.FromBase64String(cs), cryptage.cle, cryptage.iv));
            cn.Open();
            string sql = "select * from utilisateur where login = '" + txtLogin.Text + "'";
            SqlCommand com = new SqlCommand(sql, cn);
            SqlDataReader dr = com.ExecuteReader();
            bool passport = false;
            if (dr.Read())
                if (dr["password"].ToString() == cryptage.hash256(txtPassword.Text))
                    passport = true;



            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;
            if (passport)
            {
                this.Hide();
                Form1 f = new Form1();
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("login ou mot de passe incorrect");


        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
