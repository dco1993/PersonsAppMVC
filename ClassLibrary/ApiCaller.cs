using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClassLibrary {
    public static class ApiCaller {

        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient() { 
        
            ApiClient = new HttpClient();

            ApiClient.DefaultRequestHeaders.Accept.Clear();

            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        }
    }
}
