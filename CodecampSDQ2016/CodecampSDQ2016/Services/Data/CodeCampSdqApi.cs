using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CodecampSDQ2016.Services.Cache;
using Newtonsoft.Json;
using System.Diagnostics;

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
        /// Get All data from api and Save into GlobalCache
        /// </summary>
        /// <returns></returns>
        public async Task FetchData()
        {
            var data = await _client.GetStringAsync("GetData");

            if (string.IsNullOrWhiteSpace(data))
                return;
			
//			var formattedData = data.Substring(1, data.Length - 2).Replace("\\","");

			var apiData = JsonConvert.DeserializeObject<ApiDataDto>(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            if (apiData != null)
            {
                _client.BaseAddress = null;

                var sessions = apiData.Sessions;

                var speakers = apiData.Speakers;

                //Process Speaker Image Url
                foreach (var speaker in speakers)
                {
                    if(string.IsNullOrEmpty(speaker.PhotoUrl))
                        continue;

                    var speakerImage = await _client.GetByteArrayAsync(speaker.PhotoUrl);

                    speaker.BinaryPhoto = speakerImage;
                }

                await GlobalCache.SaveSessions(sessions);

                await GlobalCache.SaveSpeakers(speakers);

				_client.BaseAddress = new Uri(BaseApiUrl);
            }
        }

        /// <summary>
        /// Get All Sessions from GlobalCache
        /// </summary>
        /// <returns>Array of Session object.</returns>
        public async Task<IEnumerable<Session>> GetSessions()
        {
			var sessions = await GlobalCache.GetSessions();

			if(sessions == null)
			{
				await FetchData();

				sessions = await GlobalCache.GetSessions();
			}

            return sessions;
        }

        /// <summary>
        /// Get Session by Id from GlobalCache
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
        /// Get all Speakers from GlobalCache
        /// </summary>
        /// <returns>Array of Speaker object.</returns>
        public async Task<IEnumerable<Speaker>> GetSpeakers()
        {
            var speakers = await GlobalCache.GetSpeakers();

			if(speakers == null)
			{
				await FetchData();

				speakers = await GlobalCache.GetSpeakers();
			}

            return speakers;
        }

        /// <summary>
        /// Get Details of a Speaker from GlobalCache
        /// </summary>
        /// <param name="speakerId">Id of Speaker</param>
        /// <returns>A Speaker object.</returns>
        public async Task<Speaker> GetSpeakerDetails(int speakerId)
        {
            var speakers = await GetSpeakers();

            var speaker = speakers.FirstOrDefault(x => x.Id.Equals(speakerId));

            return speaker;
        }

        /// <summary>
        /// Get all Session of a Speaker from speaker id.
        /// </summary>
        /// <param name="speakerId">Id of Speaker</param>
        /// <returns>Array of Session object.</returns>
        public async Task<IEnumerable<Session>> GetAllSpeakerSessions(int speakerId)
        {
            var allSessions = await GetSessions();

            var speakerSessions = allSessions.Where(x => x.SpeakerId.Equals(speakerId));

            return speakerSessions;
        }
    }
}