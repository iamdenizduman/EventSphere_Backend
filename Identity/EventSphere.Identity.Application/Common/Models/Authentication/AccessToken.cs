namespace EventSphere.Identity.Application.Common.Models.Authentication
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
