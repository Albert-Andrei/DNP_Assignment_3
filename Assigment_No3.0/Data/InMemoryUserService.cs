using System;
using System.Collections.Generic;
using System.Linq;
using Assigment_No3._0.Model;

namespace Assigment_No3._0.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    Password = "123456", SecurityLevel = 4, UserName = "Troels", UserId = 1
                },
                new User
                {
                    Password = "654321", SecurityLevel = 2, UserName = "Jakob", UserId = 2
                },
                new User
                {
                    Password = "1234567", SecurityLevel = 10, UserName = "Albert", UserId = 0    
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}