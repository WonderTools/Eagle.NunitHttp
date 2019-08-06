using Newtonsoft.Json;

namespace WonderTools.Eagle.Nunit.NUnitResult
{
    public class NUnitResultRun
    {
        [JsonProperty("test-suite")]
        public NUnitResultTestSuite TestSuite { get; set; }
    }
}