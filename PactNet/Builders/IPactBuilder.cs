﻿using Newtonsoft.Json;
using PactNet.Mocks.MockHttpService;
using PactNet.Models;

namespace PactNet
{
    public interface IPactBuilder : IPactBaseBuilder<IPactBuilder>
    {
        IMockProviderService MockService(int port, bool enableSsl = false, IPAddress host = IPAddress.Loopback);
        IMockProviderService MockService(int port, JsonSerializerSettings jsonSerializerSettings, bool enableSsl = false, IPAddress host = IPAddress.Loopback);
    }
}