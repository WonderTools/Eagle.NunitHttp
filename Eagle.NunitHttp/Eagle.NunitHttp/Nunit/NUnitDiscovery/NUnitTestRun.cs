using Newtonsoft.Json;

namespace WonderTools.Eagle.Nunit.NUnitDiscovery
{
    public class NUnitTestRun
    {
        [JsonProperty("test-suite")]
        public NUnitTestSuite TestSuite { get; set; }
    }
}