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
        private StartUpActions _kickoff = new StartUpActions();
        private Constants constants = new Constants();
        private DatabaseActions dbActions = new DatabaseActions();
        private CryptoOperations cryptoOps = new CryptoOperations();
        private String _convertedPwd;
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
       {
            if (!constants.databaseExists)
            {
                passwordLabel.Text = "New Password:";
            }
            Console.WriteLine("We're off!");
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
                newSecret.secretId = 1;
                dbActions.WriteSingleResult()
                //String _oneLiner = ConvertInputToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // leaving for now, but to delete...
        private String ConvertInputToString()
        {
            String _concatStr = titleTextBox.Text + "||o||" + urlTextBox.Text + "||o||" + commentTextBox.Text + "||o||" + passwordTextBox.Text + "||o||" + keyTextBox.Text;
            return _concatStr;
        }

        private void showHideButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("listbox: {0}", secretsListBox.Text);
        }

        private void secretsListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           Console.WriteLine("I fired 3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            urlTextBox.Text = "";
            commentTextBox.Text = "";
            passwordTextBox.Text = "";
            keyTextBox.Text = "";
        }


        private void EnterPressedOnPwd(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter!!");
                _kickoff.StartWithPasswordFromInputBox(pwdTextBox.Text);
                
            }

        }

    }
}
