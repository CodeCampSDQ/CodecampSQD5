using System;
using LinqToTwitter;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	public interface ITwitterService
	{
		void TweetIt(string phrase, CancellationTokenSource cancellationTokenSource);
	}
}