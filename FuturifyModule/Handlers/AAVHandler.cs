using FuturifyModule.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement.Metadata;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FuturifyModule.Handlers
{
    public class AAVHandler : ContentHandlerBase
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _clientFactory;

        public AAVHandler(
            IContentDefinitionManager contentDefinitionManager,
            IHttpClientFactory clientFactory,
            ILogger<ContentPartHandlerCoordinator> logger)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public override async Task UpdatedAsync(UpdateContentContext context)
        {
            _logger.LogInformation($"Updated {context.ContentItem.ContentType} !!!!!!");
        }

        public override async Task PublishedAsync(PublishContentContext context)
        {
            var workflowContent = context.ContentItem.As<WorkflowPart>();
            var recruitmentRequestContent = context.ContentItem.As<RecruitmentRequestPart>();

            if (workflowContent.CurrentAssignee.ContentItemIds[0] != workflowContent.PreviousAssignee.ContentItemIds[0])
            {
                var newTask = new
                {
                    Title = "asdasds",
                    Description = "new recruitment request",
                    Assignee = workflowContent.CurrentAssignee.ContentItemIds[0],
                    ContentItemId = context.ContentItem.ContentItemId,
                    ContentType = "Task"
                };

                var body = new StringContent(JsonSerializer.Serialize(newTask), Encoding.UTF8, "application/json");

                var httpClient = _clientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("aav-futurify-auth", "futurify");
                using var httpResponse = await httpClient.PostAsync("http://localhost:5678/webhook-test/create-task", body);
            }

            _logger.LogInformation($"Published {context.ContentItem.ContentType} !!!!!!");
        }

        public override async Task CreatedAsync(CreateContentContext context)
        {
            _logger.LogInformation($"Created {context.ContentItem.ContentType} !!!!!!");
        }
    }
}
