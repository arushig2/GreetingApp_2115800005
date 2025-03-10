﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Entity;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string Greet()
        {
            return _greetingRL.Greet();
        }

        public string GreetByName(GreetingRequestModel greetRequest)
        {
            var result = "";
           if(!(string.IsNullOrWhiteSpace(greetRequest.FirstName)) &&  !(string.IsNullOrWhiteSpace(greetRequest.LastName)))
            {
               result = "Hello " + greetRequest.FirstName + " " + greetRequest.LastName;
            } else if(!(string.IsNullOrWhiteSpace(greetRequest.FirstName)))
            {
                result = "Hello " + greetRequest.FirstName;
            }
            else if (!(string.IsNullOrWhiteSpace(greetRequest.LastName)))
            {
                result = "Hello " + greetRequest.LastName;
            }
            else
            {
                result = _greetingRL.Greet();
            }

            return result;

        }

        public GreetingEntity SaveGreeting(GreetingMessageModel greeting)
        {
            var result = _greetingRL.SaveGreeting(greeting);
            return result;
        }

        public string GetGreetingMessageByID(int id)
        {
            var result = _greetingRL.GetGreetingMessageByID(id);
            return result;
        }
        public List<string> GetMessagesList()
        {
            var result = _greetingRL.GetMessagesList();
            return result;
        }

        public GreetingEntity UpdateGreeting(int id, string message)
        {
            var result = _greetingRL.UpdateGreeting(id, message);
            return result;
        }

        public GreetingEntity DeleteGreeting(int id)
        {
            var result = _greetingRL.DeleteGreeting(id);
            return result;
        }
    }
}
