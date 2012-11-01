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
    public partial class WindowSizeDialog : Form
    {
        Form1 mainForm;
        public WindowSizeDialog()
        {
            InitializeComponent();
        }
        public WindowSizeDialog(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (windowHeight_txt.Text != string.Empty && windowWidth_txt.Text != string.Empty)
            {
                mainForm.windowHeight = int.Parse(windowHeight_txt.Text);
                mainForm.windowWidth = int.Parse(windowWidth_txt.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Plz Enter a Value");
            }
        }

       
    }
}
