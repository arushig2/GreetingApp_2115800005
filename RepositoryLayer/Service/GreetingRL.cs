using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using ModelLayer.Model;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {

        GreetingDbContext _dbContext;

        public GreetingRL(GreetingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Greet()
        {
            return "Hello World";
        }

        public GreetingEntity SaveGreeting(GreetingMessageModel greeting)
        {
           var result = _dbContext.Greetings.FirstOrDefault<GreetingEntity>(g => g.Message == greeting.Message);
            if (result == null)
            {
                var greet = new GreetingEntity
                {
                    Message = greeting.Message
                };

                _dbContext.Greetings.Add(greet);
                _dbContext.SaveChanges();
                return greet;
            }

            return result;

        }

        public string GetGreetingMessageByID(int id)
        {
            var result = _dbContext.Greetings.FirstOrDefault<GreetingEntity>(g => g.Id == id);
            if (result != null)
            {
                return result.Message;
            }
            return null;
        }

        public List<string> GetMessagesList()
        {
            var result = _dbContext.Greetings.Select(g => g.Message).ToList();
            return result;
        }
    }
}
