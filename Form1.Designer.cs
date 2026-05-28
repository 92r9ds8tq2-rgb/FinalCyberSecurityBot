using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalCyberSecurityBot
{
partial class Form1
{
private System.ComponentModel.IContainer _components = null;
private RichTextBox rtbChat;
private TextBox txtUserInputControl;
private Button btnSendControl;
private Button btnPlayControl;
private Label lblAscii;

protected override void Dispose(bool disposing)
{
if (disposing && (_components != null))
{
_components.Dispose();
}
base.Dispose(disposing);
}

private void InitializeComponent()
{
rtbChat = new RichTextBox();
txtUserInputControl = new TextBox();
btnSendControl = new Button();
btnPlayControl = new Button();
lblAscii = new Label();
SuspendLayout();

// Window Canvas Configurations
BackColor = Color.Black;
ClientSize = new Size(800, 500);
Text = "Cybersecurity Awareness Bot";
StartPosition = FormStartPosition.CenterScreen;

// Header UI Text
lblAscii.Location = new Point(20, 20);
lblAscii.ForeColor = Color.Lime;
lblAscii.Size = new Size(200, 50);
lblAscii.Font = new Font("Consolas", 16F, FontStyle.Bold);

// Rich Text Chat Console
rtbChat.Location = new Point(20, 100);
rtbChat.Size = new Size(740, 250);
rtbChat.BackColor = Color.FromArgb(15, 15, 15);
rtbChat.ForeColor = Color.Lime;
rtbChat.Font = new Font("Consolas", 10F);
rtbChat.ReadOnly = true;

// Interactive Text Box Input
txtUserInputControl.Location = new Point(20, 380);
txtUserInputControl.Size = new Size(500, 30);
txtUserInputControl.BackColor = Color.FromArgb(30, 30, 30);
txtUserInputControl.ForeColor = Color.White;
txtUserInputControl.Font = new Font("Segoe UI", 11F);

// Enter Key functionality assignment
txtUserInputControl.KeyDown += (s, e) => {
if (e.KeyCode == Keys.Enter) {
btnSendControl.PerformClick();
e.SuppressKeyPress = true;
}
};

// Buttons setup
btnSendControl.Text = "Send";
btnSendControl.Location = new Point(540, 380);
btnSendControl.Size = new Size(95, 30);
btnSendControl.Click += new EventHandler(btnSend_Click);

btnPlayControl.Text = "Play";
btnPlayControl.Location = new Point(650, 380);
btnPlayControl.Size = new Size(110, 30);
btnPlayControl.Click += new EventHandler(btnPlay_Click);

// Append UI items
Controls.Add(lblAscii);
Controls.Add(rtbChatControl);
Controls.Add(txtUserInputControl);
Controls.Add(btnSendControl);
Controls.Add(btnPlayControl);

ResumeLayout(false);
PerformLayout();
}

    }
}
