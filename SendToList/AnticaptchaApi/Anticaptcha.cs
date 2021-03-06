﻿using System;
using Newtonsoft.Json;
using AnticaptchaApi.JsonApiRequest;
using AnticaptchaApi.JsonApiResponse;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace AnticaptchaApi
{
	internal class AntiCaptcha
	{
		protected string AnticaptchaKey { get; set; }

		public AntiCaptcha(string anticaptchaKey)
		{
			this.AnticaptchaKey = anticaptchaKey;
		}

		/// <summary>
		/// Get anticaptcha balance.
		/// </summary>
		/// <returns>Returns anticaptcha balance.</returns>
		public float GetBalance()
		{
			var req = new GetBalance { ClientKey = AnticaptchaKey };

			var reqJson = JsonConvert.SerializeObject(req);
			var response = (BalanceResult)ExecuteRequest<BalanceResult>(ApiMethodUrl.GetBalance, reqJson, "POST");

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

			var response = (CreateTaskResult)ExecuteRequest<CreateTaskResult>(ApiMethodUrl.CreateTask, reqJson);

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

			var taskResult = (AnticaptchaTaskResult)ExecuteRequest<AnticaptchaTaskResult>(ApiMethodUrl.GetTaskResult, reqJson);

			if (taskResult.ErrorId != 0)
				throw new Exception($"{taskResult.ErrorCode} #{taskResult.ErrorId}:\n {taskResult.ErrorDescription}");

			return taskResult;
		}

		public static object ExecuteRequest<TT>(string url, string json, string method = "POST")
		{
			var jss = new JavaScriptSerializer();

			var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = method;

			using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				streamWriter.Write(json);
			}

			var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			string result;
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				result = streamReader.ReadToEnd();
			}

			return jss.Deserialize<TT>(result);
		}

	}
}
