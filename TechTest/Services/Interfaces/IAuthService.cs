using ServiceReference;

namespace TechTest.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string UserName, string Password, string IPs);
    Task<RegisterNewCustomerResponse> RegisterAsync(string Email, string Password, string FirstName, string LastName, string Mobile, int CountryID, int aID, string signupIp);
}
