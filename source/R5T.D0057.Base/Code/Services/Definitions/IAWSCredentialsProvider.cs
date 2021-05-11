using System;
using System.Threading.Tasks;

using Amazon.Runtime;


namespace R5T.D0057
{
    public interface IAWSCredentialsProvider
    {
        Task<AWSCredentials> GetAWSCredentials();
    }
}
