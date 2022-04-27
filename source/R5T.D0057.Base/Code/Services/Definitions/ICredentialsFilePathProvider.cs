using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0057
{
    [ServiceDefinitionMarker]
    public interface ICredentialsFilePathProvider : IServiceDefinition
    {
        Task<string> GetCredentialsFilePath();
    }
}
