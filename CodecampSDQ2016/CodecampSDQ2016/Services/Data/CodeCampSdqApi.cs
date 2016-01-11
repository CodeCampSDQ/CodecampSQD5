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
        /// Get All data from api
        /// </summary>
        /// <returns></returns>
        public async Task FetchData()
        {
            var data = await _client.GetStringAsync("GetSessions");

            if (string.IsNullOrWhiteSpace(data))
                return;

            var apiData = JsonConvert.DeserializeObject<ApiDataDto>(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            if (apiData != null)
            {
                var sessions = apiData.Sessions;
                var speakers = apiData.Speakers;

                //Process Speaker Image Url
                foreach (var speaker in speakers)
                {

                }

                await GlobalCache.SaveSessions(sessions);
                await GlobalCache.SaveSpeakers(speakers);
            }
        }

        /// <summary>
        /// Get All Sessions
        /// </summary>
        /// <returns>Array of Session object.</returns>
        public async Task<IEnumerable<Session>> GetSessions()
        {
            var sessions = await GlobalCache.GetSessions();

            return sessions;
        }

        /// <summary>
        /// Get Session by Id
        /// </summary>
        /// <param name="sessionId">Id of Session</param>
        /// <returns>return a Session object.</returns>
        public async Task<Session> GetSessionDetails(int sessionId)
        {
            var sessions = await GetSessions();

            var session = sessions.FirstOrDefault(x => x.Id.Equals(sessionId));

            return session;
        }

        /// <summary>
        /// Get all Speakers.
        /// </summary>
        /// <returns>Array of Speaker object.</returns>
        public async Task<IEnumerable<Speaker>> GetSpeakers()
        {
            var speakers = await GlobalCache.GetSpeakers();

            return speakers;
        }

        /// <summary>
        /// Get Details of a Speaker.
        /// </summary>
        /// <param name="speakerId">Id of Speaker</param>
        /// <returns>A Speaker object.</returns>
        public async Task<Speaker> GetSpeakerDetails(int speakerId)
        {
            var speakers = await GetSpeakers();

            var speaker = speakers.FirstOrDefault(x => x.Id.Equals(speakerId));

            return speaker;
        }
    }
}