namespace EventSphere.Identity.Application.Models.Authentication
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
