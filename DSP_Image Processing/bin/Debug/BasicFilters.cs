using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace DSP_Image_Processing
{
    class BasicFilters
    {
        public static Bitmap ToGrayScale(Bitmap oldImage)
        {
            Bitmap newImage;
            newImage = new Bitmap(oldImage.Width, oldImage.Height);
            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < oldImage.Height; ++y)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < oldImage.Width; ++x)
                    {
                        int B = oldPixelRow[(x * pixelSize) + 0];
                        int G = oldPixelRow[(x * pixelSize) + 1];
                        int R = oldPixelRow[(x * pixelSize) + 2];

                        int grayscale = (B + G + R) / 3;

                        newPixelRow[(x * pixelSize) + 0] = newPixelRow[(x * pixelSize) + 1] = newPixelRow[(x * pixelSize) + 2] = (byte)grayscale;
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
        public static Bitmap invertImage(Bitmap oldImage)
        {
            Bitmap newImage;
            newImage = new Bitmap(oldImage.Width, oldImage.Height);
            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < oldImage.Height; ++y)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < oldImage.Width; ++x)
                    {
                        int B = oldPixelRow[(x * pixelSize) + 0];
                        int G = oldPixelRow[(x * pixelSize) + 1];
                        int R = oldPixelRow[(x * pixelSize) + 2];

                        newPixelRow[(x * pixelSize) + 0] = (byte)~B;    //(byte)(255 - B);
                        newPixelRow[(x * pixelSize) + 1] = (byte)~G;    //(byte)(255-G);
                        newPixelRow[(x * pixelSize) + 2] = (byte)~R;    //(byte)(255 - R);
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
        public static Bitmap subtractImage(Bitmap firstImage, Bitmap secondImage)
        {
            Bitmap newImage;
            newImage = new Bitmap(firstImage.Width, firstImage.Height);
            unsafe
            {
                BitmapData firstoldData = firstImage.LockBits(new Rectangle(0, 0, firstImage.Width, firstImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData secondoldData = secondImage.LockBits(new Rectangle(0, 0, secondImage.Width, secondImage.Height),
                   ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, secondImage.Width, secondImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < firstImage.Height; ++y)
                {
                    byte* oldfirstPixelRow = (byte*)firstoldData.Scan0 + (y * firstoldData.Stride);
                    byte* oldsecondPixelRow = (byte*)secondoldData.Scan0 + (y * secondoldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < firstImage.Width; ++x)
                    {
                        newPixelRow[(x * pixelSize) + 0] = (byte)(oldfirstPixelRow[(x * pixelSize) + 0] - oldsecondPixelRow[(x * pixelSize) + 0]);
                        newPixelRow[(x * pixelSize) + 1] = (byte)(oldfirstPixelRow[(x * pixelSize) + 1] - oldsecondPixelRow[(x * pixelSize) + 1]);
                        newPixelRow[(x * pixelSize) + 2]= (byte)(oldfirstPixelRow[(x * pixelSize) + 2] - oldsecondPixelRow[(x * pixelSize) + 2]);
                    }
                }
                firstImage.UnlockBits(firstoldData);
                secondImage.UnlockBits(secondoldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
    }
}
