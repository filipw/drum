﻿using System.Net.Http;

namespace Drum
{
    public static class HttpRequestExtensions
    {
        public static UriMaker<T> TryGetUriMakerFor<T>(this HttpRequestMessage req)
        {
            var factory =  req.GetConfiguration().TryGetUriMakerFactory();
            return factory != null ? factory.NewUriMakerFor<T>(req) : null;
        }
    }
}