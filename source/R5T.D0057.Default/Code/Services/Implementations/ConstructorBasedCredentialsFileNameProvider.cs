using System;
using System.Threading.Tasks;


namespace R5T.D0057.Default
{
    public class ConstructorBasedCredentialsFileNameProvider : ICredentialsFileNameProvider
    {
        private string CredentialsFileName { get; }


        public ConstructorBasedCredentialsFileNameProvider(string credentialsFileName)
        {
            this.CredentialsFileName = credentialsFileName;
        }

        public Task<string> GetCredentialsFileName()
        {
            return Task.FromResult(this.CredentialsFileName);
        }
    }
}
