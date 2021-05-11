using System;
using System.Threading.Tasks;


namespace R5T.D0057
{
    public interface ICredentialsFilePathProvider
    {
        Task<string> GetCredentialsFilePath();
    }
}
