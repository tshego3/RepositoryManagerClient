using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace repositorymanagerclient.Shared
{
    public static class WebRequests
    {
        public static async Task<T> GetAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, ILogger logger, IConfiguration configuration)
        {
            try
            {
                HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(GetUrl(webRequestEndpoint, logger, configuration));
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json)!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        public static async Task<T> PostAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, T model, ILogger logger, IConfiguration configuration)
        {
            try
            {
                 HttpClient client = new();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), new MediaTypeHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(GetUrl(webRequestEndpoint, logger, configuration), content);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json)!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        public static async Task<T> PutAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, T model, ILogger logger, IConfiguration configuration)
        {
            try
            {
                 HttpClient client = new();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), new MediaTypeHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsync(GetUrl(webRequestEndpoint, logger, configuration), content);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json)!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        public static async Task<T> DeleteAsync<T>(Enums.WebRequestEndpoint webRequestEndpoint, ILogger logger, IConfiguration configuration)
        {
            try
            {
                 HttpClient client = new();
                HttpResponseMessage response = await client.DeleteAsync(GetUrl(webRequestEndpoint, logger, configuration));
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json)!;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(string.Empty)!;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return JsonConvert.DeserializeObject<T>(string.Empty)!;
            }
        }

        private static string GetUrl(Enums.WebRequestEndpoint webRequestEndpoint, ILogger logger, IConfiguration configuration)
        {
            try
            {
                return webRequestEndpoint switch
                {
                    Enums.WebRequestEndpoint.RepositoryManagerNexuse => configuration.GetSection("RepositoryManagerNexuse").Value!,
                    Enums.WebRequestEndpoint.RepositoryManagerNote => configuration.GetSection("RepositoryManagerNote").Value!,
                    Enums.WebRequestEndpoint.RepositoryManagerVibration => configuration.GetSection("RepositoryManagerVibration").Value!,
                    _ => throw new ArgumentOutOfRangeException(nameof(webRequestEndpoint), webRequestEndpoint, null),
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return string.Empty;
            }
        }
    }
}
