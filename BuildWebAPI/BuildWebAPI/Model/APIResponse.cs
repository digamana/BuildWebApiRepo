using System.Net;

namespace BuildWebAPI.Model
{
    public class APIResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public IEnumerable<string> ErrMessage { get; set; }
        public object Result { get; set; }
    }
}
