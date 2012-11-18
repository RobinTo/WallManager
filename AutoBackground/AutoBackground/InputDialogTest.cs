using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoBackground
{
    public partial class InputDialogTest : Form
    {
        public InputDialogTest()
        {
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        string input;

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public void SetTextboxDefaultText(string newText)
        {
            textBox1.Text = newText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Input = textBox1.Text;
                Close();
                Dispose();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
                Dispose();
            }
        }
    }
}
