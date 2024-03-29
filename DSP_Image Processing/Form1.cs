﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DSP_Image_Processing
{
    public partial class Form1 : Form
    {
        private Bitmap oldImage, newImage;
        public List<byte> structureElementVal;
        private ConvolutionBasedFilter ConvFilter;
        private Thresholding imageThreshold;
        private Morphology morphImage;
        public int D0; // Cutoff Frequency
        public int ButterWorthFactor;
        public int ThresholdValue,windowWidth,windowHeight;
        
        public Form1()
        {
            InitializeComponent();
            ConvFilter = new ConvolutionBasedFilter();
            imageThreshold = new Thresholding();
            morphImage = new Morphology();
        }

        private void btn_openPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            oldImage = new Bitmap(openFile.FileName);
            picBox_oldBtmp.Image = oldImage;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            try
            {
                oldImage = new Bitmap(openFile.FileName);
                picBox_oldBtmp.Image = oldImage;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Plz Choose a valid URL\n" + exc.Message); 
            }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = BasicFilters.ToGrayScale(oldImage);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
                 ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                 ProcessingTimeLabel.Visible = true;
        }

        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            picBox_NewBtmp.Image = BasicFilters.invertImage(oldImage);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSizeDialog windowDialog = new WindowSizeDialog(this);
            if (windowDialog.ShowDialog() == DialogResult.OK)
            {
                ConvFilter = new ConvolutionBasedFilter(windowHeight,windowWidth);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                picBox_NewBtmp.Image = ConvFilter.OriginalSmooting(oldImage);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void laplacianEdgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSizeDialog windowDialog = new WindowSizeDialog(this);
            if (windowDialog.ShowDialog() == DialogResult.OK)
            {
                ConvFilter = new ConvolutionBasedFilter(windowHeight, windowWidth);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                picBox_NewBtmp.Image = ConvFilter.LaplacianEdgeDetection(oldImage);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void laplacianSharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSizeDialog windowDialog = new WindowSizeDialog(this);
            if (windowDialog.ShowDialog() == DialogResult.OK)
            {
                ConvFilter = new ConvolutionBasedFilter(windowHeight, windowWidth);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                picBox_NewBtmp.Image = ConvFilter.LaplacianSharpening(oldImage);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSizeDialog windowDialog = new WindowSizeDialog(this);
            if (windowDialog.ShowDialog() == DialogResult.OK)
            {
                ConvFilter = new ConvolutionBasedFilter(windowHeight, windowWidth);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                picBox_NewBtmp.Image = ConvFilter.smoothingFilterOptimized(oldImage);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThresholdingInputDialog thresholdDialog = new ThresholdingInputDialog(this);
            if (thresholdDialog.ShowDialog() == DialogResult.OK)
            {
                imageThreshold = new Thresholding(windowHeight, windowWidth);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                picBox_NewBtmp.Image = imageThreshold.applyStaticThresholding(oldImage, ThresholdValue);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            picBox_NewBtmp.Image = imageThreshold.applyAverageThresholding(BasicFilters.ToGrayScale(oldImage));

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;
        }

        private void adaptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSizeDialog windowDialog = new WindowSizeDialog(this);
            if (windowDialog.ShowDialog() == DialogResult.OK)
            {
                imageThreshold = new Thresholding(windowHeight,windowWidth);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                picBox_NewBtmp.Image = imageThreshold.applyAdaptiveThresholding(BasicFilters.ToGrayScale(oldImage));

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void erossionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Structural_Element_Options seOptions = new Structural_Element_Options(this);
            if (seOptions.ShowDialog() == DialogResult.OK)
            {
                morphImage = new Morphology(windowHeight, windowWidth,structureElementVal);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                picBox_NewBtmp.Image = morphImage.calculateErosion(oldImage);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void boundryDetectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Bitmap erosionResult = morphImage.calculateErosion(oldImage);
            picBox_NewBtmp.Image = BasicFilters.subtractImage(oldImage, erosionResult);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Structural_Element_Options seOptions = new Structural_Element_Options(this);
            if (seOptions.ShowDialog() == DialogResult.OK)
            {
                morphImage = new Morphology(windowHeight, windowWidth,structureElementVal);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                picBox_NewBtmp.Image = morphImage.calculateDilation(oldImage);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
                ProcessingTimeLabel.Visible = true;
            }
        }

        private void idealLowPassFilterMenuItem_Click(object sender, EventArgs e)
        {
            In_frequencyDialog frequencyDialog = new In_frequencyDialog(this);
            if (frequencyDialog.ShowDialog() != DialogResult.OK)
                return;
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = FrequencyDomain.LowPassFilter.applyIdealFilter(oldImage, D0);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;
        }

        private void gaussianLowPassFilterMenuItem_Click(object sender, EventArgs e)
        {
            In_frequencyDialog frequencyDialog = new In_frequencyDialog(this);
            if (frequencyDialog.ShowDialog() != DialogResult.OK)
                return;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = FrequencyDomain.LowPassFilter.applyGaussianFilter(oldImage, D0);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;
        }

        private void idealHighPassFilterMenuItem_Click(object sender, EventArgs e)
        {
            In_frequencyDialog frequencyDialog = new In_frequencyDialog(this);
            if (frequencyDialog.ShowDialog() != DialogResult.OK)
                return;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = FrequencyDomain.HighPassFilter.applyIdealFilter(oldImage, D0);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;

        }

        private void gaussianHighPassFilterMenuItem_Click(object sender, EventArgs e)
        {
            In_frequencyDialog frequencyDialog = new In_frequencyDialog(this);
            if (frequencyDialog.ShowDialog() != DialogResult.OK)
                return;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = FrequencyDomain.HighPassFilter.applyGaussianFilter(oldImage, D0);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;

        }

        private void butterWorthLowPassFilterMenuItem_Click(object sender, EventArgs e)
        {
            In_frequencyDialog frequencyDialog = new In_frequencyDialog(this);
            ButterWorth_FactorDialog factorDialog = new ButterWorth_FactorDialog(this);

            if (frequencyDialog.ShowDialog() != DialogResult.OK) 
                return;
            if (factorDialog.ShowDialog() != DialogResult.OK)
                return;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = FrequencyDomain.LowPassFilter.applyButterWorthFilter(oldImage, D0,ButterWorthFactor);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;
        }

        private void butterWorthHighPassFilterMenuItem_Click(object sender, EventArgs e)
        {
            In_frequencyDialog frequencyDialog = new In_frequencyDialog(this);
            ButterWorth_FactorDialog factorDialog = new ButterWorth_FactorDialog(this);

            if (frequencyDialog.ShowDialog() != DialogResult.OK)
                return;
            if (factorDialog.ShowDialog() != DialogResult.OK)
                return;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            picBox_NewBtmp.Image = FrequencyDomain.HighPassFilter.applyButterWorthFilter(oldImage, D0, ButterWorthFactor);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            ProcessingTimeLabel.Text = "Processing Time : " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds,
                           ts.Milliseconds / 10);
            ProcessingTimeLabel.Visible = true;

        }


    }
}
