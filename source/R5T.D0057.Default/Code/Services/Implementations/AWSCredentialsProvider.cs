using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Amazon.Runtime;


namespace R5T.D0057
{
    public class AWSCredentialsProvider : IAWSCredentialsProvider
    {
        public const string AccessKeyIDKeyName = "AccessKeyID";
        public const string SecretAccessKeyKeyName = "SecretAccessKey";


        private ICredentialsFilePathProvider CredentialsFilePathProvider { get; }


        public AWSCredentialsProvider(
            ICredentialsFilePathProvider credentialsFilePathProvider)
        {
            this.CredentialsFilePathProvider = credentialsFilePathProvider;
        }

        public async Task<AWSCredentials> GetAWSCredentials()
        {
            var awsCredentialFilePath = await this.CredentialsFilePathProvider.GetCredentialsFilePath();

            var jObject = await JsonHelper.LoadAsJObject(awsCredentialFilePath);

            var accessKey = jObject.Value<string>(AWSCredentialsProvider.AccessKeyIDKeyName);
            var secretKey = jObject.Value<string>(AWSCredentialsProvider.SecretAccessKeyKeyName);

            var credential = new BasicAWSCredentials(accessKey, secretKey);
            return credential;
        }
    }
}
