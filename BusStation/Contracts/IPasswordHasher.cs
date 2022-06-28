namespace BusStation.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
