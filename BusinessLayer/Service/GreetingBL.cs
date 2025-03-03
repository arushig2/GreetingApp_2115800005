﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;

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
    }
}
