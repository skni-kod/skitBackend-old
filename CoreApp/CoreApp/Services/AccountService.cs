using CoreApp.Data.Dtos;

namespace CoreApp.Services;

public interface IAccountService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwt(LoginDto dto);
}

public class AccountService : IAccountService
{
    public AccountService()
    {
        
    }

    public void RegisterUser(RegisterUserDto dto)
    {
        throw new NotImplementedException();
    }

    public string GenerateJwt(LoginDto dto)
    {
        throw new NotImplementedException();
    }
}

