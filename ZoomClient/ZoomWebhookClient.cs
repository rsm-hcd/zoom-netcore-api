using AndcultureCode.ZoomClient.Extensions;
using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Webhooks;
using RestSharp;
using System;

namespace AndcultureCode.ZoomClient
{
    public class ZoomWebhookClient : IZoomWebhookClient
    {
        #region Constants

        const string DELETE_WEBHOOK = "webhooks/{webhookId}";

        const string GET_LIST_WEBHOOKS = "webhooks";
        const string GET_WEBHOOK       = "webhooks/{webhookId}";

        const string PATCH_WEBHOOK = "webhooks/{webhookId}";

        const string POST_CREATE_WEBHOOK = "webhooks";

        #endregion

        #region Properties

        ZoomClientOptions Options { get; set; }
        RestClient WebClient { get; set; }

        #endregion

        #region Constructor

        internal ZoomWebhookClient(ZoomClientOptions options, RestClient webClient)
        {
            Options = options;
            WebClient = webClient;
        }

        #endregion

        #region IZoomUsersClient Implementation

        public ListWebhooks GetWebhooks()
        {
            var request = BuildRequestAuthorization(GET_LIST_WEBHOOKS, Method.GET);

            var response = WebClient.Execute<ListWebhooks>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }
        public Webhook CreateWebhook(CreateWebhook createWebhook)
        {
            var validateResult = createWebhook.Validate();
            if (validateResult.Count > 0)
            {
                throw new Exception($"CreateWebhook request does not pass validation. {string.Join(" :: ", validateResult)}");
            }

            var request = BuildRequestAuthorization(POST_CREATE_WEBHOOK, Method.POST);
            request.AddJsonBody(createWebhook);

            var response = WebClient.Execute<Webhook>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }

        public Webhook GetWebhook(string webhookId)
        {
            var request = BuildRequestAuthorization(GET_WEBHOOK, Method.GET);
            request.AddParameter("webhookId", webhookId, ParameterType.UrlSegment);

            var response = WebClient.Execute<Webhook>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }

        public bool UpdateWebhook(string webhookId, UpdateWebhook webhook)
        {
            var request = BuildRequestAuthorization(PATCH_WEBHOOK, Method.PATCH);
            request.AddParameter("webhookId", webhookId, ParameterType.UrlSegment);
            request.AddJsonBody(webhook);

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public bool DeleteWebhook(string webhookId)
        {
            var request = BuildRequestAuthorization(DELETE_WEBHOOK, Method.DELETE);
            request.AddParameter("webhookId", webhookId, ParameterType.UrlSegment);

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        #endregion

        #region Private Methods

        RestRequest BuildRequestAuthorization(string resource, Method method)
        {
            return WebClient.BuildRequestAuthorization(Options, resource, method);
        }

        #endregion
    }
}
