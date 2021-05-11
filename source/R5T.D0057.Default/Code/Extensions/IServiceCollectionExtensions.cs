using System;

using Microsoft.Extensions.DependencyInjection;

using Amazon;
using Amazon.Runtime;

using R5T.Dacia;


namespace R5T.D0057.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedRegionEndpointProvider"/> implementation of <see cref="IRegionEndpointProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedRegionEndpointProvider(this IServiceCollection services, RegionEndpoint regionEndpoint)
        {
            services.AddSingleton<IRegionEndpointProvider>(new ConstructorBasedRegionEndpointProvider(regionEndpoint));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedAwsRegionEndpointProvider"/> implementation of <see cref="IAwsRegionEndpointProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRegionEndpointProvider> AddConstructorBasedRegionEndpointProviderAction(this IServiceCollection services, RegionEndpoint regionEndpoint)
        {
            var serviceAction = ServiceAction.New<IRegionEndpointProvider>(() => services.AddConstructorBasedRegionEndpointProvider(regionEndpoint));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedCredentialsFileNameProvider"/> implementation of <see cref="ICredentialsFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedCredentialsFileNameProvider(this IServiceCollection services, string awsCredentialsFileName)
        {
            services.AddSingleton<ICredentialsFileNameProvider>(new ConstructorBasedCredentialsFileNameProvider(awsCredentialsFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedCredentialsFileNameProvider"/> implementation of <see cref="ICredentialsFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICredentialsFileNameProvider> AddConstructorBasedCredentialsFileNameProviderAction(this IServiceCollection services, string awsCredentialsFileName)
        {
            var serviceAction = ServiceAction.New<ICredentialsFileNameProvider>(() => services.AddConstructorBasedCredentialsFileNameProvider(awsCredentialsFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="AWSCredentialsProvider"/> implementation of <see cref="IAWSCredentialsProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAWSCredentialsProvider(this IServiceCollection services,
            IServiceAction<ICredentialsFilePathProvider> awsCredentialFilePathProviderAction)
        {
            services
                .AddSingleton<IAWSCredentialsProvider, AWSCredentialsProvider>()
                .Run(awsCredentialFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OurAwsCredentialProvider"/> implementation of <see cref="IOurAwsCredentialProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAWSCredentialsProvider> AddAWSCredentialsProviderAction(this IServiceCollection services,
            IServiceAction<ICredentialsFilePathProvider> awsCredentialFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<IAWSCredentialsProvider>(() => services.AddAWSCredentialsProvider(
                awsCredentialFilePathProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="AWSCredentials"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAWSCredentials(this IServiceCollection services,
            IServiceAction<IAWSCredentialsProvider> awsCredentialsProviderAction)
        {
            services
                .AddSingleton<AWSCredentials>((serviceProvider) =>
                {
                    // Causes deadlock when there's a Task.Run() inside a Task.Run()?
                    //var ourAwsCredentialOuter = Task.Run(async () =>
                    //{
                    //    var ourAwsCredentialProvider = serviceProvider.GetRequiredService<IOurAwsCredentialProvider>();

                    //    var ourAwsCredential = await ourAwsCredentialProvider.GetAwsCredential();
                    //    return ourAwsCredential;
                    //}).Result; // Bad, sync-over-async, but service provider API is sync so can't be helped.

                    var awsCredentialProvider = serviceProvider.GetRequiredService<IAWSCredentialsProvider>();

                    var awsCredentials = awsCredentialProvider.GetAWSCredentials().Result; // Bad, sync-over-async, but service provider API is sync so can't be helped.
                    return awsCredentials;
                })
                .Run(awsCredentialsProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AWSCredentials"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<AWSCredentials> AddAWSCredentialsAction(this IServiceCollection services,
            IServiceAction<IAWSCredentialsProvider> awsCredentialsProviderAction)
        {
            var serviceAction = ServiceAction.New<AWSCredentials>(() => services.AddAWSCredentials(
                awsCredentialsProviderAction));

            return serviceAction;
        }
    }
}
