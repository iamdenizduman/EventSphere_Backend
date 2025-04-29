using EventSphere.Core.Enums;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.Core.Result;
using EventSphere.Identity.Application.Common.Interfaces.Security;
using EventSphere.Identity.Domain.Entities;
using EventSphere.Identity.Domain.Repositories;
using MediatR;

namespace EventSphere.Identity.Application.Features.Users.RegisterUser
{
    public class RegisterUserHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IHashingHelper hashingHelper, IUnitOfWork unitOfWork, IOperationClaimReadRepository operationClaimReadRepository, IOperationClaimWriteRepository operationClaimWriteRepository, IUserOperationClaimWriteRepository userOperationClaimWriteRepository) : IRequestHandler<RegisterUserRequest, DataResult<RegisterUserResponse>>
    {
        private readonly IUserWriteRepository _userWriteRepository = userWriteRepository;
        private readonly IUserReadRepository _userReadRepository = userReadRepository;
        private readonly IHashingHelper _hashingHelper = hashingHelper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOperationClaimReadRepository _operationClaimReadRepository = operationClaimReadRepository;
        private readonly IOperationClaimWriteRepository _operationClaimWriteRepository = operationClaimWriteRepository;
        private readonly IUserOperationClaimWriteRepository _userOperationClaimWriteRepository = userOperationClaimWriteRepository;

        public async Task<DataResult<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var existMail = await _userReadRepository.GetSingleAsync(u => u.Email == request.Email);

            if (existMail != null)
                return new DataResult<RegisterUserResponse>(null, ResultStatus.Error, "Mail sistemde kayıtlı");

            _hashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Domain.Entities.User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                CreatedDate = DateTime.UtcNow
            };

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _userWriteRepository.AddAsync(user);
                var saveChangesCount = await _unitOfWork.SaveChangesAsync();
               
                if (saveChangesCount > 0)
                {
                    var operationClaim = await _operationClaimReadRepository.GetSingleAsync(x => x.Name == "Customer");

                    if (operationClaim == null)
                    {
                        operationClaim = new OperationClaim
                        {
                            Name = "Customer",
                            CreatedDate = DateTime.UtcNow
                        };

                        await _operationClaimWriteRepository.AddAsync(operationClaim);
                        await _unitOfWork.SaveChangesAsync();
                    }

                    var userOperationClaim = new UserOperationClaim
                    {
                        UserId = user.RecordId,
                        OperationClaimId = operationClaim.RecordId,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _userOperationClaimWriteRepository.AddAsync(userOperationClaim);
                    await _unitOfWork.SaveChangesAsync();

                    await _unitOfWork.CommitAsync();

                    var response = new RegisterUserResponse
                    {
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Role = operationClaim.Name
                    };

                    return new DataResult<RegisterUserResponse>(response, ResultStatus.Success, "Başarıyla kaydedildi");
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new DataResult<RegisterUserResponse>(null, ResultStatus.Error, ex.Message);
            }

            return new DataResult<RegisterUserResponse>(null, ResultStatus.Error, "Kaydedilirken bir sorun yaşandı");
        }
    }
}
