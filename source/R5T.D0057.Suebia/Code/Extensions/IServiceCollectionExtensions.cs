using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;


namespace R5T.D0057.Suebia
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CredentialsFilePathProvider"/> implementation of <see cref="ICredentialsFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCredentialsFilePathProvider(this IServiceCollection services,
            IServiceAction<ICredentialsFileNameProvider> credentialsFileNameProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProvider)
        {
            services
                .AddSingleton<ICredentialsFilePathProvider, CredentialsFilePathProvider>()
                .Run(credentialsFileNameProviderAction)
                .Run(secretsDirectoryFilePathProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CredentialsFilePathProvider"/> implementation of <see cref="ICredentialsFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICredentialsFilePathProvider> AddCredentialsFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ICredentialsFileNameProvider> credentialsFileNameProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<ICredentialsFilePathProvider>(() => services.AddCredentialsFilePathProvider(
                credentialsFileNameProviderAction,
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}
