using Newtonsoft.Json;
using RocketLaunchTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RocketLaunchTracker.Services
{
    public class RocketLaunchService
    {
        private const string apiBaseUrl = "https://launchlibrary.net/1.4/";

        public async Task<LaunchInfo> GetNextLaunchesAsync(int count)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);

                var resultString = await httpClient.GetStringAsync($"launch/next/{count}");
                var launchInfo = JsonConvert.DeserializeObject<LaunchInfo>(resultString);

                return launchInfo;
            }
        }

        public async Task<Launch> GetLaunchAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);

                var resultString = await httpClient.GetStringAsync($"launch/{id}");
                var launch = JsonConvert.DeserializeObject<LaunchInfo>(resultString);

                return launch.launches.First();
            }
        }
    }
}
