using System;
using System.Threading.Tasks;

using R5T.Suebia;


namespace R5T.D0057.Suebia
{
    public class CredentialsFilePathProvider : ICredentialsFilePathProvider
    {
        private ICredentialsFileNameProvider CredentialFileNameProvider { get; }
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public CredentialsFilePathProvider(
            ICredentialsFileNameProvider credentialFileNameProvider,
            ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.CredentialFileNameProvider = credentialFileNameProvider;
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public async Task<string> GetCredentialsFilePath()
        {
            var credentialsFileName = await this.CredentialFileNameProvider.GetCredentialsFileName();

            var credentialsFilePath = await this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(credentialsFileName);
            return credentialsFilePath;
        }
    }
}
