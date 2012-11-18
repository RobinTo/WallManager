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
    public partial class ConfirmBox : Form
    {
        public ConfirmBox(string confirmText)
        {
            InitializeComponent();
            labelText.Text = confirmText;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

    }
}
