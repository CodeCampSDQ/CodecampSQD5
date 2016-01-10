using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CodecampSDQ2016.Services.Cache;
using Newtonsoft.Json;

namespace CodecampSDQ2016.Services.Data
{
    public class CodeCampSdqApi
    {
        private const string BaseApiUrl = "http://codecampsdq5api.azurewebsites.net/api/CodeCampSdq/";
        private readonly HttpClient _client;

        public CodeCampSdqApi()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseApiUrl)
            };
        }

        /// <summary>
        /// Fetch all data from API and return an array of Session.
        /// This method try to get data from cache, if cache is empty,
        /// connect to API and get raw data of Speakers and Sessions, then,
        /// Parse this Data and save to cache.
        /// </summary>
        /// <returns>Array of Session object.</returns>
        public async Task<IEnumerable<Session>> GetSessions()
        {
            var sessions = await GlobalCache.GetSessions();

            if (sessions.Any())
                return sessions;

            var data = await _client.GetStringAsync("GetSessions");

            if (string.IsNullOrWhiteSpace(data))
                return sessions;

            var apiData = JsonConvert.DeserializeObject<ApiDataDto>(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            if (apiData != null)
            {
                sessions = apiData.Sessions;
                var speakers = apiData.Speakers;

                await GlobalCache.SaveSessions(sessions);

                //Process Speaker Image Url
                foreach (var speaker in speakers)
                {
                    
                }

                await GlobalCache.SaveSpeakers(speakers);
            }

            return sessions;
        }

        public async Task<Session> GetSession(int sessionId)
        {
            var sessions = await GetSessions();

            var session = sessions.FirstOrDefault(x => x.Id.Equals(sessionId));

            return session;
        }

        public async Task<IEnumerable<Speaker>> GetSpeakers()
        {
            var speakers = await GlobalCache.GetSpeakers();

            return speakers;
        }

        public async Task<Speaker> GetSpeakerDetails(int speakerId)
        {
            var speakers = await GetSpeakers();

            var speaker = speakers.FirstOrDefault(x => x.Id.Equals(speakerId));

            return speaker;
        }
    }
}