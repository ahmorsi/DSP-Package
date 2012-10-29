using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSP_Image_Processing
{
    public partial class ThresholdingInputDialog : Form
    {
        Form1 mainForm;
        public ThresholdingInputDialog()
        {
            InitializeComponent();
        }
        public ThresholdingInputDialog(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (txtbox_ThresholdValue.Text != string.Empty)
            {
                mainForm.ThresholdValue = int.Parse(txtbox_ThresholdValue.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Plz Enter a Value");
            }
         
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
