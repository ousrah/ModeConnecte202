using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ModeConnecte202
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();

        
            SqlCommand com = new SqlCommand("select * from ouvrage", cn);
            SqlDataReader dr = com.ExecuteReader();
            listBox1.Items.Clear();
       
            while (dr.Read())
            {
                listBox1.Items.Add(dr["nomouvr"].ToString());
            }

            SqlConnection cn2 = new SqlConnection(cs);
            cn2.Open();

            SqlCommand com2 = new SqlCommand("select * from ecrivain", cn2);

     
            SqlDataReader dr2 = com2.ExecuteReader();
            listBox2.Items.Clear();

            while (dr2.Read())
            {
                listBox2.Items.Add(dr2["nomecr"].ToString());
            }



            dr.Close();
            dr = null;

            dr2.Close();
            dr2 = null;
            com = null;
            cn.Close();
            cn = null;

            com2 = null;
            cn2.Close();
            cn2 = null;
        }
    }
}
