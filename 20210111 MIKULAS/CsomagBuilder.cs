using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210111_MIKULAS
{
    public partial class CsomagBuilder : Form
    {
        public CsomagBuilder()
        {
            InitializeComponent();
        }

        private void CsomagBuilder_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 0, 0);
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;

            string constring = @"Data Source =| DataDirectory | Resources\mikulascsomag.mdf";
            string query = "SELECT nev FROM belevalok; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string anev = myReader.GetString("nev");
                    comboBox1.Items.Add(anev);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Nem jó");
            }



            this.numericUpDown1.Maximum = new System.Decimal(3000);
            this.numericUpDown1.Minimum = new System.Decimal(0);
            this.numericUpDown1.Value = new System.Decimal(1500);
            this.numericUpDown1.Increment = 100;

            int csomag=0;

            if (csomag > numericUpDown1.Value)
            {
                MessageBox.Show("Meghaladtad a maximum értékkeretet");
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
