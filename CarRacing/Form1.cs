using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameOver.Visible = false;
            pointsLabel.Visible = true;
            btnRestart.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gameSpeed);
            enemy(gameSpeed);
            coin(gameSpeed);
            strawberry(gameSpeed);
            penguin(gameSpeed);
            gameover();
            coinsCollection();
            bonusPoints();
        }

        int collectedCoins = 0;

        Random r = new Random();
        int x;
        void enemy(int speed)
        {
            if (enemy1.Top >= 500)
            { x = r.Next(0, 100);
                enemy1.Location = new Point(x, 0);
            }
            else
            { enemy1.Top += speed; }

            if (enemy2.Top >= 500)
            {
                x = r.Next(0, 300);
                enemy2.Location = new Point(x, 0);
            }
            else
            { enemy2.Top += speed; }

            if (enemy3.Top >= 500)
            {
                x = r.Next(50,300);
                enemy3.Location = new Point(x, 0);
            }
            else
            { enemy3.Top += speed; }

        }

        void coin(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(50, 300);
                coin1.Location = new Point(x, 0);
            }
            else
            { coin1.Top += speed; }

            if (coin2.Top >= 500)
            {
                x = r.Next(0, 200);
                coin2.Location = new Point(x, 0);
            }
            else
            { coin2.Top += speed; }

            if (coin3.Top >= 500)
            {
                x = r.Next(0, 100);
                coin3.Location = new Point(x, 0);
            }
            else
            { coin3.Top += speed; }

            if (coin4.Top >= 500)
            {
                x = r.Next(50, 300);
                coin4.Location = new Point(x, 0);
            }
            else
            { coin4.Top += speed; }
        }

        void strawberry(int speed)
        {
            if (strawberry1.Top >= 500)
            {
                x = r.Next(50, 300);
                strawberry1.Location = new Point(x, 0);
            }
            else
            { strawberry1.Top += speed; }
        }

        void penguin(int speed)
        {
            if (penguin1.Top >= 500)
            {
                x = r.Next(50, 300);
                penguin1.Location = new Point(x, 0);
            }
            else
            { penguin1.Top += speed; }
        }

        void gameover ()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                gameOver.Visible = true;
                btnRestart.Visible = true;
            }
            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                gameOver.Visible = true;
                btnRestart.Visible = true;
            }
            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                gameOver.Visible = true;
                btnRestart.Visible = true;
            }
        }

        void restart()
        {

        }

        void coinsCollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedCoins++;
                pointsLabel.Text = "Coins = " + collectedCoins.ToString();
                x = r.Next(50, 300);
                coin1.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedCoins++;
                pointsLabel.Text = "Coins = " + collectedCoins.ToString();
                x = r.Next(0, 200);
                coin2.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedCoins++;
                pointsLabel.Text = "Coins = " + collectedCoins.ToString();
                x = r.Next(0, 100);
                coin3.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedCoins++;
                pointsLabel.Text = "Coins = " + collectedCoins.ToString();
                x = r.Next(50, 300);
                coin4.Location = new Point(x, 0);
            }
        }

        void bonusPoints()
        {
            if (car.Bounds.IntersectsWith(strawberry1.Bounds))
            {
                collectedCoins = collectedCoins + 5;
                pointsLabel.Text = "Coins = " + collectedCoins.ToString();
                x = r.Next(50, 300);
                strawberry1.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(penguin1.Bounds))
            {
                collectedCoins = collectedCoins - 3;
                pointsLabel.Text = "Coins = " + collectedCoins.ToString();
                x = r.Next(50, 300);
                penguin1.Location = new Point(x, 0);
            }
        }

        void moveLine (int speed)
        {
            if (pictureBox1.Top >= 500)
            {pictureBox1.Top = 0;}
            else
            {pictureBox1.Top += speed;}

            if (pictureBox2.Top >= 500)
            { pictureBox2.Top = 0; }
            else
            { pictureBox2.Top += speed; }

            if (pictureBox3.Top >= 500)
            { pictureBox3.Top = 0; }
            else
            { pictureBox3.Top += speed; }

            if (pictureBox4.Top >= 500)
            { pictureBox4.Top = 0; }
            else
            { pictureBox4.Top += speed; }
        }

        int gameSpeed = 2;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 15)
                car.Left -= 8;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Left < 260)
                car.Left += 8;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (gameSpeed < 21)
                {
                    gameSpeed++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gameSpeed > 0)
                {
                    gameSpeed--;
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e) => Application.Restart();
    }
}
