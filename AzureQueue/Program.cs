
using Azure.Storage.Queues;
using AzureQueue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using System.Text.Json;

namespace AzureQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure the Azure Queue Client
            builder.Services.AddAzureClients(option =>
            {
                option.AddClient<QueueClient, QueueClientOptions>((con, _, _) =>
                {
                    con.MessageEncoding = QueueMessageEncoding.Base64;
                    var connection = builder.Configuration.GetConnectionString("AzureQueue");
                    var queue = "add-product";
                    return new QueueClient(connection,queue,con);
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapPost("/product", async ([FromBody] Product product, QueueClient queueClient) =>
            {
                // store the data into the db in order to place the order

                // send it to the azure queue in order to consume by consumer or process it in background.
                var message = JsonSerializer.Serialize(product);  
                await queueClient.SendMessageAsync(message,null,TimeSpan.FromSeconds(30));

                return Results.Ok($"Product Created -->> Product Id -->> {product.Id}");

            });
            

            app.Run();
        }
    }
}