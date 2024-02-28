using System;
using System.IO;
using System.Windows.Forms;

namespace gamestarter
{
    public partial class trollform : Form
    {
        int pipespeed = 6;
        int gravity = 0;
        int score = 0;
        int highScore = 0;
        bool gameOver = false;

        public trollform()
        {
            InitializeComponent();
        }

        private void trollform_Load(object sender, EventArgs e)
        {
            LoadHighScore(); // Load high score when the form loads
            RestartGame();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipeBottom.Left -= pipespeed;
            pipeTop.Left -= pipespeed;
            scoreText.Text = "Score: " + score;

            LabelLost.Hide();

            if (!gameOver)
            {
                if (pipeBottom.Left < -150)
                {
                    pipeBottom.Left = 800;
                    PlayerScored(); // Player scored when passing through a pair of pipes
                }
                if (pipeTop.Left < -180)
                {
                    pipeTop.Left = 950;
                    PlayerScored(); // Player scored when passing through a pair of pipes
                }

                if (pipeBottom.Top < -150)
                {
                    pipeBottom.Left = 800;
                    score++;
                }
                if (pipeTop.Bottom < -180)
                {
                    pipeTop.Left = 950;
                    score++;
                }

                if (flappybird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                    flappybird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    flappybird.Bounds.IntersectsWith(ground.Bounds) || flappybird.Top < -25)
                {
                    EndGame();
                }

                if (score > 5)
                {
                    pipespeed = 10;
                }

                if (score > 8)
                {
                    pipespeed = 15;
                }

                if (flappybird.Top < -25)
                {
                    EndGame();
                }
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = -10;
            }
            else if (e.KeyCode == Keys.Space && gameOver)
            {
                RestartGame();
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = 10;
            }
        }

        private void gamekeyisdown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                pipespeed = 10;
            }
        }

        private void gamekeyisup2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                pipespeed = -10;
            }
        }

        private void EndGame()
        {
            gameOver = true;
            gameTimer.Stop();
            LabelLost.Show();

            if (score > highScore)
            {
                highScore = score;
                SaveHighScore();
            }

            highScoreLabel.Text = "High Score: " + highScore;
        }

        private void RestartGame()
        {
            gameOver = false;
            flappybird.Location = new System.Drawing.Point(100, 100);
            // Reset pipe positions to their initial positions
            pipeBottom.Left = 500;
            pipeTop.Left = 500;
            score = 0;
            pipespeed = 5;
            gravity = 0;
            LabelLost.Hide();
            gameTimer.Start();

            // Update the high score label with the loaded high score
            highScoreLabel.Text = "High Score: " + highScore;
        }

        private void SaveHighScore()
        {
            // Save high score to a file
            try
            {
                using (StreamWriter writer = new StreamWriter("highscore.txt"))
                {
                    writer.Write(highScore);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving high score: " + ex.Message);
            }
        }

        private void LoadHighScore()
        {
            // Load high score from a file
            try
            {
                if (File.Exists("highscore.txt"))
                {
                    using (StreamReader reader = new StreamReader("highscore.txt"))
                    {
                        string scoreText = reader.ReadLine();
                        if (!string.IsNullOrEmpty(scoreText))
                        {
                            int.TryParse(scoreText, out highScore);
                        }
                    }
                    highScoreLabel.Text = "High Score: " + highScore; // Update the high score label
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading high score: " + ex.Message);
            }
        }

        // Update high score whenever it changes
        private void UpdateHighScore(int newScore)
        {
            if (newScore > highScore)
            {
                highScore = newScore;
                SaveHighScore();
            }
        }

        // Event handler for when the player scores
        private void PlayerScored()
        {
            score++;
            scoreText.Text = "Score: " + score;
            UpdateHighScore(score); // Update and save high score
        }

    }
}
