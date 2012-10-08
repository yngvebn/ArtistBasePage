using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using Facebook.Api;
using Youtube;
using Youtube.Api;

namespace TestApplication
{
    class 
        Program
    {
        static void Main(string[] args)
        {
            IYoutubeConfig config = new YoutubeConfig();
            IYoutubeApi youtubeApi = new YoutubeApi(config);


            var ev = youtubeApi.User.GetUserFeed("arnevatnoy");
        }
    }

    internal class YoutubeConfig: IYoutubeConfig
    {
        public string BaseUrl { get { return "https://gdata.youtube.com/feeds/api"; } }
        public string ClientId { get { return "159997617394589"; } }
        public string Secret { get { return "ced7de09d14698199c88de1e6c2b35ad"; } }
        public string Token { get { return "159997617394589|lxqDIRGGL-6lNMVZtERkbJTNOeM"; } }
    }
}
