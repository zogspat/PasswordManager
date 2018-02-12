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
            _convertedPassword = _kickoff.StartWithPasswordFromInputBox();
            List<string> _items = new List<string>();
            _items.Add("One"); // <-- Add these
            _items.Add("Two");
            _items.Add("Three");

            secretsListBox.DataSource = _items;



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
                SecretThing newSecret = new SecretThing();
                newSecret.title = titleTextBox.Text;
                newSecret.url = urlTextBox.Text;
                newSecret.comment = commentTextBox.Text;
                newSecret.password = passwordTextBox.Text;
                newSecret.privateKey = keyTextBox.Text;
                _kickoff.secretManager.AddSecret(newSecret, _convertedPassword);
                String _oneLiner = ConvertInputToString();
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

        private void showHideButton_Click(object sender, EventArgs e)
        {

        }

        private void secretsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = secretsListBox.SelectedItem.ToString();
            MessageBox.Show(curItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Console.WriteLine("I fired");
        }
    }
}
