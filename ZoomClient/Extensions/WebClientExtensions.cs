using AndcultureCode.ZoomClient.Models;
using Jose;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndcultureCode.ZoomClient.Extensions
{
    public static class WebClientExtensions
    {
        public static RestRequest BuildRequestAuthorization(this RestClient webClient, ZoomClientOptions options, string resource, Method method)
        {
            var request = new RestRequest(resource, method);

            var payload = new Dictionary<string, object>()
            {
                { "iss", options.ZoomApiKey },
                { "exp", new DateTimeOffset(DateTime.UtcNow.AddMinutes(1)).ToUnixTimeSeconds() }
            };

            webClient.Authenticator = new JwtAuthenticator(JWT.Encode(payload, Encoding.UTF8.GetBytes(options.ZoomApiSecret), JwsAlgorithm.HS256));
            request.JsonSerializer = new NewtonsoftJsonSerializer();

            return request;
        }
    }
}
