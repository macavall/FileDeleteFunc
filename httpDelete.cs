using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FileDeleteFunc
{
    public class httpDelete
    {
        private readonly ILogger<httpDelete> _logger;
        private readonly IFileService _fileService;

        public httpDelete(ILogger<httpDelete> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        [Function("httpDelete")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            _fileService.DeleteFile();

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
