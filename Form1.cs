using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace FinalCyberSecurityBot
{
    public partial class Form1 : Form
    {
        private readonly ChatbotEngine bot = new ChatbotEngine();

        public Form1()
        {
            InitializeForm();

            // Set header text
            ((Label)this.Controls["lblAscii"]).Text = "CYBER BOT";

            // Initial welcome messages
            rtbChat.AppendText("Welcome to the Cybersecurity Awareness Bot!\n");
            rtbChat.AppendText("Type your message below.\n\n");
        }

        private void InitializeForm()
        {
            var initMethod = typeof(Form1).GetMethod(
                "InitializeComponent",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public
            );

            if (initMethod == null)
            {
                throw new InvalidOperationException("Unable to locate InitializeComponent method.");
            }

            initMethod.Invoke(this, null);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput)) return;

            // Show user input
            rtbChat.AppendText($"You: {userInput}\n");

            // Get bot response
            string response = bot.GetResponse(userInput);
            rtbChat.AppendText($"Bot: {response}\n\n");

            // Clear input box
            txtUserInput.Clear();

            // Scroll to bottom
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                // Path to audio file
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");

                // Check if file exists
                if (!File.Exists(soundPath))
                {
                    MessageBox.Show(
                        $"Audio file missing!\n\nPlease make sure your 'greeting.wav' file is inside a folder named 'Assets' at this exact path:\n\n{soundPath}",
                        "File Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Play audio
                using (SoundPlayer player = new SoundPlayer(soundPath))
                {
                    player.PlaySync(); // ensures playback completes
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Audio Error: {ex.Message}", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
