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
    public partial class TilføjScore : Form
    {
        private static bool closeScore = false;
        public static bool CloseScore
        {
            get { return closeScore; }
            set { closeScore = value; }
        }
        public TilføjScore()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            textBoxNavn.Text = "";
            int var = Form1.CoinsCollected;
            DateTime date = DateTime.Now;
            string dateFormat = date.ToString("yyyy-MM-dd");
            string navn = textBoxNavn.Text;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Leaderboard"].ToString();
                using (SqlCommand insertCommand = new SqlCommand("Insert_Leaderboard", conn))
                {
                    conn.Open();
                    // Stored procedure - Leaderboard
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@Navn", SqlDbType.NVarChar).Value = navn;
                    insertCommand.Parameters.AddWithValue("@Score", SqlDbType.Int).Value = var;
                    insertCommand.Parameters.AddWithValue("@Dato", SqlDbType.DateTime).Value = dateFormat;
                    insertCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            closeScore = true;
        }

        private void TilføjScore_Load(object sender, EventArgs e)
        {
        }
    }
}