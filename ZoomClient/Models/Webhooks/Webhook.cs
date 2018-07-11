using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Webhooks
{
    public class Webhook
    {
        /// <summary>
        /// Zoom property: webhook_id
        /// </summary>
        public string WebhookId { get; set; }

        /// <summary>
        /// Zoom property: url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Zoom property: auth_user
        /// </summary>
        public string AuthUser { get; set; }

        /// <summary>
        /// Zoom property: auth_password
        /// </summary>
        public string AuthPassword { get; set; }

        /// <summary>
        /// Zoom property: events
        /// </summary>
        public List<string> Events { get; set; }
    }
}
