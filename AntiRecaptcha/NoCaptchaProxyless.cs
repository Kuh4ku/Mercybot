using AntiRecaptcha.Base;
using Newtonsoft.Json.Linq;
using System;

namespace AntiRecaptcha
{
    public class NoCaptchaProxyless : AnticaptchaBase
    {

        // Properties
        public Uri WebsiteUrl { protected get; set; }
        public string WebsiteKey { protected get; set; }
        public string WebsiteSToken { protected get; set; }


        // Constructor
        public NoCaptchaProxyless(string clientKey, Uri websiteUrl, string websiteKey)
        {
            ClientKey = clientKey;
            WebsiteUrl = websiteUrl;
            WebsiteKey = websiteKey;
        }


        public override JObject GetPostData()
        {
            return new JObject
            {
                {"type", "NoCaptchaTaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"websiteKey", WebsiteKey},
                {"websiteSToken", WebsiteSToken}
            };
        }

        public string GetTaskSolution()
            => TaskInfo.Solution.GRecaptchaResponse;

    }
}
