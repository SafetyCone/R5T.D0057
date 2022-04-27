using System;
using System.Threading.Tasks;

using Amazon;

using R5T.T0064;


namespace R5T.D0057
{
    [ServiceDefinitionMarker]
    public interface IRegionEndpointProvider : IServiceDefinition
    {
        Task<RegionEndpoint> GetRegionEndpoint();
    }
}
