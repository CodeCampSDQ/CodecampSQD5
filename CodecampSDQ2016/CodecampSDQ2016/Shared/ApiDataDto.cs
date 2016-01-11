using System.Collections.Generic;

namespace CodecampSDQ2016
{
    public class ApiDataDto
    {
        public ApiDataDto()
        {
            Sessions = new List<Session>();
            Speakers = new List<Speaker>();
        }

        public List<Session> Sessions { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}