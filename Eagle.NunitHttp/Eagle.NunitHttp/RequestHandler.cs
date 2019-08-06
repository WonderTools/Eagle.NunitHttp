﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WonderTools.Eagle.HttpContract;
using WonderTools.Eagle.NUnit;

namespace WonderTools.Eagle.NUnitHttp
{
    public static class RequestHandler
    {
        public static async Task<IActionResult> HandleRequest(this HttpRequest request, string nodeSecret,
            params TestableAssembly[] assemblies)
        {
            var serializedTrigger = await new StreamReader(request.Body).ReadToEndAsync();
            var trigger = JsonConvert.DeserializeObject<TestTrigger>(serializedTrigger);

            if (!string.IsNullOrWhiteSpace(nodeSecret))
            {
                if (nodeSecret != trigger.NodeSecret)
                {
                    return new ForbidResult("The node secret is invalid");
                }
            }

            var engine = new EagleEngine(assemblies);
            var discoveredTestSuites = engine.GetDiscoveredTestSuites();
            var httpRequestResultHandler = new HttpRequestResultHandler(discoveredTestSuites, trigger.NodeName, trigger.RequestId, trigger.CallBackUrl);
            var results = await engine.ExecuteTest(httpRequestResultHandler, trigger.Id);
            var result = new TestReport()
            {
                NodeName = trigger.NodeName,
                RequestId = trigger.RequestId,
                TestResults = results,
                TestSuites = discoveredTestSuites
            };
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }


        public static async Task<IActionResult> HandleRequest(this HttpRequest request, params TestableAssembly[] assemblies)
        {
            return await request.HandleRequest(string.Empty, assemblies);
        }
    }
}