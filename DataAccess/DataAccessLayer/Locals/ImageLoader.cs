using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Threading;
using log4net;
namespace DataAccess
{
    public class ImageLoader : IImageLoader
    {
        log4net.ILog Logging = LogManager.GetLogger(typeof(ImageLoader));

        public BitmapImage getImage(string name)
        {

            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder sb = new StringBuilder();
            sb.Append(execPath);
            sb.Append("/Images/");
            sb.Append(name);
            sb.Append(".png");
            Logging.Info("Loaded from" + sb.ToString());

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
            sb.Append("/Images/");
            sb.Append(filename);
            sb.Append(".png");
            if (File.Exists(sb.ToString()))
            {
                File.Delete(sb.ToString());
            }

            Bitmap bitmap = BitmapImage2Bitmap(image);
            bitmap.Save(sb.ToString());
            Logging.Info("Saved at" + sb.ToString());
        }
        public Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
      
                Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

    }
}
