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
            StartUpActions kickoff = new StartUpActions();
            kickoff.StartWithPasswordFromInputBox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Oi!!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
