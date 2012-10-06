using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using Facebook.Api;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IFacebookConfig config = new FacebookConfig();
            IFacebookApi facebook = new FacebookApi(config);
            
        }
    }

    internal class FacebookConfig : IFacebookConfig
    {
        public string BaseUrl { get { return "https://graph.facebook.com/"; } }
        public string ApiKey { get { return "159997617394589"; } }
        public string Secret { get { return "ced7de09d14698199c88de1e6c2b35ad"; } }
    }
}
