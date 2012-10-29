using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
namespace DSP_Image_Processing
{
    class Thresholding
    {

        private int windowHeight, windowWidth;
        public Thresholding()
        {
            windowHeight = windowWidth = 3;
        }
        public Thresholding(int windowHeight, int windowWidth)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }
        private Int64 calculateAdaptiveThreshold(int startX, int startY, BitmapData oldData)
        {
            Int64 thresholdB = 0;

            int pixelSize = 3;
            unsafe
            {
                for (int y = startY - (windowHeight / 2); y <= startY + (windowHeight / 2); y++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    for (int x = startX - (windowWidth / 2); x <= startX + (windowWidth / 2); x++)
                    {
                        thresholdB += (int)(oldPixelRow[(x * pixelSize) + 0]);
                    }
                }
            }
            return (thresholdB / (windowWidth * windowHeight));
        }
        private Int64 calculateAverageThreshold(BitmapData oldData)
        {
            Int64 thresholdB = 0;
            int pixelSize = 3;
            unsafe
            {
                for (int y = 0; y < oldData.Height; y++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    for (int x = 0; x < oldData.Width; x++)
                    {
                        thresholdB += (int)(oldPixelRow[(x * pixelSize) + 0]);
                    }
                }
            }
            return (thresholdB / (oldData.Height * oldData.Width));
        }
        public Bitmap applyAdaptiveThresholding(Bitmap oldImage)
        {
            Bitmap newImage = new Bitmap(oldImage.Width, oldImage.Height);
            int startX = (windowWidth / 2), startY = (windowHeight / 2);
            int pixelSize = 3;
            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Int64 ThresholdValue = 0;
                for (int y = startY; y < oldImage.Height - startY; y += windowHeight)
                {
                    for (int x = startX; x < oldImage.Width - startX; x += windowWidth)
                    {
                        ThresholdValue = calculateAdaptiveThreshold(x, y, oldData);
                        for (int fillY = y - (windowHeight / 2); fillY <= y + (windowHeight / 2); fillY++)
                        {
                            byte* oldPixelRow = (byte*)oldData.Scan0 + (fillY * oldData.Stride);
                            byte* newPixelRow = (byte*)newData.Scan0 + (fillY * newData.Stride);
                           

                            for (int fillX = x - (windowWidth / 2); fillX <= x + (windowWidth / 2); fillX++)
                            {
                                if (oldPixelRow[(fillX * pixelSize) + 0] < ThresholdValue)
                                {
                                    newPixelRow[(fillX * pixelSize) + 0] = 0;
                                    newPixelRow[(fillX * pixelSize) + 1] = 0;
                                    newPixelRow[(fillX * pixelSize) + 2] = 0;
                                }
                                else
                                {
                                    newPixelRow[(fillX * pixelSize) + 0] = 255;
                                    newPixelRow[(fillX * pixelSize) + 1] = 255;
                                    newPixelRow[(fillX * pixelSize) + 2] = 255;
                                }
                            }
                        }
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
        public Bitmap applyAverageThresholding(Bitmap oldImage)
        {
            Bitmap newImage = new Bitmap(oldImage.Width, oldImage.Height);
            int startX = (windowWidth / 2), startY = (windowHeight / 2);
            int pixelSize = 3;
            Int64 ThresholdValue = 0;
            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                ThresholdValue = calculateAverageThreshold(oldData);
                for (int fillY = 0; fillY <oldData.Height; fillY++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (fillY * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (fillY * newData.Stride);

                    for (int fillX = 0; fillX < oldData.Width; fillX++)
                    {
                        if (oldPixelRow[(fillX * pixelSize) + 0] < ThresholdValue)
                        {
                            newPixelRow[(fillX * pixelSize) + 0] = 0;
                            newPixelRow[(fillX * pixelSize) + 1] = 0;
                            newPixelRow[(fillX * pixelSize) + 2] = 0;
                        }
                        else
                        {
                            newPixelRow[(fillX * pixelSize) + 0] = 255;
                            newPixelRow[(fillX * pixelSize) + 1] = 255;
                            newPixelRow[(fillX * pixelSize) + 2] = 255;
                        }
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
        public Bitmap applyStaticThresholding(Bitmap oldImage, Int64 ThresholdValue)
        {
            Bitmap newImage = new Bitmap(oldImage.Width, oldImage.Height);
            int startX = (windowWidth / 2), startY = (windowHeight / 2);
            int pixelSize = 3;
            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                for (int fillY = 0; fillY < oldData.Height; fillY++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (fillY * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (fillY * newData.Stride);

                    for (int fillX = 0; fillX < oldData.Width; fillX++)
                    {
                        if (oldPixelRow[(fillX * pixelSize) + 0] < ThresholdValue)
                        {
                            newPixelRow[(fillX * pixelSize) + 0] = 0;
                            newPixelRow[(fillX * pixelSize) + 1] = 0;
                            newPixelRow[(fillX * pixelSize) + 2] = 0;
                        }
                        else
                        {
                            newPixelRow[(fillX * pixelSize) + 0] = 255;
                            newPixelRow[(fillX * pixelSize) + 1] = 255;
                            newPixelRow[(fillX * pixelSize) + 2] = 255;
                        }
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
    }
}
