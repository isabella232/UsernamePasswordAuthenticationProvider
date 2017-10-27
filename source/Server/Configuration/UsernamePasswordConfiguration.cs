﻿using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration
{
    public class UsernamePasswordConfiguration : ExtensionConfigurationDocument
    {
        protected UsernamePasswordConfiguration()
        {
        }

        public UsernamePasswordConfiguration(string name, string extensionAuthor) : base(name, extensionAuthor, "1.0")
        {
            Id = UsernamePasswordConfigurationStore.SingletonId;
        }
    }
}