using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MercyBot.Protocol.Data.Maps
{
    public static class MapsManager
    {

        // Fields
        private static ConcurrentDictionary<int, Map> _mapsCache;
        private static SemaphoreSlim _semaphoreSlim;
        private static HttpClient _httpClient;


        // Constructor
        public static void Initialize(string assetsVersion)
        {
            _mapsCache = new ConcurrentDictionary<int, Map>();
            _semaphoreSlim = new SemaphoreSlim(1, 1);
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri($"https://ankama.akamaized.net/games/dofus-tablette/assets/{assetsVersion}/maps/");
        }


        public static async Task<Map> GetMapAsync(int id)
        {
            await _semaphoreSlim.WaitAsync().ConfigureAwait(false);

            if (_mapsCache.TryGetValue(id, out Map map))
            {
                _semaphoreSlim.Release();
                return map;
            }

            Map rMap = null;

            try
            {
                var response = await _httpClient.GetAsync($"{id}.json").ConfigureAwait(false);
                var json = await response.Content.ReadAsJsonAsync().ConfigureAwait(false);
                rMap = json.ToObject<Map>();
                _mapsCache.TryAdd(id, rMap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            _semaphoreSlim.Release();
            return rMap;
        }

    }
}
