using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210111_MIKULAS
{
    public partial class FrmOsztaly : Form
    {
        public FrmOsztaly()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmOsztaly_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 0, 0);
            button1.BackColor = Color.White;
            btnadd.BackColor = Color.White;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            textBox1.Text =
            ofd.ShowDialog() == DialogResult.OK
            ? ofd.FileName
            : null;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            btnadd.Enabled = false;

            if (textBox1 != null)
            {
                btnadd.Enabled = true;
            }

            string filePath = "osztalynevsor.txt";
            string nev;
            int index;

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                index = line.IndexOf("=");
                nev = line.Substring(0, index);

                InsertIntoDatabaseMethod(nev);
            }

            file.Close();
        }

        private static void InsertIntoDatabaseMethod(string nev)
        {
            string dbConnectionString = Properties.Settings.Default.conn;

            string query = "INSERT INTO [emberek] (Nev) VALUES (@Nev) ";

            using (SqlConnection cn = new SqlConnection(dbConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@nev", SqlDbType.VarChar, 50).Value = nev;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

    }
}
