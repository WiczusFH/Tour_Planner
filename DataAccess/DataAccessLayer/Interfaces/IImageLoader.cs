using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Threading;

namespace DataAccess
{
    public interface IImageLoader
    {
        public BitmapImage getImage(string name);
        public BitmapImage getImageHttp(string uri);
        public void saveImage(BitmapImage image, string filename);
        public Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage);
    }
}
