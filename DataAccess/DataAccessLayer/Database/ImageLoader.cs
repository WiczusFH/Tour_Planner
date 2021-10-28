using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace DataAccess
{
    public class ImageLoader 
    {

        public BitmapImage getImage(string uri)
        {
        
            Uri path = new Uri(uri, UriKind.Relative);
            BitmapImage bitmap = new BitmapImage(path);
            return bitmap;
        }
        public BitmapImage getImageHttp(string uri)
        {

            Uri path = new Uri(uri);
            BitmapImage bitmap = new BitmapImage(path);
            return bitmap;
        }

    }
}
