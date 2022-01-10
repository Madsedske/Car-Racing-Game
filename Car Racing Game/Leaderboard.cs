using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Racing_Game
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Leaderboard"].ToString();
                conn.Open();
                SqlCommand command = new SqlCommand($"select top 10 navn, score, dato from leaderboard order by score desc;", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(reader[0]));
                        item.SubItems.Add(Convert.ToString(reader[1]));
                        item.SubItems.Add(Convert.ToString(reader[2]));
                        listView1.Items.Add(item);
                    }
                }
                conn.Close();
            }
        } 
    }
}
