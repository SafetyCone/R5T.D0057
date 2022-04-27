using System;
using System.Threading.Tasks;

using Amazon.Runtime;

using R5T.T0064;


namespace R5T.D0057
{
    [ServiceDefinitionMarker]
    public interface IAWSCredentialsProvider : IServiceDefinition
    {
        Task<AWSCredentials> GetAWSCredentials();
    }
}
