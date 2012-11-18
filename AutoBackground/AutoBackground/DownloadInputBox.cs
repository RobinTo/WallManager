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
    public partial class DownloadInputBox : Form
    {
        public DownloadInputBox()
        {
            InitializeComponent();
        }

        string input;
        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public void SetComboBoxDataSource(List<string> s)
        {
            comboBox1.DataSource = s;
        }

        public void SetDefaultTextBoxText(string s)
        {
            textBox1.Text = s;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

    }
}
