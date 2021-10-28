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
    public class Mapquest
    {

        public async Task<float[]> namesToCoord(string[] names) {
            float[] result = new float[names.Length*2];
            StringBuilder sb = new StringBuilder();
            sb.Append($"https://www.mapquestapi.com/geocoding/v1/batch?key={Configuration.MapQuestKey}");
            foreach(string name in names)
            {
                sb.Append($"&location={name}");
            }
            string URL = sb.ToString();
            Console.WriteLine(URL);
            string res=await GetRequest_s(URL);
            JsonDocument jsonDocument = JsonDocument.Parse(res);
            try
            {
                for (int i = 0; i < names.Length; i++)
                {
                    result[i*2 + 0] = float.Parse(jsonDocument.RootElement.GetProperty("results")[i].GetProperty("locations")[0].GetProperty("latLng").GetProperty("lat").ToString());
                    result[i*2 + 1] = float.Parse(jsonDocument.RootElement.GetProperty("results")[i].GetProperty("locations")[0].GetProperty("latLng").GetProperty("lng").ToString());

                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        public async Task<float> getDistance(string StartLocation,string Endlocation) {
            string URL =$"http://www.mapquestapi.com/directions/v2/route?key={Configuration.MapQuestKey}&from={StartLocation}&to={Endlocation}";
            string res = await GetRequest_s(URL);
            float result=-1;
            JsonDocument jsonDocument = JsonDocument.Parse(res);
            try {
                result= float.Parse(jsonDocument.RootElement.GetProperty("route").GetProperty("distance").ToString());
            } catch
            {
                
            }

            return result;
        }
        public async Task<BitmapImage> GetMapRouteCoord(float x0, float y0, float x1, float y1) //-R make async
        {
            string URL = $"https://www.mapquestapi.com/staticmap/v5/map?key={Configuration.MapQuestKey}&start={x0},{y0}&end={x1},{y1}";

            byte[] img = await GetRequest_b(URL);
            return LoadImage(img);
        }


        //-R Make Request api
        async static Task<string> GetRequest_s(string RequestURL)
        {
            string s_content;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(RequestURL))
                {
                    using (HttpContent content = response.Content)
                    {
                        s_content = await content.ReadAsStringAsync();
                    }
                }
            }
            return s_content;
        }

        async static Task<byte[]> GetRequest_b(string RequestURL)
        {
            byte[] s_content;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(RequestURL)) {
                    using (HttpContent content = response.Content){
                        s_content = await content.ReadAsByteArrayAsync();
                    }
                }
            }
            return s_content;
        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
