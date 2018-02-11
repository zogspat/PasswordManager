using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form1 : Form
    {

        private String _convertedPassword;
 
        private StartUpActions _kickoff = new StartUpActions();
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Console.WriteLine("We're off!");
            SecretManager bazinga = new SecretManager();
            SecretThing boink = new SecretThing();
            boink.password = "terribly secret";
            bazinga.AddSecret(boink);
            _convertedPassword = _kickoff.StartWithPasswordFromInputBox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Oi!! Title: {0}", titleTextBox.Text);
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Title is mandatory!");
            }
            else
            {
                String _oneLiner = ConvertInputToString();
                String _encryptedOneLiner = _kickoff.bce.AESEncryption(_oneLiner, _convertedPassword, true);
                Console.WriteLine("_encryptedOneLiner: {0}", _encryptedOneLiner);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private String ConvertInputToString()
        {
            String _concatStr = titleTextBox.Text + "||o||" + urlTextBox.Text + "||o||" + commentTextBox.Text + "||o||" + passwordTextBox.Text + "||o||" + keyTextBox.Text;
            return _concatStr;
        }
    }
}
