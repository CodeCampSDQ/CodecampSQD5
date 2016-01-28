using System;
using CoreTweet;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using CodecampSDQ2016.iOS;
using UIKit;

[assembly: Dependency (typeof (TwitterServiceIOS))]
namespace CodecampSDQ2016.iOS
{
	public class TwitterServiceIOS : ITwitterService
	{
		Tokens _tokens;

		public TwitterServiceIOS ()
		{
			var session = OAuth.Authorize(AppKeys.TWITTER_APY_KEY, AppKeys.TWITTER_CONSUMER_SECRET);
 
			_tokens = session.GetTokens(AppKeys.TWITTER_PINCODE);
		}

		public void TweetIt (string phrase, CancellationTokenSource token)
		{
			_tokens.Statuses.UpdateAsync(status: phrase, cancellationToken: token.Token);
		}

	}
}

