using System.Collections.Generic;
using System.Linq;
using webapi.Interfaces;
using webapi.Models;
using System;

namespace webapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _context;

        public UserRepository(TodoContext context)
        {
            _context = context;

            if( _context.Users.Count() == 0)
                Add(new User { FirstName = "Sam", LastName = "Street", PublicId = "qwertyuiop", Username = "sam", Password = "1234" });
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Add(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();

            return item;
        }

        public User FindById(int key)
        {
            return _context.Users.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(long key)
        {
            var entity = _context.Users.First(t => t.Key == key);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }

        public Token Authenticate(User user)
        {
            var entity = _context.Users.First(t => t.Username == user.Username);
            return new Token{ Name = user.Username + "_", Expires = DateTime.Now.AddHours(24), GeneratedToken = "ballsack", IsActive = true};
        }
    }
}