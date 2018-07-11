using AndcultureCode.ZoomClient.Models.Webhooks;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomWebhookClient
    {
        /// <summary>
        /// List webhooks for an account. https://zoom.github.io/api/#list-webhooks
        /// </summary>
        /// <returns></returns>
        ListWebhooks GetWebhooks();

        /// <summary>
        /// Create a webhook for an account. https://zoom.github.io/api/#create-a-webhook
        /// </summary>
        /// <param name="createWebhook"></param>
        /// <returns></returns>
        Webhook CreateWebhook(CreateWebhook createWebhook);

        /// <summary>
        /// Retrieve a webhook. https://zoom.github.io/api/#retrieve-a-webhook
        /// </summary>
        /// <param name="webhookId"></param>
        /// <returns></returns>
        Webhook GetWebhook(string webhookId);

        /// <summary>
        /// Update a webhook. https://zoom.github.io/api/#update-a-webhook
        /// </summary>
        /// <param name="webhookId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        bool UpdateWebhook(string webhookId, UpdateWebhook webhook);

        /// <summary>
        /// Delete a webhook. https://zoom.github.io/api/#delete-a-webhook
        /// </summary>
        /// <param name="webhookId"></param>
        /// <returns></returns>
        bool DeleteWebhook(string webhookId);
    }
}
