using ServiceReference;
using System.Text;
using TechTest.Services.Interfaces;
using System.Xml.Serialization;

namespace TechTest.Services;

public class AuthService : IAuthService
{
    private readonly ICUTechClient _soapClient;

    public AuthService(HttpClient httpClient, ICUTechClient soapClient)
    {
        _soapClient = soapClient;
    }

    public async Task<LoginResponse> LoginAsync(string UserName, string Password, string IPs)
    {
        return await _soapClient.LoginAsync(UserName, Password, IPs);
    }

    public async Task<RegisterNewCustomerResponse> RegisterAsync(string Email, string Password, string FirstName, string LastName, string Mobile, int CountryID, int aID, string signupIp)
    {
        return await _soapClient.RegisterNewCustomerAsync(Email, Password, FirstName, LastName, Mobile, CountryID, aID, signupIp);
    }
}
