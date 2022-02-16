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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();

            SqlCommand com = new SqlCommand("select * from ouvrage", cn);
            SqlDataReader dr = com.ExecuteReader();
            listBox1.Items.Clear();
            listBox2.Items.Clear();


            while (dr.Read())
            {
                listBox1.Items.Add(dr["nomouvr"].ToString());
                listBox2.Items.Add(dr["numouvr"].ToString());

            }
            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;

            string cs = @"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();

            SqlCommand com = new SqlCommand("select * from ouvrage where numouvr = " +listBox2.Text , cn);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            textBox1.Text = dr[0].ToString();
            textBox2.Text = dr[1].ToString();
            textBox3.Text = dr[2].ToString();
            textBox4.Text = dr[3].ToString();
            textBox5.Text = dr[4].ToString();


            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;

        }
    }
}
