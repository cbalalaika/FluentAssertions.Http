﻿using System.Net.Http;
using System.Text.Json;

namespace FluentAssertions.Http
{
    public static class HttpResponseMessageExtensions
    {
        private static readonly JsonSerializerOptions SerializationOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Returns an <see cref="HttpResponseMessageAssertions"/> object that can be used to assert the
        /// current <see cref="HttpResponseMessage"/>.
        /// </summary>
        public static HttpResponseMessageAssertions Should(
            this HttpResponseMessage instance)
        {
            return new HttpResponseMessageAssertions(instance);
        }
        
        internal static string GetContent(
            this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }

        internal static T GetContentAs<T>(
            this HttpResponseMessage response)
        {
            return JsonSerializer.Deserialize<T>(response.GetContent(), SerializationOptions);
        }
    }
}