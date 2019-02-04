using DAL.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RestClient
    {
        private HttpClient client;

        public RestClient()
        {
            this.client = new HttpClient();
        }

        public void Init(string baseUri)
        {
            this.client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
        }


        public async Task<T> Get<T>(string path, Func<string, T> deserializeFn = null)
            where T : class
        {
            HttpResponseMessage response = await client.GetAsync(path);
            switch (response.StatusCode)
            {

                case System.Net.HttpStatusCode.NotFound:
                    throw new NotFoundException();
                case System.Net.HttpStatusCode.OK:

                    if (deserializeFn == null)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();

                    var myCustomResponse = await Task.Factory.StartNew(() => deserializeFn(responseContent));

                    return myCustomResponse;
                default:
                    throw new ApiErrorException();
            }
        }

    }
}
