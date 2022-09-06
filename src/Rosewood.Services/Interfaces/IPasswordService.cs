namespace Rosewood.Services.Interfaces;

public interface IPasswordService
{
    string HashPassword(string password);
}
