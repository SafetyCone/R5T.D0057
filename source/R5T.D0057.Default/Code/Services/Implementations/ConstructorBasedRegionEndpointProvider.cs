using System;
using System.Threading.Tasks;

using Amazon;


namespace R5T.D0057
{
    public class ConstructorBasedRegionEndpointProvider : IRegionEndpointProvider
    {
        private RegionEndpoint RegionEndpoint { get; }


        public ConstructorBasedRegionEndpointProvider(RegionEndpoint regionEndpoint)
        {
            this.RegionEndpoint = regionEndpoint;
        }

        public Task<RegionEndpoint> GetRegionEndpoint()
        {
            return Task.FromResult(this.RegionEndpoint);
        }
    }
}
