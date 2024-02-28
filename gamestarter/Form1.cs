using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Net.NetworkInformation;

namespace gamestarter
{
    public partial class Form1 : Form
    {

        private Dictionary<string, string> gamePaths = new Dictionary<string, string>();
        private FlowLayoutPanel flowLayoutPanelLeft;
        private FlowLayoutPanel flowLayoutPanelRight; // Add declaration
        private System.Windows.Forms.Timer timer;
        private OpenFileDialog openFileDialog; // Add OpenFileDialog declaration
        private string screenshotFolderPath = "Screenshots"; // Folder for screenshots
        private string highScoreFilePath = "HighScores/highscore.txt"; // File path for high scores


        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            InitializeAnimationTimer();
            SetModernBackground();
            InitializeOpenFileDialog(); // Initialize OpenFileDialog
            LoadGamePaths(); // Load saved game paths
            TakeScreenshot(); // Capture screenshot when the form initializes
            InitializeDirectories(); // Create directories if they don't exist


            // Display the current IP address when the form loads
            ShowCurrentIPAddress();
        }


        private void ShowCurrentIPAddress()
        {
            // Get all network interfaces
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Filter out loopback and disconnected interfaces
            var activeInterfaces = networkInterfaces.Where(ni =>
                ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                ni.OperationalStatus == OperationalStatus.Up);

            // Get the first active interface
            var activeInterface = activeInterfaces.FirstOrDefault();

            // Check if an active interface is found
            if (activeInterface != null)
            {
                // Get the IP properties of the active interface
                var ipProperties = activeInterface.GetIPProperties();

                // Get the IPv4 address
                var ipAddress = ipProperties.UnicastAddresses
                    .FirstOrDefault(addr => addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                    .Address.ToString();

                // Display the IP address on the label
                lblIPAddress.Text = "IP Address: " + ipAddress;
            }
            else
            {
                // If no active interface is found, display a message on the label
                lblIPAddress.Text = "No active network connection";
            }
        }


        private void InitializeDirectories()
        {
            // Create the directory for screenshots if it doesn't exist
            if (!Directory.Exists(screenshotFolderPath))
            {
                Directory.CreateDirectory(screenshotFolderPath);
            }

            // Create the directory for high scores if it doesn't exist
            string highScoreDirectory = Path.GetDirectoryName(highScoreFilePath);
            if (!Directory.Exists(highScoreDirectory))
            {
                Directory.CreateDirectory(highScoreDirectory);
            }
        }

        private void TakeScreenshot()
        {
            // Get the primary screen bounds
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            // Create a bitmap to store the screenshot
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            // Create a graphics object from the bitmap
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Capture the screen
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }

            // Generate a unique filename for the screenshot
            string fileName = $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";

            // Combine the folder path with the filename
            string filePath = Path.Combine(screenshotFolderPath, fileName);

            // Save the screenshot
            bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Game Executable";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeUI()
        {

            flowLayoutPanelRight = new FlowLayoutPanel(); // Initialize flowLayoutPanelRight
            flowLayoutPanelRight.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelRight.Dock = DockStyle.Right;
            flowLayoutPanelRight.AutoScroll = true; // Enable vertical scrollbar only
            flowLayoutPanelRight.WrapContents = false;
            flowLayoutPanelRight.Width = 501;

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
            if (buttonCount >= 4)
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
                    MessageBox.Show("Please enter the name.", "Name missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tableLayout.Width = 478; // Adjust the width as needed
            tableLayout.Height = 83;
            tableLayout.ColumnCount = 40;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            // Create the game button
            Button button = new Button();
            button.Text = gameName;
            button.Width = 150;
            button.Height = 80;
            button.Margin = new Padding(5);
            button.BackColor = Color.FromArgb(255, 255, 255); // White
            button.Click += (s, ev) => LaunchGame(gameName);

            infoLabel.Hide();

            // Create the open folder button
            Button openFolderButton = new Button();
            openFolderButton.Text = "Open Folder";
            openFolderButton.Width = 150;
            openFolderButton.Height = 80;
            openFolderButton.Margin = new Padding(5);
            openFolderButton.BackColor = Color.FromArgb(203, 247, 246); // Blue
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
            deleteButton.Width = 150;
            deleteButton.Height = 80;
            deleteButton.Margin = new Padding(5);
            deleteButton.BackColor = Color.FromArgb(247, 236, 203); // Red
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

        private void newform_Click(object sender, EventArgs e)
        {
            var myForm = new trollform();
            myForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Notesbttn_Click(object sender, EventArgs e)
        {
            var myForm = new penis();
            myForm.Show();
        }
    }
}