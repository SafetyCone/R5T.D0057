using System;
using System.Threading.Tasks;

using R5T.Suebia;

using R5T.T0064;


namespace R5T.D0057.Suebia
{
    [ServiceImplementationMarker]
    public class CredentialsFilePathProvider : ICredentialsFilePathProvider, IServiceImplementation
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
