using System.Net;

namespace CallWebAPI.Model
{
    public class APIResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> ErrMessage { get; set; }
        public object Result { get; set; }
    }
}
