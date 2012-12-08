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
    public partial class ButterWorth_FactorDialog : Form
    {
        Form1 mainForm;
        public ButterWorth_FactorDialog()
        {
            InitializeComponent();
        }
        public ButterWorth_FactorDialog(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txtBox_Factor.Text != string.Empty)
            {
                mainForm.ButterWorthFactor = int.Parse(txtBox_Factor.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
