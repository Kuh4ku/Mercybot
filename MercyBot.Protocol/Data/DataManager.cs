using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace MercyBot.Protocol.Data
{
    public static class DataManager
    {

        // Fields
        private static Dictionary<string, ConcurrentDictionary<int, IData>> _cache;
        private static HttpClient _httpClient;


        public static void Initialize(string assetsVersion, string lang)
        {
            _cache = new Dictionary<string, ConcurrentDictionary<int, IData>>();
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri($"https://proxyconnection.touch.dofus.com/data/map?lang={lang}&v={assetsVersion}");

            var dataType = typeof(IData);

            //  .Net Core 1.1
            var assTypes = Assembly.GetAssembly(dataType).GetTypes();
            foreach (var type in assTypes)
            {
                if (!dataType.IsAssignableFrom(type) || type == dataType)
                    continue;
                
                _cache.Add(type.Name, new ConcurrentDictionary<int, IData>());
            }
        }

        public static T Get<T>(int id) where T : IData => GetOrDownload<T>(new[] { id }).ElementAt(0);

        public static IEnumerable<T> GetEnumerable<T>(IEnumerable<int> ids) where T : IData => GetOrDownload<T>(ids);

        public static List<T> GetList<T>(IEnumerable<int> ids) where T : IData => GetOrDownload<T>(ids).ToList();

        private static IEnumerable<T> GetOrDownload<T>(IEnumerable<int> ids) where T : IData
        {
            Stopwatch sw = Stopwatch.StartNew();
            string className = typeof(T).Name;
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Data", className);
            List<T> data = new List<T>(ids.Count());

            List<int> idsToDownload = new List<int>();
            foreach (int id in ids)
            {
                var cachedData = _cache[className].ContainsKey(id) ? _cache[className][id] : null;

                // If its already in cache
                if (cachedData != null)
                {
                    data.Add((T)cachedData);
                }
                else
                {
                    // If it exists as a file
                    string filePath = Path.Combine(dir, $"{id}.mb");
                    if (File.Exists(filePath))
                    {
                        var dataEntry = (T)JsonConvert.DeserializeObject(File.ReadAllText(filePath), typeof(T));
                        // Cache it then add it to the list
                        _cache[className].TryAdd(dataEntry.Id, dataEntry);
                        data.Add(dataEntry);
                    }
                    // If not then we add it to the download list
                    else
                    {
                        idsToDownload.Add(id);
                    }
                }
            }

            if (idsToDownload.Count > 0)
            {
                try
                {
                    // This will download, cache and save all of the needed entries
                    data.AddRange(Download<T>(idsToDownload));
                }
                catch
                {
                    // ignored
                }
            }

            Console.WriteLine($"Got {data.Count} entries in {sw.Elapsed.Milliseconds}ms.");
            return data;
        }

        private static IEnumerable<T> Download<T>(IEnumerable<int> ids) where T : IData
        {
            string className = typeof(T).Name;
            List<KeyValuePair<string, string>> contentKvps = new List<KeyValuePair<string, string>>();

            IEnumerable<T> CacheAndSave<T>(IEnumerable<T> data) where T : IData
            {
                foreach (var entry in data)
                {
                    // Cache it
                    _cache[className].TryAdd(entry.Id, entry);

                    // Then save it
                    var dir = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data", className));
                    File.WriteAllText(Path.Combine(dir.FullName, $"{entry.Id}.mb"), JsonConvert.SerializeObject(entry, Formatting.None));
                }

                return data;
            }

            contentKvps.Add(new KeyValuePair<string, string>("class", className));
            foreach (var id in ids) contentKvps.Add(new KeyValuePair<string, string>("ids[]", id.ToString()));

            using (var response = _httpClient.PostAsync("", new FormUrlEncodedContent(contentKvps)).Result)
            {
                response.EnsureSuccessStatusCode();

                string responseString = response.Content.ReadAsStringAsync().Result;

                try
                {
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(responseString);

                    // In case no objects were found
                    if (dict.Count == 0)
                        return new List<T>() { default(T) };

                    var data = dict.Values.Select(f => (T)f.ToObject(typeof(T))).ToList();
                    return CacheAndSave(data);
                }
                catch { return null; }
            }
        }

    }
}
