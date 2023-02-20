using ISMS_API.DTOs;

namespace ISMS_API.Services.Abstract
{
    public interface ITokenService
    {
        string CreateToken(UserDto user);

    }
}
