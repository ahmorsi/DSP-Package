// -----------------------------------------------------------------------
// <copyright file="Morphology.cs" company="Hewlett-Packard">
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
    public class Morphology
    {
        private int windowHeight, windowWidth;
        private List<byte> structureElement;
        public Morphology()
        {
            windowHeight = windowWidth = 3;
            structureElement = new List<byte>();
            for (int i = 0; i < windowWidth * windowHeight; ++i)
                structureElement.Add(255);
            structureElement[0] = structureElement[2] = structureElement[8] = structureElement[6] = 0;
        }
        public Morphology(int windowHeight, int windowWidth)
        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
        }
        public Bitmap calculateErosion(Bitmap oldImage)
        {
            Bitmap newImage = new Bitmap(oldImage);
            int startX = (windowWidth / 2), startY = (windowHeight / 2);

            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                
                for (int y = startY; y < oldImage.Height - startY; y++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = startX; x < oldImage.Width - startX; x++)
                    {
                        bool fit=true;
                        int structureIndex = 0;
                        for (int currentwindowY = y - startY; currentwindowY <= y + startY; currentwindowY++)
                        {
                            byte* temppixel = (byte*)oldData.Scan0 + (currentwindowY * oldData.Stride);
                            for (int currentwindowX = x - startX; currentwindowX <= x + startX; currentwindowX++)
                            {
                                if (temppixel[(currentwindowX * pixelSize)] != structureElement[structureIndex] && structureElement[structureIndex] == 255) 
                                {
                                    fit = false;
                                    break;
                                }
                                ++structureIndex;
                            }
                            if (!fit)
                                break;
                        }
                        if(fit)
                            newPixelRow[(x * pixelSize) + 0] = newPixelRow[(x * pixelSize) + 1] = newPixelRow[(x * pixelSize) + 2] = 255;
                        else
                            newPixelRow[(x * pixelSize) + 0] = newPixelRow[(x * pixelSize) + 1] = newPixelRow[(x * pixelSize) + 2] = 0;
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
        public Bitmap calculateDilation(Bitmap oldImage)
        {
            Bitmap newImage = new Bitmap(oldImage);
            int startX = (windowWidth / 2), startY = (windowHeight / 2);

            unsafe
            {
                BitmapData oldData = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;

                for (int y = startY; y < oldImage.Height - startY; y++)
                {
                    byte* oldPixelRow = (byte*)oldData.Scan0 + (y * oldData.Stride);
                    byte* newPixelRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = startX; x < oldImage.Width - startX; x++)
                    {
                        bool hit = false;
                        int structureIndex = 0;
                        for (int currentwindowY = y - startY; currentwindowY <= y + startY; currentwindowY++)
                        {
                            byte* temppixel = (byte*)oldData.Scan0 + (currentwindowY * oldData.Stride);
                            for (int currentwindowX = x - startX; currentwindowX <= x + startX; currentwindowX++)
                            {
                                if (temppixel[(currentwindowX * pixelSize)] == (byte)structureElement[structureIndex] && structureElement[structureIndex] == 255)
                                {
                                    hit = true;
                                    break;
                                }
                                ++structureIndex;
                            }
                            if (hit)
                                break;
                        }
                        newPixelRow[(x * pixelSize) + 0] = newPixelRow[(x * pixelSize) + 1] = newPixelRow[(x * pixelSize) + 2] = (byte)(hit ? 1 : 0);
                    }
                }
                oldImage.UnlockBits(oldData);
                newImage.UnlockBits(newData);
            }
            return newImage;
        }
    }
}
