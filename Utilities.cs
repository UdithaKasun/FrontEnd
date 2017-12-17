using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SPDC
{
    public class Utilities
    {

        public static void PostCall_RestAPI(string baseUrl,string resourceUrl,Object postBody)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.PostAsync(resourceUrl, new System.Net.Http.StringContent(
   new JavaScriptSerializer().Serialize(postBody), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else
                    throw new Exception("Operation Failed");
            }
        }
    }
}
