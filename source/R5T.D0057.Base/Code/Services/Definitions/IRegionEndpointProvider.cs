using System;
using System.Threading.Tasks;

using Amazon;


namespace R5T.D0057
{
    public interface IRegionEndpointProvider
    {
        Task<RegionEndpoint> GetRegionEndpoint();
    }
}
