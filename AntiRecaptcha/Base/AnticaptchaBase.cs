using AntiRecaptcha.Base.Responses;
using AntiRecaptcha.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace AntiRecaptcha.Base
{
    public abstract class AnticaptchaBase : IDisposable
    {

        // Fields
        private const string Host = "api.anti-captcha.com";
        private const SchemeTypes Scheme = SchemeTypes.HTTPS;


        // Properties
        public int TaskId { get; private set; }
        public string ClientKey { set; private get; }
        public TaskResultResponse TaskInfo { get; protected set; }


        public abstract JObject GetPostData();

        public void CreateTask()
        {
            var taskJson = GetPostData();
            var jsonPostData = new JObject();
            jsonPostData["clientKey"] = ClientKey;
            jsonPostData["task"] = taskJson ?? throw new Exception("A task preparing error.");
            
            dynamic postResult = JsonPostRequest(ApiMethods.CreateTask, jsonPostData);

            if (postResult == null || postResult.Equals(false))
                throw new Exception("API error");

            var response = new CreateTaskResponse(postResult);

            if (!response.ErrorId.Equals(0))
                throw new Exception(response.ErrorDescription);

            if (response.TaskId == null)
                throw new Exception("Failed to parse taskId");

            TaskId = (int)response.TaskId;
        }

        public void WaitForResult(int maxSeconds = 120, int currentSecond = 0)
        {
            if (currentSecond >= maxSeconds)
                throw new Exception("Time out");

            if (currentSecond.Equals(0))
            {
                Thread.Sleep(3000);
            }
            else
            {
                Thread.Sleep(1000);
            }

            var jsonPostData = new JObject();
            jsonPostData["clientKey"] = ClientKey;
            jsonPostData["taskId"] = TaskId;

            dynamic postResult = JsonPostRequest(ApiMethods.GetTaskResult, jsonPostData);

            if (postResult == null || postResult.Equals(false))
                throw new Exception("API error");

            TaskInfo = new TaskResultResponse(postResult);

            if (!TaskInfo.ErrorId.Equals(0))
                throw new Exception(TaskInfo.ErrorDescription);

            if (TaskInfo.Status.Equals(TaskResultResponse.StatusType.Processing))
            {
                WaitForResult(maxSeconds, currentSecond + 1);
                return;
            }

            if (TaskInfo.Status.Equals(TaskResultResponse.StatusType.Ready))
            {
                if (TaskInfo.Solution.GRecaptchaResponse == null && TaskInfo.Solution.Text == null)
                    throw new Exception("Got no 'solution' field from API");

                return;
            }

            throw new Exception("An unknown API status, please update your software");
        }

        private dynamic JsonPostRequest(ApiMethods methodName, JObject jsonPostData)
        {
            string error;
            var methodNameStr = Char.ToLowerInvariant(methodName.ToString()[0]) + methodName.ToString().Substring(1);

            dynamic data = HttpHelper.Post(
                new Uri(Scheme + "://" + Host + "/" + methodNameStr),
                JsonConvert.SerializeObject(jsonPostData, Formatting.Indented),
                out error
                );

            if (String.IsNullOrEmpty(error))
            {
                if (data == null)
                {
                    error = "Got empty or invalid response from API";
                }
                else
                {
                    return data;
                }
            }
            else
            {
                error = "HTTP or JSON error: " + error;
            }

            throw new Exception(error);
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                TaskId = 0;
                ClientKey = null;
                TaskInfo = null;

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

    }
}
