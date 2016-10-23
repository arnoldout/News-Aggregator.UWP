using NewsAggregator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

            var response = client.PostAsync(App.apiURL+"addProfile", httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return await ParseRegResponse(await response.Content.ReadAsStringAsync(), "Invalid Login");
            }
            return "false";
        }
        public static async Task<string> ParseRegResponse(String result, String dialogMsg)
        {
            if (result.Equals("false"))
            {
                //username taken
                var dialog = new MessageDialog(dialogMsg);
                await dialog.ShowAsync();
                return "false";
           } 
            else
            {
                //account created
                return result.ToString();
            }
        }
        public static async void GetProfile(String id)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(String));

            String url = App.apiURL + "getProfile/" + id;
            WebRequest wrGETURL = WebRequest.Create(url);
            wrGETURL.Proxy = null;

            WebResponse response = await wrGETURL.GetResponseAsync();
            Stream dataStream = response.GetResponseStream();
            StreamReader objReader = new StreamReader(dataStream);
            dynamic profile = JsonConvert.DeserializeObject(objReader.ReadToEnd());
        }

        public static string GetPostHeader(Object p, DataContractJsonSerializer deseri)
        {
            MemoryStream stream = new MemoryStream();
            deseri.WriteObject(stream, p);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();  
        }
        internal static async void FailedRequest()
        {
            var dialog = new MessageDialog("The server could not be reached");
            await dialog.ShowAsync();
        }
        public static async Task<String> login(Profile p)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Profile));
            string data = GetPostHeader(p, ser);
            var client = new HttpClient();
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PostAsync(App.apiURL + "login", httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "false";
        }
    }
}
