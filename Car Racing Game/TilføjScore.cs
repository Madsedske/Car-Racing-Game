using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
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

        private int score;

        public TilføjScore()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {         
            score = Form1.CoinsCollected;
            DateTime date = DateTime.Now;
            string dateFormat = date.ToString("dd-MM-yyyy");

            string filename = @"C:\Program Files (x86)\Edske Entertainment\Car Racing Game\LeaderboardDS.xlsx";
            FileInfo fileInfo = new FileInfo(@"C:\Program Files (x86)\Edske Entertainment\Car Racing Game\LeaderboardDS.xlsx");

            fileInfo.IsReadOnly = false;
            string connection = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
            string Command = "insert into [Sheet$] (Name, Score) values ('" + this.textBoxNavn.Text + "'," + this.score + ")";
            
            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(Command, con);
            cmd.ExecuteNonQuery();
            con.Close();

            textBoxNavn.Text = "";
            closeScore = true;
        }

        private void TilføjScore_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNavn.Text = "";
            closeScore = true;
        }
    }
}