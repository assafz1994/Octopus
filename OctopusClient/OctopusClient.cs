using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Octopus.Common;

namespace Octopus.Client
{
    public class OctopusClient : IDisposable
    {
        private readonly HttpClient _client;

        public OctopusClient(string endpoint)
        {
            _client = new HttpClient();
            Endpoint = new Uri(endpoint);
        }

        public Uri Endpoint { get; }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task ExecuteNoneQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty", nameof(query));

            var octopusResponse = await SendQuery(query);

            if (octopusResponse.IsSuccess == false)
            {
                throw new Exception(octopusResponse.ErrorMessage);
            }
        }

        public async Task<dynamic[]> ExecuteQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty", nameof(query));

            var octopusResponse = await SendQuery(query);

            if (octopusResponse.IsSuccess == false)
            {
                throw new Exception(octopusResponse.ErrorMessage);
            }

            return octopusResponse.Content.Select(fields =>
            {
                var eo = new ExpandoObject();
                var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

                foreach (var kvp in fields)
                {
                    eoColl.Add(kvp);
                }

                dynamic eoDynamic = eo;
                return eoDynamic;
            }).ToArray();
        }

        private async Task<OctopusResponse> SendQuery(string query)
        {
            var httpResponse = await _client.GetAsync(new Uri(Endpoint, "ExecuteQuery?query=" + query));
            if (httpResponse.Content == null) throw new Exception("Empty response from server");

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var octopusResponse = JsonConvert.DeserializeObject<OctopusResponse>(responseContent);
            if (octopusResponse == null)
            {
                throw new Exception("Null response from the server");
            }

            return octopusResponse;
        }
    }
}