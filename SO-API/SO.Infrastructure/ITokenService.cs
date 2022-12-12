using SO.DTO;

namespace SO.Infrastructure
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}