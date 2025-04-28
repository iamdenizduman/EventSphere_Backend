using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.Identity.Application.Security.Interfaces;
using EventSphere.Identity.Domain.Repositories;
using MediatR;

namespace EventSphere.Identity.Application.Features.User.RegisterUser
{
    public class RegisterUserHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IPasswordHasher passwordHasher) : IRequestHandler<RegisterUserRequest, DataResult<RegisterUserResponse>>
    {
        private readonly IUserWriteRepository _userWriteRepository = userWriteRepository;
        private readonly IUserReadRepository _userReadRepository = userReadRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<DataResult<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var existMail = await _userReadRepository.GetSingleAsync(u => u.Email == request.Email);

            if (existMail == null)
                return new DataResult<RegisterUserResponse>(null, ResultStatus.Error, "Mail sistemde kayıtlı");
                
            _passwordHasher.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Domain.Entities.User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                CreatedDate = DateTime.Now                
            };

            await _userWriteRepository.AddAsync(user);            
            var saveChangesCount = await _userWriteRepository.SaveChangesAsync();

            if (saveChangesCount > 0)
            {
                var response = new RegisterUserResponse
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName= request.LastName,
                    Password = request.Password
                };

                return new DataResult<RegisterUserResponse>(response, ResultStatus.Success, "Başarıyla kaydedildi");
            }

            return new DataResult<RegisterUserResponse>(null, ResultStatus.Success, "Kaydedilirken sorun yaşandı");
        }
    }
}
