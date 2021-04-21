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


        public override async System.Threading.Tasks.Task PublishedAsync(PublishContentContext context)
        {
            var recruitmentRequestContent = context.ContentItem.As<RecruitmentRequest>();
            var workflowContent = context.ContentItem.As<WorkflowPart>();

            if (workflowContent == null || recruitmentRequestContent == null) return;

            if (workflowContent.CurrentAssignee.ContentItemIds.Length == 0 || workflowContent.PreviousAssignee.ContentItemIds.Length == 0)
            {
                return;
            }
            
            if (workflowContent.CurrentAssignee.ContentItemIds[0] != workflowContent.PreviousAssignee.ContentItemIds[0])
            {
                var newTask = new
                {
                    Title = context.ContentItem.DisplayText,
                    Description = recruitmentRequestContent.Description.Text,
                    Assignee = workflowContent.CurrentAssignee.ContentItemIds[0],
                    ParentContentItemId = context.ContentItem.ContentItemId,
                    ParentContentType = context.ContentItem.ContentType
                };

                var body = new StringContent(JsonSerializer.Serialize(newTask), Encoding.UTF8, "application/json");

                var httpClient = _clientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("aav-futurify-auth", "futurify");
                using var httpResponse = await httpClient.PostAsync("http://localhost:5678/webhook-test/create-task", body);
            }

            _logger.LogInformation($"Published {context.ContentItem.ContentType} !!!!!!");
        }
    }
}
