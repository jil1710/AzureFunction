using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ProductConsumer
{
    public class Function1
    {
        // It invoke on queue trigger
        // This function is trigger every time when the new item is inserted into queue storage.

        [FunctionName("ProductConsumer")]
        public void Run([QueueTrigger("add-product", Connection = "AzureQueue")]string myQueueItem, ILogger log)
        {
            // Process the queue item or message.
            // update the database or request for shipping the product.
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
