namespace gamestarter
{
    partial class penis
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
            drawCrossButton = new Button();
            SuspendLayout();
            // 
            // drawCrossButton
            // 
            drawCrossButton.Location = new Point(339, 193);
            drawCrossButton.Name = "drawCrossButton";
            drawCrossButton.Size = new Size(75, 23);
            drawCrossButton.TabIndex = 0;
            drawCrossButton.Text = "button1";
            drawCrossButton.UseVisualStyleBackColor = true;
            // 
            // penis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(drawCrossButton);
            Name = "penis";
            Text = "penis";
            ResumeLayout(false);
        }

        #endregion

        private Button drawCrossButton;
    }
}