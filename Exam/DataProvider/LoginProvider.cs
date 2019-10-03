using Newtonsoft.Json;

namespace Exam.DataProvider
{
    //TODO
    [JsonObject(MemberSerialization.OptIn)]
    public class LoginProvider
    {
        [JsonProperty(PropertyName = "includeAttributes")]
        public string IncludeAttributes { get; } = "perm.*";

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; } = "admin@betlab";

        [JsonProperty(PropertyName = "password")]
        public string Password { get; } = "abc";
    }
}