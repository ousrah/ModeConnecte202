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
    public partial class Form1 : Form
    {
        public Form1()
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
            dataGridView1.Rows.Clear();
            while(dr.Read())
            {
                listBox1.Items.Add(dr["nomouvr"].ToString());
                dataGridView1.Rows.Add(dr["numouvr"], dr["nomouvr"]);
            }
            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();

            SqlCommand com = new SqlCommand("select max(prixvente) from tarifer", cn);
            int nb = Convert.ToInt32(com.ExecuteScalar());
            textBox1.Text = nb.ToString() ;



            com = null;
            cn.Close();
            cn = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string cs = @"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();

            SqlCommand com = new SqlCommand("insert into ouvrage values (5432181,'test 202',2022,1,'CLET')", cn);
            com.ExecuteNonQuery();

            com = null;
            cn.Close();
            cn = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
