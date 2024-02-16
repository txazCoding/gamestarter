using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace gamestarter
{
    public partial class Form1 : Form
    {

        private Dictionary<string, string> gamePaths = new Dictionary<string, string>();
        private FlowLayoutPanel flowLayoutPanelLeft;
        private FlowLayoutPanel flowLayoutPanelRight; // Add declaration
        private System.Windows.Forms.Timer timer;
        private OpenFileDialog openFileDialog; // Add OpenFileDialog declaration

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            InitializeAnimationTimer();
            SetModernBackground();
            InitializeOpenFileDialog(); // Initialize OpenFileDialog
            LoadGamePaths(); // Load saved game paths
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Game Executable";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
        }

        private void InitializeUI()
        {
            // Create FlowLayoutPanel for left and right controls
            flowLayoutPanelLeft = new FlowLayoutPanel();
            flowLayoutPanelLeft.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelLeft.Dock = DockStyle.Left;
            flowLayoutPanelLeft.AutoScroll = false;
            flowLayoutPanelLeft.WrapContents = false;
            flowLayoutPanelLeft.Width = 50;
            flowLayoutPanelLeft.BackColor = Color.FromArgb(64, 64, 64); // Darker gray
            Controls.Add(flowLayoutPanelLeft);

            flowLayoutPanelRight = new FlowLayoutPanel(); // Initialize flowLayoutPanelRight
            flowLayoutPanelRight.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelRight.Dock = DockStyle.Right;
            flowLayoutPanelRight.AutoScroll = false;
            flowLayoutPanelRight.WrapContents = false;
            flowLayoutPanelRight.Width = 250;


            Controls.Add(flowLayoutPanelRight);

            // Manually place textboxes and button on the form
            // Ensure their Name properties match the references in btnAddGame_Click method
            // txtGameName
            // txtGamePath
            // btnAddGame
        }

        private void InitializeAnimationTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void SetModernBackground()
        {
            this.BackColor = Color.FromArgb(64, 64, 64); // Darker gray
        }

        private int currentRow = 0; // Initialize currentRow variable
        private int currentColumn = 0; // Initialize currentColumn variable

        private int buttonCount = 0; // Initialize button count

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            if (buttonCount >= 4) // CAHNGE NUMBER OF BUTTONS IN ONE ROW
            {
                MessageBox.Show("Maximum button limit reached. No more buttons can be added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            openFileDialog.ShowDialog(); // Show the OpenFileDialog

            // Retrieve the selected file path
            string selectedPath = openFileDialog.FileName;

            if (!string.IsNullOrEmpty(selectedPath))
            {
                // Set the selected path in the game path text box
                txtGamePath.Text = selectedPath;

                // Retrieve text from the manually placed textboxes
                string gameName = txtGameName.Text.Trim();

                // Check if the game name or file path is empty
                if (string.IsNullOrEmpty(gameName))
                {
                    MessageBox.Show("Please enter the game name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the game name already exists
                if (gamePaths.ContainsKey(gameName))
                {
                    MessageBox.Show("A game with the same name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the game name and file path to the dictionary
                gamePaths.Add(gameName, selectedPath);

                // Add the game button to the panel
                AddButton(gameName, selectedPath);

                // Save the updated game paths
                SaveGamePaths();

                buttonCount++; // Increment button count
            }
        }

        private void AddButton(string gameName, string gamePath)
        {
            // Create a table layout panel to hold the game button, open folder button, and delete button
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Width = 250; // Adjust the width as needed
            tableLayout.Height = 105;
            tableLayout.ColumnCount = 4;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            // Create the game button
            Button button = new Button();
            button.Text = gameName;
            button.Width = 100;
            button.Height = 105;
            button.Margin = new Padding(5);
            button.BackColor = Color.FromArgb(255, 255, 255); // White
            button.Click += (s, ev) => LaunchGame(gameName);
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;

            // Create the open folder button
            Button openFolderButton = new Button();
            openFolderButton.Text = "Open Folder";
            openFolderButton.Width = 80;
            openFolderButton.Height = 105;
            openFolderButton.Margin = new Padding(5);
            openFolderButton.BackColor = Color.FromArgb(209, 177, 201); // Blue
            openFolderButton.Click += (s, ev) =>
            {
                // Get the directory containing the game executable
                string gameDirectory = System.IO.Path.GetDirectoryName(gamePath);

                // Open the file explorer at the directory containing the game executable
                Process.Start("explorer.exe", gameDirectory);
            };

            // Create the delete button
            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Width = 80;
            deleteButton.Height = 105;
            deleteButton.Margin = new Padding(5);
            deleteButton.BackColor = Color.FromArgb(255, 186, 186); // Red
            deleteButton.Click += (s, ev) =>
            {
                // Remove the game button and its path from the dictionary and the file
                gamePaths.Remove(gameName);
                SaveGamePaths();

                // Remove the table layout panel from the flow layout panel
                flowLayoutPanelRight.Controls.Remove(tableLayout);
            };

            // Add buttons to the table layout panel
            tableLayout.Controls.Add(button, 0, 0);
            tableLayout.Controls.Add(openFolderButton, 1, 0);
            tableLayout.Controls.Add(deleteButton, 2, 0);

            // Add the table layout panel to the flow layout panel
            flowLayoutPanelRight.Controls.Add(tableLayout);

            // Your logic to update currentRow and currentColumn...
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            // Increase the size of the button slightly when mouse enters
            Button button = (Button)sender;
            button.Size = new Size(button.Width + 5, button.Height + 5);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // Revert the size of the button back to the original when mouse leaves
            Button button = (Button)sender;
            button.Size = new Size(button.Width - 5, button.Height - 5);
        }


        private bool IsWithinFormBounds(Point location, Size size)
        {
            Rectangle formBounds = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Rectangle buttonBounds = new Rectangle(location, size);

            return formBounds.Contains(buttonBounds);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            Button button = (Button)timer.Tag;

            // Gradually increase button opacity until fully visible
            if (button.Visible)
            {
                timer.Stop(); // Stop the timer when button is fully visible
            }
            else
            {
                button.Visible = true;
                button.ForeColor = Color.FromArgb(Math.Min(button.ForeColor.R + 10, 255),
                                                   Math.Min(button.ForeColor.G + 10, 255),
                                                   Math.Min(button.ForeColor.B + 10, 255));
                flowLayoutPanelRight.Invalidate(); // Force the flow layout panel to redraw
            }
        }

        private void LaunchGame(string gameName)
        {
            // Check if the game name exists in the dictionary
            if (gamePaths.ContainsKey(gameName))
            {
                // Get the file path corresponding to the game name
                string gamePath = gamePaths[gameName];

                // Open the game file using the default program
                Process.Start(gamePath);
            }
            else
            {
                MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGamePaths()
        {
            // Check if the file exists
            if (File.Exists("gamePaths.txt"))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines("gamePaths.txt");

                foreach (string line in lines)
                {
                    // Split each line into game name and game path
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        // Add game name and game path to the dictionary
                        gamePaths.Add(parts[0], parts[1]);
                        // Add the button to the form
                        AddButton(parts[0], parts[1]);
                    }
                }
            }
        }

        private void SaveGamePaths()
        {
            // Write game paths to a file
            using (StreamWriter writer = new StreamWriter("gamePaths.txt"))
            {
                foreach (var entry in gamePaths)
                {
                    // Write game name and game path separated by a pipe character
                    writer.WriteLine(entry.Key + "|" + entry.Value);
                }
            }
        }
    }
}