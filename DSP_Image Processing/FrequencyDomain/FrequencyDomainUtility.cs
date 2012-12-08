namespace DSP_Image_Processing.FrequencyDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using MathWorks.MATLAB.NET.Arrays;
    using MathWorks.MATLAB.NET.Utility;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FrequencyDomainUtility
    {
        public static Bitmap applyConvolution(Bitmap oldImg, double[,] H)
        {
            Bitmap filteredImage = new Bitmap(oldImg.Width, oldImg.Height);
            FourierTransform.FourierTransform MATLAB = new FourierTransform.FourierTransform();

            double[,] R = new double[oldImg.Height, oldImg.Width];
            double[,] G = new double[oldImg.Height, oldImg.Width];
            double[,] B = new double[oldImg.Height, oldImg.Width];

            Color Clr;
            for (int i = 0; i < oldImg.Height; i++)
                for (int j = 0; j < oldImg.Width; j++)
                {
                    Clr = oldImg.GetPixel(j, i);
                    R[i, j] = Clr.R;
                    G[i, j] = Clr.G;
                    B[i, j] = Clr.B;
                }

            MWNumericArray NewR = (MWNumericArray)MATLAB.ApplyFrequencyDomainFilter((MWNumericArray)R, (MWNumericArray)H);//Applying the Convolution on the R Component of Original Image
            MWNumericArray NewG = (MWNumericArray)MATLAB.ApplyFrequencyDomainFilter((MWNumericArray)G, (MWNumericArray)H);//Applying the Convolution on the G Component of Original Image
            MWNumericArray NewB = (MWNumericArray)MATLAB.ApplyFrequencyDomainFilter((MWNumericArray)B, (MWNumericArray)H);//Applying the Convolution on the B Component of Original Image

            double[,] realR = (double[,])NewR.ToArray(MWArrayComponent.Real);//Real Part of R Component in Space Domain 
            double[,] realG = (double[,])NewG.ToArray(MWArrayComponent.Real);//Real Part of G Component in Space Domain
            double[,] realB = (double[,])NewB.ToArray(MWArrayComponent.Real);//Real Part of B Component in Space Domain

            for (int i = 0; i < oldImg.Height; ++i)
                for (int j = 0; j < oldImg.Width; ++j)
                {
                    filteredImage.SetPixel(j, i, Color.FromArgb((byte)realR[i, j], (byte)realG[i, j], (byte)realB[i, j]));
                }
            return filteredImage;
        }
    }
}
