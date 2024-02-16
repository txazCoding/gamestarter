namespace gamestarter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtGamePath = new TextBox();
            txtGameName = new TextBox();
            btnAddGame = new Button();
            openFileDialog1 = new OpenFileDialog();
            Name = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtGamePath
            // 
            txtGamePath.BackColor = Color.FromArgb(64, 64, 64);
            txtGamePath.BorderStyle = BorderStyle.FixedSingle;
            txtGamePath.Enabled = false;
            txtGamePath.Font = new Font("Segoe UI", 11.25F);
            txtGamePath.ForeColor = SystemColors.ButtonHighlight;
            txtGamePath.Location = new Point(12, 237);
            txtGamePath.MaximumSize = new Size(150, 35);
            txtGamePath.Multiline = true;
            txtGamePath.Name = "txtGamePath";
            txtGamePath.ReadOnly = true;
            txtGamePath.Size = new Size(120, 24);
            txtGamePath.TabIndex = 0;
            txtGamePath.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGameName
            // 
            txtGameName.BorderStyle = BorderStyle.FixedSingle;
            txtGameName.Font = new Font("Segoe UI", 11.25F);
            txtGameName.Location = new Point(12, 166);
            txtGameName.MaximumSize = new Size(150, 35);
            txtGameName.Multiline = true;
            txtGameName.Name = "txtGameName";
            txtGameName.Size = new Size(120, 24);
            txtGameName.TabIndex = 1;
            txtGameName.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddGame
            // 
            btnAddGame.BackColor = Color.Transparent;
            btnAddGame.FlatStyle = FlatStyle.Flat;
            btnAddGame.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddGame.ForeColor = SystemColors.ButtonHighlight;
            btnAddGame.Location = new Point(12, 196);
            btnAddGame.MaximumSize = new Size(150, 35);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(120, 35);
            btnAddGame.TabIndex = 2;
            btnAddGame.Text = "Choose File";
            btnAddGame.UseVisualStyleBackColor = false;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            Name.ForeColor = SystemColors.ButtonHighlight;
            Name.Location = new Point(46, 144);
            Name.Name = "Name";
            Name.Size = new Size(49, 19);
            Name.TabIndex = 3;
            Name.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(50, 264);
            label1.Name = "label1";
            label1.Size = new Size(41, 19);
            label1.TabIndex = 4;
            label1.Text = "Path";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(900, 450);
            Controls.Add(label1);
            Controls.Add(Name);
            Controls.Add(btnAddGame);
            Controls.Add(txtGameName);
            Controls.Add(txtGamePath);
            MaximumSize = new Size(916, 489);
            MinimumSize = new Size(416, 489);
            Opacity = 0.95D;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "resizer";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGamePath;
        private TextBox txtGameName;
        private Button btnAddGame;
        private OpenFileDialog openFileDialog1;
        private Label Name;
        private Label label1;
    }
}
