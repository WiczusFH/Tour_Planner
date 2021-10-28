using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Threading;
namespace DataAccess
{
    public class ImageLoader 
    {

        public BitmapImage getImage(string uri)
        {

            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder sb = new StringBuilder();
            sb.Append(execPath);
            sb.Append(uri);
            Uri path = new Uri(sb.ToString());
            BitmapImage bitmap = new BitmapImage(path);
            return bitmap;
        }
        public BitmapImage getImageHttp(string uri)
        {

            Uri path = new Uri("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg");
            BitmapImage bitmap = new BitmapImage(path);
            return bitmap;
        }
        public void saveImage(BitmapImage image, string filename)
        {
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder sb = new StringBuilder();
            sb.Append(execPath);
            sb.Append(filename);
            Console.WriteLine(image.IsDownloading);
            Thread.Sleep(5000);
            Console.WriteLine(image.PixelWidth);

            Console.WriteLine(image.IsDownloading);
            //image.Freeze();
            Bitmap bitmap = BitmapImage2Bitmap(image);
            bitmap.Save(sb.ToString());

            
        }
        Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            //BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

    }
}
