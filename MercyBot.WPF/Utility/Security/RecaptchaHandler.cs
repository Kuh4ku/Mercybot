using AntiRecaptcha;
using MercyBot.Configurations;
using System;
using System.Threading;

namespace MercyBot.Utility
{
    public static class RecaptchaHandler
    {

        // Fields
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);


        public static string GetResponse(string siteKey)
        {
            _semaphore.Wait();
            string result = null;

            if (!string.IsNullOrEmpty(GlobalConfiguration.Instance.AntiCaptchaKey))
            {
                try
                {
                    using (NoCaptchaProxyless ncp = new NoCaptchaProxyless(GlobalConfiguration.Instance.AntiCaptchaKey, new Uri("https://proxyconnection.touch.dofus.com/recaptcha"), siteKey))
                    {
                        ncp.CreateTask();
                        ncp.WaitForResult(300);

                        result = ncp.GetTaskSolution();
                    }
                }
                catch
                {
                    _semaphore.Release();
                    throw;
                }
            }

            _semaphore.Release();
            return result;
        }

    }
}
