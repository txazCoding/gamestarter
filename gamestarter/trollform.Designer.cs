namespace gamestarter
{
    partial class trollform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trollform));
            flappybird = new PictureBox();
            ground = new PictureBox();
            pipeTop = new PictureBox();
            pipeBottom = new PictureBox();
            scoreText = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            LabelLost = new Label();
            highScoreLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)flappybird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pipeTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pipeBottom).BeginInit();
            SuspendLayout();
            // 
            // flappybird
            // 
            flappybird.Image = (Image)resources.GetObject("flappybird.Image");
            flappybird.Location = new Point(46, 193);
            flappybird.Name = "flappybird";
            flappybird.Size = new Size(61, 50);
            flappybird.SizeMode = PictureBoxSizeMode.StretchImage;
            flappybird.TabIndex = 0;
            flappybird.TabStop = false;
            // 
            // ground
            // 
            ground.Image = Properties.Resources.ground;
            ground.Location = new Point(-4, 408);
            ground.Name = "ground";
            ground.Size = new Size(658, 110);
            ground.SizeMode = PictureBoxSizeMode.StretchImage;
            ground.TabIndex = 1;
            ground.TabStop = false;
            // 
            // pipeTop
            // 
            pipeTop.Image = Properties.Resources.pipedown;
            pipeTop.Location = new Point(394, -67);
            pipeTop.Name = "pipeTop";
            pipeTop.Size = new Size(93, 210);
            pipeTop.SizeMode = PictureBoxSizeMode.StretchImage;
            pipeTop.TabIndex = 2;
            pipeTop.TabStop = false;
            // 
            // pipeBottom
            // 
            pipeBottom.Image = Properties.Resources.pipe;
            pipeBottom.Location = new Point(343, 302);
            pipeBottom.Name = "pipeBottom";
            pipeBottom.Size = new Size(93, 187);
            pipeBottom.SizeMode = PictureBoxSizeMode.StretchImage;
            pipeBottom.TabIndex = 3;
            pipeBottom.TabStop = false;
            // 
            // scoreText
            // 
            scoreText.AutoSize = true;
            scoreText.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scoreText.Location = new Point(12, 9);
            scoreText.Name = "scoreText";
            scoreText.Size = new Size(73, 22);
            scoreText.TabIndex = 4;
            scoreText.Text = "Score: 0";
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimerEvent;
            // 
            // LabelLost
            // 
            LabelLost.AutoSize = true;
            LabelLost.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelLost.Location = new Point(262, 189);
            LabelLost.Name = "LabelLost";
            LabelLost.Size = new Size(129, 54);
            LabelLost.TabIndex = 5;
            LabelLost.Text = "You lost Loser\r\n\r\nSpace = Restart\r\n";
            // 
            // highScoreLabel
            // 
            highScoreLabel.AccessibleRole = AccessibleRole.Caret;
            highScoreLabel.AutoSize = true;
            highScoreLabel.Location = new Point(12, 31);
            highScoreLabel.Name = "highScoreLabel";
            highScoreLabel.Size = new Size(0, 15);
            highScoreLabel.TabIndex = 6;
            // 
            // trollform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 513);
            Controls.Add(highScoreLabel);
            Controls.Add(LabelLost);
            Controls.Add(pipeTop);
            Controls.Add(ground);
            Controls.Add(pipeBottom);
            Controls.Add(flappybird);
            Controls.Add(scoreText);
            Name = "trollform";
            Text = "Form2";
            KeyDown += gamekeyisdown;
            KeyUp += gamekeyisup;
            ((System.ComponentModel.ISupportInitialize)flappybird).EndInit();
            ((System.ComponentModel.ISupportInitialize)ground).EndInit();
            ((System.ComponentModel.ISupportInitialize)pipeTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pipeBottom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox flappybird;
        private PictureBox ground;
        private PictureBox pipeTop;
        private PictureBox pipeBottom;
        private Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
        private Label LabelLost;
        private Label highScoreLabel;
    }
}