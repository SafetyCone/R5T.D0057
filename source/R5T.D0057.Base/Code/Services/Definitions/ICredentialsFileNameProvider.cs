using System;
using System.Threading.Tasks;


namespace R5T.D0057
{
    public interface ICredentialsFileNameProvider
    {
        Task<string> GetCredentialsFileName();
    }
}
