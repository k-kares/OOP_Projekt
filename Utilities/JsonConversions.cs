using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.QuickType;

namespace Utilities
{
    public static class  JsonConversions
    {
        public static T[]? DeserializeResponseList<T>(RestResponse<T> restResponse)
        {
            return JsonConvert.DeserializeObject<T[]>(restResponse.Content);

        }

        public static List<T>? DeserializeResponse<T>(RestResponse<T> restResponse)
        {
            return JsonConvert.DeserializeObject<List<T>>(restResponse.Content);

        }

        public static Task<RestResponse<GroupResults>> GetDataGroupResults(string url)
        {
            RestClient restClient = new RestClient($"{url}");
            return restClient.ExecuteAsync<GroupResults>(new RestRequest());
        }

         public static Task<RestResponse<Countries>> GetDataCountryResults(string url)
        {
            RestClient restClient = new RestClient($"{url}");
            return restClient.ExecuteAsync<Countries>(new RestRequest());
        }


        public static Task<RestResponse<Repke>> GetDataRepke(string url)
        {
            RestClient restClient = new RestClient($"{url}");
            return restClient.ExecuteAsync<Repke>(new RestRequest());
        }

        public static Task<RestResponse<GameStats>> GetDataGameStats(string url)
        {
            RestClient restClient = new RestClient($"{url}");
            return restClient.ExecuteAsync<GameStats>(new RestRequest());
        }

        public static Task<RestResponse<TeamStatistics>> GetDataTeamStats(string url)
        {
            RestClient restClient = new RestClient($"{url}");
            return restClient.ExecuteAsync<TeamStatistics>(new RestRequest());
        }
        public static Task<RestResponse<Player>> GetDataPlayers(string url)
        {
            RestClient restClient = new RestClient($"{url}");
            return restClient.ExecuteAsync<Player>(new RestRequest());
        }


    }
}
