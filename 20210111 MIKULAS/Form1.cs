using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210111_MIKULAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string dbConnectionString = Properties.Settings.Default.conn;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 0, 0);
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOsztaly settingsForm = new FrmOsztaly();
            settingsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztosan kilépsz?", "Figyelmeztetés", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSorsolas settingsForm = new FrmSorsolas();
            settingsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CsomagBuilder settingsForm = new CsomagBuilder();
            settingsForm.Show();
        }
    }
}
