using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Akavache;

namespace CodecampSDQ2016.Services.Cache
{
    public static class GlobalCache
    {
        private const string SessionKey = "sessions";
        private const string SpeakersKey = "speakers";

        public static async Task SaveSessions(IEnumerable<Session> sessions)
        {
            await BlobCache.UserAccount.InsertObject(SessionKey, sessions);
        }

        public static async Task<IEnumerable<Session>> GetSessions()
        {
            var sessions = await BlobCache.UserAccount.GetObject<IEnumerable<Session>>(SessionKey);

            return sessions;
        }

        public static async Task SaveSpeakers(IEnumerable<Speaker> speakers)
        {
            await BlobCache.UserAccount.InsertObject(SpeakersKey, speakers);
        }

        public static async Task<IEnumerable<Speaker>> GetSpeakers()
        {
            var speakers = await BlobCache.UserAccount.GetObject<IEnumerable<Speaker>>(SpeakersKey);

            return speakers;
        }

        public static async Task ClearCache()
        {
            await BlobCache.UserAccount.Vacuum();
        }
    }
}