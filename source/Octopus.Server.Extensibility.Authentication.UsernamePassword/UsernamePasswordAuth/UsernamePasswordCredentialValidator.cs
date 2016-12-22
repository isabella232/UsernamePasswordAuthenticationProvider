﻿using Octopus.Data.Storage.User;
using Octopus.Server.Extensibility.Authentication.Storage.User;
using Octopus.Server.Extensibility.Authentication.UsernamePassword.Configuration;

namespace Octopus.Server.Extensibility.Authentication.UsernamePassword.UsernamePasswordAuth
{
    public class UsernamePasswordCredentialValidator : IUsernamePasswordCredentialValidator
    {
        readonly IUsernamePasswordConfigurationStore configurationStore;
        readonly IUserStore userStore;

        public UsernamePasswordCredentialValidator(
            IUsernamePasswordConfigurationStore configurationStore,
            IUserStore userStore)
        {
            this.configurationStore = configurationStore;
            this.userStore = userStore;
        }

        public int Priority => 50;

        public AuthenticationUserCreateOrUpdateResult ValidateCredentials(string username, string password)
        {
            if (!configurationStore.GetIsEnabled())
            {
                return new AuthenticationUserCreateOrUpdateResult();
            }

            var user = userStore.GetByUsername(username);

            if (user != null && user.ValidatePassword(password))
            {
                return new AuthenticationUserCreateOrUpdateResult(user);
            }

            return new AuthenticationUserCreateOrUpdateResult("Invalid username or password.");
        }
    }
}