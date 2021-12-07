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
        int gamespeed = 3;
        Random randomGenerator = new Random();
        int coinValue;
        int coinsCollected;
        bool moveRight, moveLeft;
        int carSpeed = 12; 

        public Form1()
        {
            InitializeComponent();
            LabelGameOver.Visible = false;
            labelSamledeCoins.Visible = false;
            GameSpeedLabel.Text = "Current gamespeed = " + gamespeed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelSamledeCoins.Visible = false;
            hvideStriber(gamespeed);
            carsKeepSpawn(gamespeed);
            coins(gamespeed);
            gameover();
            coinsCollect();
        }

        void hvideStriber(int speed)
        {
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

        void gameover()
        {
            if (pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil1.Bounds) || pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil2.Bounds) || pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil3.Bounds) || pictureBoxUserCar.Bounds.IntersectsWith(pictureBoxBil4.Bounds))
            {
                timer1.Enabled = false;
                LabelGameOver.Visible = true;
                labelBegin.Visible = true;
                labelSamledeCoins.Visible = true;
                labelSamledeCoins.Text = "Du scorede " + coinsCollected + " mønter";
            }
        }
        void coinsCollect()
        {
            if (gamespeed == 3)            
                coinValue = 1;
            
            if (gamespeed == 6)
                coinValue = 2;
            
            if (gamespeed == 9)
                coinValue = 3;

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

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                coinsCollected = 0;
                label1.Text = "Coins = " + coinsCollected;
                LabelGameOver.Visible = false;
                timer1.Start();
                labelBegin.Visible = false;

                //The four cars spawnpoint 
                int xLocationCar1 = randomGenerator.Next(20, 325);
                pictureBoxBil1.Location = new Point(xLocationCar1, -50);
                int xLocationCar2 = randomGenerator.Next(20, 325);
                pictureBoxBil2.Location = new Point(xLocationCar2, -250);
                int xLocationCar3 = randomGenerator.Next(20, 325);
                pictureBoxBil3.Location = new Point(xLocationCar3, -450);
                int xLocationCar4 = randomGenerator.Next(20, 325);
                pictureBoxBil4.Location = new Point(xLocationCar4, -650);

                //The three coins spawnpoint
                int xLocationCoin1 = randomGenerator.Next(20, 335);
                pictureBoxCoin1.Location = new Point(xLocationCoin1, -140);
                int xLocationCoin2 = randomGenerator.Next(20, 335);
                pictureBoxCoin2.Location = new Point(xLocationCoin2, -340);
                int xLocationCoin3 = randomGenerator.Next(20, 335);
                pictureBoxCoin3.Location = new Point(xLocationCoin3, -540);
            }

            if (e.KeyCode == Keys.Left)            
                moveLeft = true;                         

            if (e.KeyCode == Keys.Right)            
                moveRight = true; 

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
        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)            
                moveLeft = false;            

            if (e.KeyCode == Keys.Right)            
                moveRight = false;              
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