
![cbimage](https://github.com/jil1710/readmedemo/assets/125335932/f63c6e59-83c2-4f93-be8e-fec3748982d2)

# Azure Function

- Azure Functions is a serverless solution that allows you to write less code, maintain less infrastructure, and save on costs. Instead of worrying about deploying and maintaining servers, the cloud infrastructure provides all the up-to-date resources needed to keep your applications running.

-  In simple words, Azure Function is a serverless compute service that enables user to run event-triggered code without having to provision or manage infrastructure. Being as a trigger-based service, it runs a script or piece of code in response to a variety of events.

## How Do You Call Azure Function?
    
- Azure Functions can be called when triggered by the events from other services. Being event driven, the application platform has capabilities to implement code triggered by events occurring in any third-party service or on-premise system.

- Azure Functions provides templates to get you started with key scenarios, including the following:

    - **HTTPTrigger :-** Trigger the execution of your code by using an HTTP request.
    - **TimerTrigger :-** Execute clean up or other batch tasks on a predefined schedule.
    - **CosmosDBTrigger :-** Process Azure Cosmos DB documents when they are added or updated in collections in a NoSQL database.
    - **BlobTrigger :-** Process Azure Storage blobs when they are added to containers. You might use this function for image resizing.
    - **QueueTrigger :-** Respond to messages as they arrive in an Azure Storage queue.
    - **EventGridTrigger :-** Respond to events delivered to a subscription in Azure Event Grid. Supports a subscription-based model for receiving events, which includes filtering. A good solution for building event-based architectures.
    - **EventHubTrigger :-** Respond to events delivered to an Azure Event Hub. Particularly useful in application instrumentation, user experience or workflow processing, and internet-of-things (IoT) scenarios.
    - **ServiceBusQueueTrigger :-** Connect your code to other Azure services or on-premises services by listening to message queues.
    - **ServiceBusTopicTrigger :-** Connect your code to other Azure services or on-premises services by subscribing to topics.

## How Do I Make an Azure Function App?

- Azure Functions can be built in two ways either through Azure portal or using Visual Studio. Below are the step by step process to create and deploy Azure Functions.

- **Create Azure Functions in Azure Portal:**
    - Click on Create a resource, select on Azure Functions App in Compute section and Click Create.
    - Provide the necessary details and create it.

- **Create Azure Functions in Visual Studio:**
  - Select **File -> New Project**. Select Azure Function project.
  - Provide the necessary details like Name, path, Function App version and Trigger option. Click Create.

## Where Are Azure Functions Used?

- Azure Functions are best suited for smaller apps have events that can work independently of other websites. Some of the common azure functions are sending emails, starting backup, order processing, task scheduling such as database cleanup, sending notifications, messages, and IoT data processing.

    - **Process file uploads :** In a retail solution, a partner system can submit product catalog information as files into blob storage. You can use a blob triggered function to validate, transform, and process the files into the main system as they're uploaded.

        ![image](https://github.com/jil1710/readmedemo/assets/125335932/668c7e7e-241a-4329-8917-780325de84f2)


    - **Run scheduled tasks :** Functions enables you to run your code based on a cron schedule that you define. For example, might be analyzed for duplicate entries every 15 minutes to avoid multiple communications going out to the same customer.
 
        ![image](https://github.com/jil1710/readmedemo/assets/125335932/3e1ce470-5573-4877-9c9f-fc47cecc6a68)

      ```csharp
          [FunctionName("TimerTriggerCSharp")]
          public static void Run([TimerTrigger("0 */15 * * * *")]TimerInfo myTimer, ILogger log)
          {
              if (myTimer.IsPastDue)
              {
                  log.LogInformation("Timer is running late!");
              }
              log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
          
              // Perform the database deduplication
          }
      ```

    - **Respond to database changes :** There are processes where you might need to log, audit, or perform some other operation when stored data changes. Functions triggers provide a good way to get notified of data changes to initial such an operation.
         
        ![image](https://github.com/jil1710/readmedemo/assets/125335932/6e2a69e5-73fd-46d8-88f6-6ae5a1377a01)

     - **Build a scalable web API :** An HTTP triggered function defines an HTTP endpoint. These endpoints run function code that can connect to other services directly or by using binding extensions. You can compose the endpoints into a web-based API. Http Trigger that is executed whenever an HTTP request is made.
 
         ![image](https://github.com/jil1710/readmedemo/assets/125335932/8b2d7212-cd90-447c-8726-ee76e7381ee2)

       - For Example
      
         ![image](https://github.com/jil1710/readmedemo/assets/125335932/0cabff9c-8369-4bc9-9823-61ed2126e899)

          ![image](https://github.com/jil1710/readmedemo/assets/125335932/ad0b2d93-3416-489a-b9c2-49c9f0a03ff3)

## To Publish the Azure Functions from Visual studio: 

- Right Click on the Project Name, Select Publish.
- Provide the details like Resource group name, storage account and more. After this process, the profile will be created and ready to publish.
- Click Publish.
