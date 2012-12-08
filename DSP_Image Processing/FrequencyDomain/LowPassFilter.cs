// -----------------------------------------------------------------------
// <copyright file="LowPassFilter.cs" company="Hewlett-Packard">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System.Drawing;
using System.Drawing.Imaging;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using FourierTransform;

namespace DSP_Image_Processing.FrequencyDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LowPassFilter
    {
        public static Bitmap applyIdealFilter(Bitmap oldImg, int D0)
        {
            double[,] H = new double[oldImg.Height, oldImg.Width];

            int X0 = oldImg.Width / 2; // Origin X in the Frequency domain
            int Y0 = oldImg.Height / 2;// Origin Y in the Frequency domain

            for (int i = 0; i < H.GetLength(0); i++)
                for (int j = 0; j < H.GetLength(1); j++)
                {
                    double distance = Math.Sqrt(((i - Y0) * (i - Y0)) + ((j - X0) * (j - X0)));
                    if (distance > D0)
                        H[i, j] = 0;
                    else
                        H[i, j] = 1;
                }

            return FrequencyDomainUtility.applyConvolution(oldImg, H);
        }
        public static Bitmap applyGaussianFilter(Bitmap oldImg, int D0)
        {
            double[,] H = new double[oldImg.Height, oldImg.Width];

            int X0 = oldImg.Width / 2; // Origin X in the Frequency domain
            int Y0 = oldImg.Height / 2;// Origin Y in the Frequency domain

            for (int i = 0; i < H.GetLength(0); i++)
                for (int j = 0; j < H.GetLength(1); j++)
                {
                    double distance = Math.Sqrt((i - Y0) * (i - Y0) + (j - X0) * (j - X0));
                    H[i, j] = Math.Exp((-distance * distance) / (2 * D0 * D0));
                }

            return FrequencyDomainUtility.applyConvolution(oldImg, H);
        }
        public static Bitmap applyButterWorthFilter(Bitmap oldImg, int D0, int n)
        {
            double[,] H = new double[oldImg.Height, oldImg.Width];

            int X0 = oldImg.Width / 2; // Origin X in the Frequency domain
            int Y0 = oldImg.Height / 2;// Origin Y in the Frequency domain

            for (int i = 0; i < H.GetLength(0); i++)
                for (int j = 0; j < H.GetLength(1); j++)
                {
                    double distance = Math.Sqrt((i - Y0) * (i - Y0) + (j - X0) * (j - X0));
                    H[i, j] = 1 / (1 + Math.Pow(distance / D0, 2 * n));
                }

            return FrequencyDomainUtility.applyConvolution(oldImg, H);
        }
        
    }
}
