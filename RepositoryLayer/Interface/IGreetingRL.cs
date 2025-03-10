﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;
using ModelLayer.Model;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        string Greet();
        GreetingEntity SaveGreeting(GreetingMessageModel greeting);
        string GetGreetingMessageByID(int id);
        List<string> GetMessagesList();
        GreetingEntity UpdateGreeting(int id, string message);

        GreetingEntity DeleteGreeting(int id);
    }
}