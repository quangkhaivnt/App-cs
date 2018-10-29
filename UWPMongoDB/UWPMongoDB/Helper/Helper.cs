using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPMongoDB.Helper
{
    public class Helper
    {
        //Get all user from MongoDB
        public static async Task<List<User>> getAllUser()
        {
            using(var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(Common.API_SELECT_DOCUMENTS_LINK);
                var responseBodyAsText = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200 - OK
                {


                    //Convert result to JSON
                    var users = JsonConvert.DeserializeObject<List<User>>(responseBodyAsText);
                    return users;
                }
            }
            return null;
        }

        public static async Task insertNewUser(string user)
        {
            // We will make a Post Request with content is JSON string 

            using(var client = new HttpClient())
            {
                var address = new Uri(Common.API_SELECT_DOCUMENTS_LINK);
                User addUser = new User();
                addUser.user = user;
                string postPody = JsonConvert.SerializeObject(addUser);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var responseBodyAsText = await client.PostAsync(address, new StringContent(postPody, Encoding.UTF8, "application/json"));

            }
        }

        public static async Task insertMultiNewUser(List<User> users)
        {
            // We will make a Post Request with content is JSON string 

            using (var client = new HttpClient())
            {
                var address = new Uri(Common.API_SELECT_DOCUMENTS_LINK);

                
                string postPody = JsonConvert.SerializeObject(users);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var responseBodyAsText = await client.PostAsync(address, new StringContent(postPody, Encoding.UTF8, "application/json"));

            }
        }

        public static async Task updateUser(User oldValue,string newValue)
        {
            // We will make a Put Request to update User
           //Fixed
           using(var client = new HttpClient())
            {
                StringBuilder str = new StringBuilder(Common.API_DOCUMENTS_LINK);
                str.Append("/" + oldValue._id.oid + "?apiKey=" + Common.API_KEY);
                // We need string : {"user":"admin1"} for example value changed
                //So we need use {{ for instance of { for block exception System.Format
                string json = String.Format("{{\"user\":\"{0}\"}}", newValue);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var responseBodyAsText = await client.PutAsync(str.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        public static async Task deleteUser(User user)
        {
            using(var client = new HttpClient())
            {

                StringBuilder str = new StringBuilder(Common.API_DOCUMENTS_LINK);
                str.Append("/" + user._id.oid + "?apiKey=" + Common.API_KEY);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseBodyAsText = await client.DeleteAsync(str.ToString());

            }
        }
    }
}
