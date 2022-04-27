using System;
using System.Threading.Tasks;

using Amazon;

using R5T.T0064;


namespace R5T.D0057
{
    [ServiceImplementationMarker]
    public class ConstructorBasedRegionEndpointProvider : IRegionEndpointProvider, IServiceImplementation
    {
        private RegionEndpoint RegionEndpoint { get; }


        public ConstructorBasedRegionEndpointProvider(
            [NotServiceComponent] RegionEndpoint regionEndpoint)
        {
            this.RegionEndpoint = regionEndpoint;
        }

        public Task<RegionEndpoint> GetRegionEndpoint()
        {
            return Task.FromResult(this.RegionEndpoint);
        }
    }
}
