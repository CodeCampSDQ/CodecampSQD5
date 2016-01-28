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
			return await Task.Run<IEnumerable<Session>>(async ()=>{

				IEnumerable<Session> sessions = null;

				try
				{
					sessions = await BlobCache.UserAccount.GetObject<IEnumerable<Session>>(SessionKey);
				}
				catch(KeyNotFoundException)
				{
				}

				return sessions;
			});
        }

		public static async Task<bool> CheckIfEmpty()
		{
			return await Task.Run<bool>(async ()=>{

				IEnumerable<Session> session = null;

				IEnumerable<Speaker> speakers = null;

				try
				{
					session = await GetSessions();

					speakers = await GetSpeakers();

				}
				catch(KeyNotFoundException)
				{
				}

				return (session == null || speakers == null);
			});
		}

        public static async Task SaveSpeakers(IEnumerable<Speaker> speakers)
        {
            await BlobCache.UserAccount.InsertObject(SpeakersKey, speakers);
        }

        public static async Task<IEnumerable<Speaker>> GetSpeakers()
        {
			return await Task.Run<IEnumerable<Speaker>>(async ()=>{

				IEnumerable<Speaker> speakers = null;

				try
				{
					speakers = await BlobCache.UserAccount.GetObject<IEnumerable<Speaker>>(SpeakersKey);
				}
				catch(KeyNotFoundException)
				{
				}

				return speakers;
			});
        }

        public static async Task ClearCache()
        {
            await BlobCache.UserAccount.Vacuum();
        }
    }
}