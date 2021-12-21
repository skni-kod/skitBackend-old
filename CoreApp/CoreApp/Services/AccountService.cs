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
}

