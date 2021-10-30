using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
namespace DataAccess
{
    public interface IMapquest
    {

        public Task<float[]> namesToCoord(string[] names);
        public Task<float> getDistance(string StartLocation, string Endlocation);
        public Task<BitmapImage> GetMapRouteCoord(float x0, float y0, float x1, float y1);
        public Task<string> GetRequest_s(string RequestURL);
        public Task<byte[]> GetRequest_b(string RequestURL);
        public BitmapImage LoadImage(byte[] imageData);
    }
}
