using Newtonsoft.Json;

namespace WonderTools.Eagle.Nunit.NUnitResult
{
    public class StringHolder
    {
        [JsonProperty("#cdata-section")]
        public string Data { get; set; }
    }
}