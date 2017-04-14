using System.Collections.Generic;
using System.Linq;
using webapi.Interfaces;
using webapi.Models;
using System;

namespace webapi.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TodoContext _context;

        public AuthRepository(TodoContext context)
        {
            _context = context;

            if( _context.TodoItems.Count() == 0)
                Add(new Token { Name = "Default", GeneratedToken = "generatedtoken", Expires = DateTime.Now, IsActive = true });
        }

        public Token Add(Token token)
        {
            _context.Tokens.Add(token);
            _context.SaveChanges();

            return token;
        }

        public Token Find(long key)
        {
            return _context.Tokens.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(long key)
        {
            var entity = _context.Tokens.First(t => t.Key == key);
            _context.Tokens.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Token item)
        {
            _context.Tokens.Update(item);
            _context.SaveChanges();
        }
    }
}