namespace TechTest.DTOs;

public class LoginRequestDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string IPs { get; set; } = "127.0.0.1";
}
