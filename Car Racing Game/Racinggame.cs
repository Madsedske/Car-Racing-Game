using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Car_Racing_Game
{
    public partial class Form1 : Form
    {
        TilføjScore navnTilScore = new TilføjScore();
        Leaderboard leaderboard = new Leaderboard();

        public Form1(TilføjScore Form)
        {
            this.navnTilScore = Form;
        }
        public Form1(Leaderboard Form)
        {
            this.leaderboard = Form;
        }

        int gamespeed = 3;
        Random randomGenerator = new Random();
        int coinValue;
        bool moveRight, moveLeft;
        int carSpeed = 12;

        private static int coinsCollected;

        public static int CoinsCollected
        {
            get { return coinsCollected; }
            set { coinsCollected = value; }
        }

        public Form1()
        {
            InitializeComponent();
            LabelGameOver.Visible = false;
            labelSamledeCoins.Visible = false;
            GameSpeedLabel.Text = "Current gamespeed = " + gamespeed;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // A timer for the gamespeed.
            labelSamledeCoins.Visible = false;
            hvideStriber(gamespeed);
            carsKeepSpawn(gamespeed);
            coins(gamespeed);
            gameover();
            coinsCollect();
        }

        void hvideStriber(int speed)
        {
            // Keep the white stripes in a loop.
            if (pictureBoxMidtStribe1.Top >= 601)
                pictureBoxMidtStribe1.Top = -99;
            else
                pictureBoxMidtStribe1.Top += speed;

            if (pictureBoxMidtStribe2.Top >= 601)
                pictureBoxMidtStribe2.Top = -99;
            else
                pictureBoxMidtStribe2.Top += speed;

            if (pictureBoxMidtStribe3.Top >= 601)
                pictureBoxMidtStribe3.Top = -99;
            else
                pictureBoxMidtStribe3.Top += speed;

            if (pictureBoxMidtStribe4.Top >= 601)
                pictureBoxMidtStribe4.Top = -99;
            else
                pictureBoxMidtStribe4.Top += speed;

            if (pictureBoxMidtStribe5.Top >= 601)
                pictureBoxMidtStribe5.Top = -99;
            else
                pictureBoxMidtStribe5.Top += speed;

            if (pictureBoxMidtStribe6.Top >= 601)
                pictureBoxMidtStribe6.Top = -99;
            else
                pictureBoxMidtStribe6.Top += speed;

            if (pictureBoxMidtStribe7.Top >= 601)
                pictureBoxMidtStribe7.Top = -99;
            else
                pictureBoxMidtStribe7.Top += speed;
        }
        
        void carsKeepSpawn(int speed)
        {
            // Keeps spawning the cars at different spawnpoints, so there not leaving the map.
            if (pictureBoxBil1.Top >= 650)
            {
                int xLocationCar = randomGenerator.Next(20, 325);
                pictureBoxBil1.Location = new Point(xLocationCar, -50);
            }
            else pictureBoxBil1.Top += speed;

            if (pictureBoxBil2.Top >= 650)
            {
                int xLocationCar = randomGenerator.Next(20, 325);
                pictureBoxBil2.Location = new Point(xLocationCar, -50);
            }
            else pictureBoxBil2.Top += speed;

            if (pictureBoxBil3.Top >= 650)
            {
                int xLocationCar = randomGenerator.Next(20, 325);
                pictureBoxBil3.Location = new Point(xLocationCar, -50);
            }
            else pictureBoxBil3.Top += speed;

            if (pictureBoxBil4.Top >= 650)
            {
                int xLocationCar = randomGenerator.Next(20, 325);
                pictureBoxBil4.Location = new Point(xLocationCar, -50);
            }
            else pictureBoxBil4.Top += speed;
        }

        public void gameover()
        {
            // Detects collision with the other cars. Then controls the gameover elements.
            if (pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil1.Bounds) || pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil2.Bounds) || pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil3.Bounds) || pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil4.Bounds))
            {
                TilføjScore.CloseScore = false;
                CheckScoreTimer.Enabled = true;
                MoveTimer.Enabled = false;
                timer1.Enabled = false;
                LabelGameOver.Visible = true;
                labelBegin.Visible = true;
                labelSamledeCoins.Visible = true;
                labelSamledeCoins.Text = "Du scorede " + coinsCollected + " mønter";
                navnTilScore.Show();
            }
        }
        void coinsCollect()
        {
            // Adds value for collecting the coins at different gamespeeds.
            if (gamespeed == 3)            
                coinValue = 1;
            
            if (gamespeed == 6)
                coinValue = 2;
            
            if (gamespeed == 9)
                coinValue = 3;

            // Controls the collision when hitting coins and then add them again on the map.
            if (pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxCoin1.Bounds))
            {
                coinsCollected = coinsCollected + coinValue;
                label1.Text = "Coins = " + coinsCollected;
                int xLocationCoins = randomGenerator.Next(20, 335);
                pictureBoxCoin1.Location = new Point(xLocationCoins, -50);
            }
            if (pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxCoin2.Bounds))
            {
                coinsCollected = coinsCollected + coinValue;
                label1.Text = "Coins = " + coinsCollected;
                int xLocationCoins = randomGenerator.Next(20, 335);
                pictureBoxCoin2.Location = new Point(xLocationCoins, -50);
            }
            if (pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxCoin3.Bounds))
            {
                coinsCollected = coinsCollected + coinValue;
                label1.Text = "Coins = " + coinsCollected;
                int xLocationCoins = randomGenerator.Next(20, 335);
                pictureBoxCoin3.Location = new Point(xLocationCoins, -50);
            }
        }

        void coins(int speed)
        {
            // Controls the random spawnpoint for the coins and keep looping them for the map.
            if (pictureBoxCoin1.Top >= 650)
            {
                int xLocationCoins = randomGenerator.Next(20, 335);
                pictureBoxCoin1.Location = new Point(xLocationCoins, -50);
            }
            else pictureBoxCoin1.Top += speed;

            if (pictureBoxCoin2.Top >= 650)
            {
                int xLocationCoins = randomGenerator.Next(20, 335);
                pictureBoxCoin2.Location = new Point(xLocationCoins, -50);
            }
            else pictureBoxCoin2.Top += speed;

            if (pictureBoxCoin3.Top >= 650)
            {
                int xLocationCoins = randomGenerator.Next(20, 335);
                pictureBoxCoin3.Location = new Point(xLocationCoins, -50);
            }
            else pictureBoxCoin3.Top += speed;
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Controls to begin a game.
            if (e.KeyCode == Keys.Space)
            {                    
                CheckScoreTimer.Enabled = false;
                MoveTimer.Enabled = true;
                coinsCollected = 0;
                label1.Text = "Coins = " + coinsCollected;
                LabelGameOver.Visible = false;
                timer1.Start();
                labelBegin.Visible = false;

                //The four cars spawnpoint at the start of the game.
                int xLocationCar1 = randomGenerator.Next(20, 325);
                pictureBoxBil1.Location = new Point(xLocationCar1, -50);
                int xLocationCar2 = randomGenerator.Next(20, 325);
                pictureBoxBil2.Location = new Point(xLocationCar2, -250);
                int xLocationCar3 = randomGenerator.Next(20, 325);
                pictureBoxBil3.Location = new Point(xLocationCar3, -450);
                int xLocationCar4 = randomGenerator.Next(20, 325);
                pictureBoxBil4.Location = new Point(xLocationCar4, -650);

                //The three coins spawnpoint at the start of the game.
                int xLocationCoin1 = randomGenerator.Next(20, 335);
                pictureBoxCoin1.Location = new Point(xLocationCoin1, -140);
                int xLocationCoin2 = randomGenerator.Next(20, 335);
                pictureBoxCoin2.Location = new Point(xLocationCoin2, -340);
                int xLocationCoin3 = randomGenerator.Next(20, 335);
                pictureBoxCoin3.Location = new Point(xLocationCoin3, -540);
            }

            // The next two controls the steering to right and left.
            if (e.KeyCode == Keys.Left)            
                moveLeft = true;                         

            if (e.KeyCode == Keys.Right)            
                moveRight = true; 

            // The next two controls the gamespeed. How fast the cars drive.
            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 10)                
                    gamespeed = gamespeed + 3;         
            GameSpeedLabel.Text = "Current gamespeed = " + gamespeed;
            }
            
            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 3)                
                    gamespeed = gamespeed - 3;
            GameSpeedLabel.Text = "Current gamespeed = " + gamespeed;
            }

            // Controls for see the leaderboard.
            if (e.KeyCode == Keys.Enter)
            {                
                leaderboard.Show();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Controls for steering to right and left.
            if (e.KeyCode == Keys.Left)            
                moveLeft = false;            

            if (e.KeyCode == Keys.Right)            
                moveRight = false;              
        }

        public void CheckScoreTimer_Tick(object sender, EventArgs e)
        {
            switch (TilføjScore.CloseScore)
            {
                case true:
                    navnTilScore.Visible = false;
                    break;
                case false:
                    navnTilScore.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (moveLeft == true && pictureBoxUserCar.Left > 0)            
                pictureBoxUserCar.Left -= carSpeed;   
            
            if (moveRight == true && pictureBoxUserCar.Left < 339)            
                pictureBoxUserCar.Left += carSpeed;            
        }
    }
}