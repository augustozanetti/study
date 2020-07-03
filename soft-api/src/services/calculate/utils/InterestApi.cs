using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace calculate
{
    public class InterestAPI
    {
        private string _baseUrl { get; }
        public InterestAPI(IConfiguration configuration)
        {
            var section = configuration.GetSection("INTEREST_API_URL");

            this._baseUrl = section.Value;
        }
        private async Task<string> ExecuteRequest()
        {
            string result;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(this._baseUrl))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }

            return result;
        }

        public async Task<double> GetInterestRate() => Double.Parse(await this.ExecuteRequest());

    }
}
