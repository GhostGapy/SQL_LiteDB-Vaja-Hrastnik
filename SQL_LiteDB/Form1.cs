using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQL_LiteDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "SELECT * FROM pesmi;";

                    //cmd.ExecuteNonQuery();
                    
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string ime = reader.GetString(1);
                        string priimek = reader.GetString(2);
                        string naslov = reader.GetString(3);

                        MessageBox.Show(ime + " " + priimek + ": " + naslov);
                    }
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
    }
}
