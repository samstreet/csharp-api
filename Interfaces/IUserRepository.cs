using webapi.Models;

namespace webapi.Interfaces
{
    public interface IUserRepository
    {
        User Add(User token);
        User FindById(int id);
        void Remove(long key);
        void Update(User item);
        Token Authenticate(User user);
    }
}