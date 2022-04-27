using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0057
{
    [ServiceImplementationMarker]
    public class ConstructorBasedCredentialsFileNameProvider : ICredentialsFileNameProvider, IServiceImplementation
    {
        private string CredentialsFileName { get; }


        public ConstructorBasedCredentialsFileNameProvider(
            [NotServiceComponent] string credentialsFileName)
        {
            this.CredentialsFileName = credentialsFileName;
        }

        public Task<string> GetCredentialsFileName()
        {
            return Task.FromResult(this.CredentialsFileName);
        }
    }
}
