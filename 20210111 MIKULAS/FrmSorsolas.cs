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
    public partial class FrmSorsolas : Form
    {
        public FrmSorsolas()
        {
           
            InitializeComponent();
        }

        private void FrmSorsolas_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 0, 0);
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;


            OleDbConnection oledbCnn;
            OleDbDataAdapter oledbAdapter;
            DataSet ds = new DataSet();
            string sql = null;
            int i = 0;

            sql = "Select * from emberek";

            oledbCnn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0" + @"Data Source=|DataDirectory|Resources\mikulascsomag.mdf");
            try
            {
                oledbCnn.Open();
                oledbAdapter = new OleDbDataAdapter(sql, oledbCnn);
                oledbAdapter.Fill(ds);
                dgvsors.DataSource = ds;
 
                oledbAdapter.Dispose();
                oledbCnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HIBA! ");
            }

        }
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // We assume every cell is valid
            // and then we'll loop until we find one that isn't.    
            var allValid = true;
            foreach (DataGridViewRow row in dgvsors.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var v = cell.Value;
                    if (v == null || v == DBNull.Value || string.IsNullOrEmpty(v?.ToString()))
                    {
                        allValid = false;
                        break;
                    }
                }

                if (!allValid) break;
            }

            button1.Enabled = allValid;
            button2.Enabled = allValid;
        }

        private void dgvsors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public System.Data.OleDb.OleDbCommand SelectCommand { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection oledbCnn;
            OleDbDataAdapter oledbAdapter;
            DataSet ds = new DataSet();
            string sql = null;
            int i = 0;

            sql = "SELECT * FROM emberek ORDER BY NEWID()";

            oledbCnn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0" + @"Data Source=|DataDirectory|Resources\mikulascsomag.mdf");
            try
            {
                oledbCnn.Open();
                oledbAdapter = new OleDbDataAdapter(sql, oledbCnn);
                oledbAdapter.Fill(ds);
                dgvsors.DataSource = ds;

                oledbAdapter.Dispose();
                oledbCnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba");
            }
        }
    }
}
