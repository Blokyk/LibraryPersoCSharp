namespace Library.Image
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System;
    using System.IO;

    public static class ExtendImage
    {
        /// <summary>
        /// Return a 3D int array from the image based on each color channel. Use as [x, y, c] : x = x position ; y = y position ; c = color 0 = red, 1 = green, 2 = blue
        /// </summary>
        public static float[,,] ToArray(this Bitmap bmp)
        {
            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] r = new byte[bytes / 3];
            byte[] g = new byte[bytes / 3];
            byte[] b = new byte[bytes / 3];
            float[,,] output = new float[bmp.Height, bmp.Width, 3];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int count = 0;
            int stride = bmpData.Stride;

            for (int column = 0; column < bmpData.Height; column++)
            {
                for (int row = 0; row < bmpData.Width; row++)
                {
                    b[count] = (rgbValues[(column * stride) + (row * 3)]);
                    g[count] = (rgbValues[(column * stride) + (row * 3) + 1]);
                    r[count++] = (rgbValues[(column * stride) + (row * 3) + 2]);
                }
            }

            count = 0;

            for (int x = 0; x < bmpData.Height; x++)
            {
                for (int y = 0; y < bmpData.Width; y++)
                {
                    output[x, y, 0] = r[count];
                    output[x, y, 1] = g[count];
                    output[x, y, 2] = b[count++];
                }
            }

            bmp.UnlockBits(bmpData);

            return output;
        }


        /// <summary>
        /// Same as ToIntArray() but return a factor array instead of a color value array
        /// </summary>
        public static float[,,] ToIntArrayAsFactor(this Bitmap bmp)
        {
            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] r = new byte[bytes / 3];
            byte[] g = new byte[bytes / 3];
            byte[] b = new byte[bytes / 3];
            float[,,] output = new float[bmp.Height, bmp.Width, 3];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int count = 0;
            int stride = bmpData.Stride;

            for (int column = 0; column < bmpData.Height; column++)
            {
                for (int row = 0; row < bmpData.Width; row++)
                {
                    b[count] = (rgbValues[(column * stride) + (row * 3)]);
                    g[count] = (rgbValues[(column * stride) + (row * 3) + 1]);
                    r[count++] = (rgbValues[(column * stride) + (row * 3) + 2]);
                }
            }

            count = 0;

            for (int x = 0; x < bmpData.Height; x++)
            {
                for (int y = 0; y < bmpData.Width; y++)
                {
                    // Because 255 is the maximum value for a color
                    output[x, y, 0] = r[count] / 255;
                    output[x, y, 1] = g[count] / 255;
                    output[x, y, 2] = b[count++] / 255;
                }
            }

            bmp.UnlockBits(bmpData);

            return output;
        }
    } 
}