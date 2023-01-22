using static Utility.SD;

namespace CallWebAPI.Model
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.Get;
        public string URL { get; set; }
        public object Data { get; set; }
    }
}
