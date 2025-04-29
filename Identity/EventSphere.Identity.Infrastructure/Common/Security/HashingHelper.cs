﻿using EventSphere.Identity.Application.Common.Interfaces.Security;
using System.Text;

namespace EventSphere.Identity.Infrastructure.Common.Security
{
    public class HashingHelper : IHashingHelper
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            byte[] computedHash;

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                    return false;
            }
            return true;
        }
    }
}
