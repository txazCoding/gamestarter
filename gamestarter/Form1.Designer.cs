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
            openFileDialog1 = new OpenFileDialog();
            txtGamePath = new TextBox();
            newform = new Button();
            label1 = new Label();
            Name = new Label();
            btnAddGame = new Button();
            txtGameName = new TextBox();
            Notesbttn = new Button();
            lblIPAddress = new Label();
            infoLabel = new Label();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtGamePath
            // 
            txtGamePath.BackColor = Color.FromArgb(64, 64, 64);
            txtGamePath.BorderStyle = BorderStyle.None;
            txtGamePath.Enabled = false;
            txtGamePath.Font = new Font("Segoe UI", 11.25F);
            txtGamePath.ForeColor = SystemColors.ButtonHighlight;
            txtGamePath.Location = new Point(128, 256);
            txtGamePath.MaximumSize = new Size(150, 180);
            txtGamePath.Multiline = true;
            txtGamePath.Name = "txtGamePath";
            txtGamePath.ReadOnly = true;
            txtGamePath.Size = new Size(150, 180);
            txtGamePath.TabIndex = 0;
            txtGamePath.TextAlign = HorizontalAlignment.Center;
            // 
            // newform
            // 
            newform.BackColor = Color.White;
            newform.FlatStyle = FlatStyle.Flat;
            newform.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newform.ForeColor = Color.Beige;
            newform.Image = Properties.Resources.bird;
            newform.Location = new Point(12, 371);
            newform.Name = "newform";
            newform.Size = new Size(87, 65);
            newform.TabIndex = 5;
            newform.UseVisualStyleBackColor = false;
            newform.Click += newform_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(185, 234);
            label1.Name = "label1";
            label1.Size = new Size(41, 19);
            label1.TabIndex = 4;
            label1.Text = "Path";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            Name.ForeColor = SystemColors.ButtonHighlight;
            Name.Location = new Point(177, 144);
            Name.Name = "Name";
            Name.Size = new Size(49, 19);
            Name.TabIndex = 3;
            Name.Text = "Name";
            // 
            // btnAddGame
            // 
            btnAddGame.BackColor = Color.Transparent;
            btnAddGame.FlatStyle = FlatStyle.Flat;
            btnAddGame.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddGame.ForeColor = SystemColors.ButtonHighlight;
            btnAddGame.Location = new Point(128, 196);
            btnAddGame.MaximumSize = new Size(150, 35);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(150, 35);
            btnAddGame.TabIndex = 2;
            btnAddGame.Text = "Choose File";
            btnAddGame.UseVisualStyleBackColor = false;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // txtGameName
            // 
            txtGameName.BorderStyle = BorderStyle.FixedSingle;
            txtGameName.Font = new Font("Segoe UI", 11.25F);
            txtGameName.Location = new Point(128, 166);
            txtGameName.MaximumSize = new Size(150, 35);
            txtGameName.Multiline = true;
            txtGameName.Name = "txtGameName";
            txtGameName.Size = new Size(150, 24);
            txtGameName.TabIndex = 1;
            txtGameName.TextAlign = HorizontalAlignment.Center;
            // 
            // Notesbttn
            // 
            Notesbttn.BackColor = Color.White;
            Notesbttn.FlatStyle = FlatStyle.Flat;
            Notesbttn.Location = new Point(307, 374);
            Notesbttn.Name = "Notesbttn";
            Notesbttn.Size = new Size(87, 65);
            Notesbttn.TabIndex = 6;
            Notesbttn.Text = "Work in progress";
            Notesbttn.UseVisualStyleBackColor = false;
            Notesbttn.Click += Notesbttn_Click;
            // 
            // lblIPAddress
            // 
            lblIPAddress.AutoSize = true;
            lblIPAddress.Font = new Font("Tahoma", 12F, FontStyle.Italic, GraphicsUnit.Point, 177);
            lblIPAddress.ForeColor = Color.White;
            lblIPAddress.Location = new Point(12, 9);
            lblIPAddress.Name = "lblIPAddress";
            lblIPAddress.Size = new Size(51, 19);
            lblIPAddress.TabIndex = 7;
            lblIPAddress.Text = "label2";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.ForeColor = Color.White;
            infoLabel.Location = new Point(590, 196);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(169, 15);
            infoLabel.TabIndex = 8;
            infoLabel.Text = "added apps will be shown here";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(900, 450);
            Controls.Add(infoLabel);
            Controls.Add(lblIPAddress);
            Controls.Add(Notesbttn);
            Controls.Add(newform);
            Controls.Add(label1);
            Controls.Add(Name);
            Controls.Add(btnAddGame);
            Controls.Add(txtGameName);
            Controls.Add(txtGamePath);
            Cursor = Cursors.Cross;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(916, 489);
            MinimumSize = new Size(416, 489);
            Opacity = 0.98D;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "kys";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private TextBox txtGamePath;
        private Button newform;
        private Label label1;
        private Label Name;
        private Button btnAddGame;
        private TextBox txtGameName;
        private Button Notesbttn;
        private Label lblIPAddress;
        private Label infoLabel;
    }
}
