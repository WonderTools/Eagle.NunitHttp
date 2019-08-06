using Newtonsoft.Json;

namespace WonderTools.Eagle.Nunit.NUnitDiscovery
{
    public class NUnitDiscoveryRoot
    {
        [JsonProperty("test-run")]
        public NUnitTestRun TestRun { get; set; }
    }
}