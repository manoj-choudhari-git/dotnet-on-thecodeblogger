using Microsoft.Extensions.Logging;

namespace HostBasedConsoleApp
{
    internal class Worker
    {
        private readonly ILogger<Worker> logger;

        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }
        public void Execute()
        {
            logger.LogInformation("This is Info log");
            logger.LogWarning("This is Warning log");
            logger.LogError("This is Error log");
            logger.LogCritical("This is Critical log");
        }
    }
}