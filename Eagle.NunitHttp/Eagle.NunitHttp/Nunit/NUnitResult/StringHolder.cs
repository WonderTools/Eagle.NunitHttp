using Newtonsoft.Json;

namespace WonderTools.Eagle.NUnit.NUnitResult
{
    public class StringHolder
    {
        [JsonProperty("#cdata-section")]
        public string Data { get; set; }
    }
}