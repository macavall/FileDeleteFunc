using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace FileDeleteFunc
{
    public class httpcreate
    {
        private readonly ILogger<httpcreate> _logger;
        private readonly IFileService _fileService;

        public httpcreate(ILogger<httpcreate> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        [Function("httpcreate")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // get paramater from req object
            string? count = req.Query["count"];

            // check if id is null
            if (count == null)
            {
                _fileService.WriteFile();
            }
            else
            {
                _fileService.WriteFile(Convert.ToInt32(count));
            }

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
