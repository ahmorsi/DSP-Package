// -----------------------------------------------------------------------
// <copyright file="ConvolutionBasedFilter.cs" company="Hewlett-Packard">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DSP_Image_Processing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ConvolutionBasedFilter
    {
        private int windowHeight, windowWidth;
        private List<float> windowMask;
        public ConvolutionBasedFilter()
        {
            windowHeight=windowWidth=3;
            windowMask = new List<float>(windowHeight * windowWidth);
        }
        public ConvolutionBasedFilter(int windowHeight, int windowWidth)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            windowMask = new List<float>(windowHeight * windowWidth);
        }
        public Bitmap OriginalSmooting(Bitmap oldImage)
        {
            int area=windowHeight * windowWidth;
            for (int i = 0; i < area; ++i)
                windowMask.Add(0.1f);
            Bitmap processedImage=Calculate_Convolution(oldImage);
            windowMask.Clear();
            return processedImage;
        }
        public Bitmap LaplacianEdgeDetection(Bitmap oldImage)
        {
            int area = windowHeight * windowWidth;
            for (int i = 0; i < area; ++i)
                windowMask.Add(-1.0f);
            windowMask[windowMask.Count / 2] = area - 1;
            Bitmap processedImage = Calculate_Convolution(oldImage);
            windowMask.Clear();
            return processedImage;
        }
        public Bitmap LaplacianSharpening(Bitmap oldImage)
        {
            int area = windowHeight * windowWidth;
            for (int i = 0; i < area; ++i)
                windowMask.Add(-1.0f);
            windowMask[windowMask.Count / 2] = area;
            Bitmap processedImage = Calculate_Convolution(oldImage);
            windowMask.Clear();
            return processedImage;
        }
        private List<int> Initialize_the_row(BitmapData oldData, int y)
        {
            List<int> arr = new List<int>();
            int pixelSize = 3;
            unsafe
            {
                for (int x = 0; x < this.windowWidth; x++)
                {
                    int sumR = 0, sumB = 0, sumG = 0;
                    for (int curY = y - (this.windowHeight / 2); curY < y + (this.windowHeight / 2); curY++)
                    {
                        byte* oldPixelRow = (byte*)oldData.Scan0 + (curY * oldData.Stride);
                        sumB += oldPixelRow[(x * pixelSize) + 0];
                        sumG += oldPixelRow[(x * pixelSize) + 1];
                        sumR += oldPixelRow[(x * pixelSize) + 2];
                    }
                    arr.Add(sumB);
                    arr.Add(sumG);
                    arr.Add(sumR);
                }
                return arr;
            }
        }
        private List<int> calcNextColumn(int x, int startY, int endY, BitmapData oldData)
        {
            List<int> arr = new List<int>();
            unsafe
            {
                int R = 0, G = 0, B = 0, pixelSize = 3;
                for (int i = startY; i <= endY; i++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (i * oldData.Stride);
                    B += oldPixelRow[(x * pixelSize) + 0];
                    G += oldPixelRow[(x * pixelSize) + 1];
                    R += oldPixelRow[(x * pixelSize) + 2];
                }
                arr.Add(B);
                arr.Add(G);
                arr.Add(R);
            }
            return arr;
        }
        public Bitmap smoothingFilterOptimized(Bitmap oldImage)
        {
            Bitmap newImage = new Bitmap(oldImage);
            int startX = (windowWidth / 2), startY = (windowHeight / 2);

            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                int B, G, R;
                //for (int y = 0; y < startY; y++)
                //{
                //    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                //    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                //    for (int x = 0; x < startX; x++)
                //    {
                //        newPixelRow[(x * pixelSize) + 0] = newPixelRow[(x * pixelSize) + 0];
                //        newPixelRow[(x * pixelSize) + 1] = newPixelRow[(x * pixelSize) + 1];
                //        newPixelRow[(x * pixelSize) + 2] = newPixelRow[(x * pixelSize) + 2];
                //    }
                //}
                //for (int y = oldImage.Height-startY; y < startY; y++)
                //{
                //    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                //    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                //    for (int x = 0; x < startX; x++)
                //    {
                //        newPixelRow[(x * pixelSize) + 0] = newPixelRow[(x * pixelSize) + 0];
                //        newPixelRow[(x * pixelSize) + 1] = newPixelRow[(x * pixelSize) + 1];
                //        newPixelRow[(x * pixelSize) + 2] = newPixelRow[(x * pixelSize) + 2];
                //    }
                //}
                
                for (int y = startY; y < oldImage.Height - startY; y++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    List<int> windowSum = this.Initialize_the_row(oldData, y);

                    int newR=0, newG=0, newB=0;
                    for (int x = startX; x < oldImage.Width - startX; x++)
                    {
                        B = 0;
                        G = 0;
                        R = 0;
                        for (int i = 0; i < windowWidth; i++)
                        {
                            B += windowSum[(i * pixelSize) + 0];
                            G += windowSum[(i * pixelSize) + 1];
                            R += windowSum[(i * pixelSize) + 2];
                        }
                        newPixelRow[(x * pixelSize) + 0] = (byte)(B / (windowHeight * windowWidth));
                        newPixelRow[(x * pixelSize) + 1] = (byte)(G / (windowHeight * windowWidth));
                        newPixelRow[(x * pixelSize) + 2] = (byte)(R / (windowHeight * windowWidth));
                        List<int> newColumn = this.calcNextColumn(x+windowWidth/2 + 1, y - (windowHeight / 2), y + (windowHeight / 2), oldData);
                        windowSum[(newB% windowWidth)*pixelSize + 0] = newColumn[0];
                        windowSum[(newG% windowWidth)*pixelSize + 1] = newColumn[1];
                        windowSum[(newR% windowWidth)*pixelSize + 2] = newColumn[2];
                        ++newB;
                        ++newG;
                        ++newR;
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
        private Bitmap Calculate_Convolution(Bitmap oldImage)
        {
            Bitmap newImage = new Bitmap(oldImage);
            int startX = (windowWidth / 2), startY = (windowHeight/ 2);

            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                float B, G, R;
                for (int y = startY; y < oldImage.Height - startY; y++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = startX; x < oldImage.Width - startX; x++)
                    {
                        B = G = R = 0;
                        int MaskIndex = 0;
                        for (int currentwindowY = y - startY; currentwindowY <= y + startY; currentwindowY++)
                        {
                            byte* temppixel = (byte*)oldData.Scan0 + (currentwindowY * oldData.Stride);
                            for (int currentwindowX = x - startX; currentwindowX <= x + startX; currentwindowX++)
                            {
                                B += (temppixel[(currentwindowX * pixelSize) + 0]* windowMask[MaskIndex]);
                                G += (temppixel[(currentwindowX * pixelSize) + 1]* windowMask[MaskIndex]);
                                R += (temppixel[(currentwindowX * pixelSize) + 2]* windowMask[MaskIndex]);
                                ++MaskIndex;
                            }
                        }
                        newPixelRow[(x * pixelSize) + 0] = (byte)(Math.Abs(B));
                        newPixelRow[(x * pixelSize) + 1] = (byte)(Math.Abs(G));
                        newPixelRow[(x * pixelSize) + 2] = (byte)(Math.Abs(R));
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
    }
}
