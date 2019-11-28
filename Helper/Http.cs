using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTM_Frontend.Helper
{
    class Http
    {
        public List<GetTemplateTD> GetList(string endPoint)
        {
            try
            {
                //http://34.244.190.178:8080/traffic
                string url = "http://localhost:1790/traffic/" + endPoint;
                HttpClient client = new HttpClient();
                string response = "";
                Task task = Task.Run(async () =>
                {
                    response = await client.GetStringAsync(url);
                });
                task.Wait();

                var data = JsonConvert.DeserializeObject<List<GetTemplateTD>>(response);
                return data;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<GetTemplateTD>();
            }
        }

    }
}

