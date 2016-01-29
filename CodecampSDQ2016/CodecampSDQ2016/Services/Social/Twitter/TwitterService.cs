using System;
using System.Threading.Tasks;
using System.Threading;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class TwitterService : ITwitterService
	{
//		TwitterCredentials _credentials;
//
//		ILoggedUser _user;
//
		public TwitterService ()
		{
//			var connected = CrossConnectivity.Current.IsConnected;
//
//			if(connected)
//			{
//				_credentials = new TwitterCredentials (AppKeys.TWITTER_CONSUMER_KEY, AppKeys.TWITTER_CONSUMER_SECRET, AppKeys.TWITTER_ACCESSTOKEN,AppKeys.TWITTER_ACESSTOKENSECRET);
// 				
//				_user = User.GetLoggedUser (_credentials);
//			}
		}

		public void TweetIt (string phrase, CancellationTokenSource cancellationTokenSource)
		{
//			_user.PublishTweet(phrase);

			Device.OpenUri(new Uri("twitter://post?message=hello%20world"));
		}
	}
}

