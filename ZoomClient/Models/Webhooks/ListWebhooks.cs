using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Webhooks
{
    public class ListWebhooks : BaseList
    {
        /// <summary>
        /// Zoom property: webhooks
        /// </summary>
        public List<Webhook> Webhooks { get; set; }
    }
}
