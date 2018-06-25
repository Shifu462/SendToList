using System;
using JsonRequest;
using Newtonsoft.Json;
using AnticaptchaApi.JsonApiRequest;
using AnticaptchaApi.JsonApiResponse;

namespace AnticaptchaApi
{
    class AntiCaptcha
    {
        protected Request RequestWorker = new Request();

        protected string AnticaptchaKey { get; set; }
        public float Balance { get => GetBalance(); }

        public AntiCaptcha(string anticaptchaKey)
        {
            AnticaptchaKey = anticaptchaKey;
        }

        /// <summary>
        /// Get anticaptcha balance.
        /// </summary>
        /// <returns>Returns anticaptcha balance.</returns>
        protected float GetBalance()
        {
            var req = new GetBalance { ClientKey = AnticaptchaKey };

            var reqJson = JsonConvert.SerializeObject(req);
            var response = (BalanceResult) RequestWorker.Execute<BalanceResult>(ApiMethodUrl.GetBalance, reqJson, "POST");

            if (response.ErrorId != 0)
                throw new Exception($"{response.ErrorCode} #{response.ErrorId}:\n {response.ErrorDescription}");

            return response.Balance;
        }
        
        public int CreateTask(string fileLink)
        {
            var req = new CreateTaskRequest
            {
                ClientKey = AnticaptchaKey,
                CaptchaTask = new JsonCaptchaTask.ImageToTextTask(fileLink)
            };

            var reqJson = JsonConvert.SerializeObject(req);
            var response = (CreateTaskResult) RequestWorker.Execute<CreateTaskResult>(ApiMethodUrl.CreateTask, reqJson, "POST");

            if (response.ErrorId != 0)
                throw new Exception($"{response.ErrorCode} #{response.ErrorId}:\n {response.ErrorDescription}");

            return response.TaskId;
        }

        public AnticaptchaTaskResult GetTaskResult(int taskId)
        {
            var req = new GetTaskResultRequest
            {
                ClientKey = AnticaptchaKey,
                TaskId = taskId
            };

            var reqJson = JsonConvert.SerializeObject(req);
            var taskResult = (AnticaptchaTaskResult)RequestWorker.Execute<AnticaptchaTaskResult>(ApiMethodUrl.GetTaskResult, reqJson, "POST");

            if (taskResult.ErrorId != 0)
                throw new Exception($"{taskResult.ErrorCode} #{taskResult.ErrorId}:\n {taskResult.ErrorDescription}");
            
            return taskResult;
        }

    }
}
