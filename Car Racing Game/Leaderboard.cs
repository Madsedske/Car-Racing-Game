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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Car_Racing_Game
{
    public partial class Leaderboard : Form
    {

        private static bool closeLeaderboard = false;
        public static bool CloseLeaderboard
        {
            get { return closeLeaderboard; }
            set { closeLeaderboard = value; }
        }

        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            closeLeaderboard = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = @"C:\Program Files (x86)\Edske Entertainment\Car Racing Game\LeaderboardDS.xlsx";
            DirectorySecurity dirSec = Directory.GetAccessControl(filename);
            dirSec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            string connection = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
            string Command = "select top 10 Name, Score from [Sheet$] order by score desc";
            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(Command, con);
            OleDbDataAdapter db = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            db.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}