using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace repositorymanagerclient.Shared
{
    public static class WebRequests
    {
        public static async Task<T> GetAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(GetUrl(webRequestEndpoint));
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch 
            {
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        public static async Task<T> PostAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, T model)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), new MediaTypeHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(GetUrl(webRequestEndpoint), content);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch
            {
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        public static async Task<T> PutAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, T model)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), new MediaTypeHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsync(GetUrl(webRequestEndpoint), content);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch
            {
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        public static async Task<T> DeleteAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, T model)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync(GetUrl(webRequestEndpoint));
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch
            {
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        private static string GetUrl(Enums.WebRequestEndpoint webRequestEndpoint)
        {
            try
            {
                switch (webRequestEndpoint)
                {
                    case Enums.WebRequestEndpoint.RepositoryManagerNexuse:
                        return "";
                    case Enums.WebRequestEndpoint.RepositoryManagerNote:
                        return "";
                    case Enums.WebRequestEndpoint.RepositoryManagerVibration:
                        return "";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(webRequestEndpoint), webRequestEndpoint, null);
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
