using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string Greet();
        string GreetByName(GreetingRequestModel greetRequest);
        GreetingEntity SaveGreeting(GreetingMessageModel greetingRequest);
        string GetGreetingMessageByID(int id);
        List<string> GetMessagesList();
    }
}
