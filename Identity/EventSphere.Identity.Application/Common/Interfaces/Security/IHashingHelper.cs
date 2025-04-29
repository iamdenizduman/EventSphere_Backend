namespace EventSphere.Identity.Application.Common.Interfaces.Security
{
    public interface IHashingHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
