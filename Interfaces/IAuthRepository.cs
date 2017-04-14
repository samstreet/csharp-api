using webapi.Models;

namespace webapi.Interfaces
{
    public interface IAuthRepository
    {
        Token Add(Token token);
        Token Find(long key);
        void Remove(long key);
        void Update(Token item);
    }
}