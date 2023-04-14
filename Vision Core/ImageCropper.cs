using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision_Core
{
    public static class ImageCropper
    {

        public static void CropImage(string file, int x, int y, int width, int height)
        {
            string imagePath = file;
            Bitmap croppedImage;

            // Here we capture the resource - image file.
            using (var originalImage = new Bitmap(imagePath))
            {
                Rectangle crop = new Rectangle(x, y, width, height);

                // Here we capture another resource.
                croppedImage = originalImage.Clone(crop, originalImage.PixelFormat);

            } // Here we release the original resource - bitmap in memory and file on disk.

            // At this point the file on disk already free - you can record to the same path.
            croppedImage.Save(imagePath, ImageFormat.Jpeg);

            // It is desirable release this resource too.
            croppedImage.Dispose();
        }

    }
}
