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
    public partial class Structural_Element_Options : Form
    {
        Form1 mainForm;
        static int numOfCells  = 3;
        static int cellSize = 40;
        List<TextBox> textboxes = new List<TextBox>();
        int[,] Cells = new int[numOfCells, numOfCells];
        List<byte> values = new List<byte>();

        public Structural_Element_Options()
        {
            InitializeComponent();
            InitGrid();
        }
        public Structural_Element_Options(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.DoubleBuffered = true;
            windowHeight_txt.Text = numOfCells.ToString();
            windowWidth_txt.Text = numOfCells.ToString();

        }

        private void Structural_Element_Options_Load(object sender, EventArgs e)
        {
          

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

                int indexi=0, indexj=0,val;
                mainForm.windowHeight = int.Parse(windowHeight_txt.Text);
                mainForm.windowWidth = int.Parse(windowWidth_txt.Text);
                this.DialogResult = DialogResult.OK;

                for (int i = 0; i < textboxes.Count; i++)
                {
                    val = int.Parse(textboxes[i].Text)*255;
                    if (indexi > numOfCells / 2 )
                        indexi = 0;
                    if (indexj > numOfCells / 2)
                    { indexi++; indexj = 0; }

                    values.Insert(i,(byte) val);
                    indexj++;
                }
                mainForm.structureElementVal = values;
                    this.Close();
            }
            else
            {
                MessageBox.Show("Plz Enter a Value");
            }
        }
        private void btnDrawGrid_Click(object sender, EventArgs e)
        {
            numOfCells = int.Parse(windowHeight_txt.Text);
            Cells = new int[numOfCells, numOfCells];
            InitGrid();
            pnlGridDraw.Refresh();
           
        }
        private void pnlGridDraw_Paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;
            pnlGridDraw.AutoSize = true;
            pnlGridDraw.Width = numOfCells * cellSize + 3;
            pnlGridDraw.Height = numOfCells * cellSize + 3;
            if (this.Width < pnlGridDraw.Width)
                this.Width = pnlGridDraw.Width + 5;
            for (int i = 0; i <= numOfCells; i++)
            {
                g.DrawLine(Pens.Black, i * cellSize, 0, i * cellSize, numOfCells * cellSize);
                g.DrawLine(Pens.Black, 0, i * cellSize, numOfCells * cellSize, i * cellSize);
            }
            int y;
            TextBox myTextBox;
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    myTextBox = new TextBox();
                    y = j * cellSize;

                    myTextBox.Text = Cells[i, j].ToString();
                    myTextBox.TextAlign = HorizontalAlignment.Center;
                    myTextBox.Size = new Size(cellSize - 2, cellSize);
                    myTextBox.Location = new Point(j * cellSize + pnlGridDraw.Location.X + 2, pnlGridDraw.Location.Y + i * cellSize);
                    this.Controls.Add(myTextBox);
                    textboxes.Add(myTextBox);
                    myTextBox.BorderStyle = BorderStyle.Fixed3D;
                    myTextBox.Enabled = true;
                    //t.ReadOnly = true;
                    myTextBox.Show();
                    myTextBox.BringToFront();
                    //t.MouseClick +=  text_MouseClick;
                    myTextBox.MouseClick += text_MouseClick;
                }
            }
            this.Invalidate();
        }
  
        private void text_MouseClick(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "1")
            {
                t.Text = "0";
            }
            else
            {
                t.Text = "1";
            }
        }



        #region GridHelpers
        private void InitGrid()
        {
            textboxes.Clear();
            for (int i = 0; i < numOfCells; i++)
                for (int j = 0; j < numOfCells; j++)
                    Cells[i, j] = 0;
        }
        #endregion

       
    }
}
