using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NewsAggregator.Data
{
    class ProfileService
    {
        public static async Task<string> Write(Profile p)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Profile));
            string data = GetPostHeader(p, ser);
            var client = new HttpClient();
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PostAsync("http://localhost:4567/addProfile", httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "false";
        }
        public static async Task<string> ParseResponse(String result)
        {
            if (result.Equals("false"))
            {
                //username taken
                var dialog = new MessageDialog("Username Taken");
                await dialog.ShowAsync();
                return "false";
            }
            else
            {
                //account created
                return result.ToString();
            }
        }
        /*public static async Task<Profile> getProfile(String id)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(String));
            string data = GetPostHeader(id, ser);
            var client = new HttpClient();
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PostAsync("http://localhost:4567/getProfile", httpContent).Result;

        }*/
        public static string GetPostHeader(Object p, DataContractJsonSerializer deseri)
        {
            MemoryStream stream = new MemoryStream();
            deseri.WriteObject(stream, p);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();  
        }
    }
}
